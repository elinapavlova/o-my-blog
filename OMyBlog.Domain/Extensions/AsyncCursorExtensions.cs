using System.Runtime.CompilerServices;
using MongoDB.Driver;
using MongoDB.Driver.Core.Operations;

namespace OMyBlog.Domain.Extensions;

public static class AsyncCursorExtensions
{
    public static IAsyncEnumerable<TDocument> ToAsyncEnumerable<TDocument>(this IAsyncCursor<TDocument> cursor)
    {
        if (cursor is null) throw new ArgumentNullException(nameof(cursor));

        return new AsyncCursorAsyncEnumerableAdapter<TDocument>(cursor);
    }

    private static async IAsyncEnumerable<TDocument> ToAsyncEnumerable<TDocument>(
        IAsyncCursorSource<TDocument>? source,
        IAsyncCursor<TDocument>? cursor,
        [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        cursor ??= await source!.ToCursorAsync(cancellationToken).ConfigureAwait(false);

        try
        {
            while (await cursor.MoveNextAsync(cancellationToken).ConfigureAwait(false))
            {
                foreach (var document in cursor.Current)
                {
                    yield return document;
                    cancellationToken.ThrowIfCancellationRequested();
                }
            }
        }
        finally
        {
            if (cursor is AsyncCursor<TDocument> asyncCursor)
            {
                await asyncCursor.CloseAsync(cancellationToken).ConfigureAwait(false);
            }

            cursor.Dispose();
        }
    }

    private class AsyncCursorAsyncEnumerableAdapter<TDocument> : IAsyncEnumerable<TDocument>
    {
        private readonly IAsyncCursor<TDocument> _cursor;
        private bool _enumerated;

        public AsyncCursorAsyncEnumerableAdapter(IAsyncCursor<TDocument> cursor)
        {
            _cursor = cursor;
        }

        public IAsyncEnumerator<TDocument> GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            if (_enumerated)
            {
                throw new InvalidOperationException("An IAsyncCursor can only be enumerated once");
            }

            _enumerated = true;

            return 
                ToAsyncEnumerable(null, _cursor, cancellationToken).
                    GetAsyncEnumerator(cancellationToken);
        }
    }
}