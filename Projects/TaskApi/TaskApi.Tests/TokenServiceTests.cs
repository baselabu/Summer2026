using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using TaskApi.Models;
using TaskApi.Services;

namespace TaskApi.Tests;

public class TokenServiceTests
{
    [Fact]
    public void GenerateToken_ReturnsJwtWithExpectedClaims()
    {
        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string?>
            {
                ["Jwt:Key"] = "a-very-long-secret-key-for-tests-only",
                ["Jwt:Issuer"] = "TaskApiIssuer",
                ["Jwt:Audience"] = "TaskApiAudience"
            })
            .Build();

        var service = new TokenService(configuration);
        var user = new User
        {
            Id = 42,
            Username = "alice"
        };

        var tokenString = service.GenerateToken(user);
        var token = new JwtSecurityTokenHandler().ReadJwtToken(tokenString);

        Assert.Equal("TaskApiIssuer", token.Issuer);
        Assert.Contains("TaskApiAudience", token.Audiences);
        Assert.Contains(token.Claims, claim => claim.Type == System.Security.Claims.ClaimTypes.Name && claim.Value == user.Username);
        Assert.Contains(token.Claims, claim => claim.Type == System.Security.Claims.ClaimTypes.NameIdentifier && claim.Value == user.Id.ToString());
        Assert.Contains(token.Claims, claim => claim.Type == System.Security.Claims.ClaimTypes.Role && claim.Value == "User");
    }

    [Fact]
    public void GenerateToken_WhenKeyMissing_Throws()
    {
        var configuration = new ConfigurationBuilder().Build();
        var service = new TokenService(configuration);

        var exception = Assert.Throws<InvalidOperationException>(() => service.GenerateToken(new User { Id = 1, Username = "alice" }));

        Assert.Equal("Jwt:Key is missing.", exception.Message);
    }
}