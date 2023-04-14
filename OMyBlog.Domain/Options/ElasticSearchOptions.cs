namespace OMyBlog.Domain.Options;

public class ElasticSearchOptions
{
    public string CertificateFingerPrint { get; set;}
    public string ConnectionPool { get; set;}
    public AuthenticationInfo Authentication { get; set;}
}

public class AuthenticationInfo
{
    public string Username { get; set;}
    public string Password { get; set;}
}