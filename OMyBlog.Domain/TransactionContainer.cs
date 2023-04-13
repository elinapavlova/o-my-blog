using MongoDB.Driver;

namespace OMyBlog.Domain;

public class TransactionContainer : IAsyncDisposable
{
    public bool HasError { get; set; }
    public IClientSessionHandle Session { get; set; }

    public TransactionContainer(IClientSessionHandle session, bool hasError = false)
    {
        HasError = hasError;
        Session = session;
    }

    public async ValueTask DisposeAsync()
    {
        if (HasError is false)
        {
            await Session.CommitTransactionAsync();
            return;
        }

        await Session.AbortTransactionAsync();
    }
}