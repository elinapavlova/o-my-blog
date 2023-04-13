namespace OMyBlog.Domain.Options;

public class AppOptions
{
    public DefaultApiVersion DefaultApiVersion { get; set; }
}

public class DefaultApiVersion
{
    public int MajorVersion { get; set; }
    public int MinorVersion { get; set; }
}