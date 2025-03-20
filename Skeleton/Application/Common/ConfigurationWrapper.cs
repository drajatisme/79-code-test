namespace Skeleton.Application.Common;

public record ConfigurationWrapper
{
    public JwtConfigurationWrapper? Jwt { get; set; }
    public ConnectionStringsWrapper? ConnectionStrings { get; set; }
    public List<string>? Policies { get; set; }
}

public record JwtConfigurationWrapper
{
    public required string Secret { get; set; }
    public required string Issuer { get; set; }
    public required string Audience { get; set; }
}

public record ConnectionStringsWrapper
{
    public required string DefaultConnection { get; set; }
}

