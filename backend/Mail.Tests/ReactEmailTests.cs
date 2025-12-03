using Core.Services;
using FluentAssertions;
using Mail.Services;
using Moq;

namespace Mail.Tests;

public class ReactEmailTests
{
    private readonly Mock<IFrontendLocation> frontendLocation = new();

    public ReactEmailTests()
    {
        frontendLocation.Setup(l => l.GetFromPath(It.IsAny<string>()))
            .Returns((string path) => new Uri("https://example.com" + path));
    }

    [Fact]
    public async Task CreateAsync_ThrowsIfNotEverythingReplaced()
    {
        var exception = await Assert.ThrowsAsync<InvalidOperationException>(() => ReactEmail.CreateAsync(
            new EmailAddress("hosting-noreply@notifications.compozerr.com", "compozerr hosting"),
            [new EmailAddress("email@example.com", "User Name")],
            "Bla bla",
            new MissingPaymentMethodTemplate()
            {
                CustomerName = "User Name",
                CompanyName = "Compozerr Hosting",
                Description = "Some description",
                // AddPaymentMethodUrl MISSING
                DashboardLink = frontendLocation.Object.GetFromPath("/projects").ToString(),
                ContactLink = frontendLocation.Object.GetFromPath("/contact").ToString(),
                CompanyAddress = "Whatever"
            }));

        exception.Message.Should().Contain("Unmatched placeholder found in template:");
    }
}

public sealed class MissingPaymentMethodTemplate : ReactEmailTemplate
{
    public MissingPaymentMethodTemplate() : base("Emails/missing-payment-method-mock.html") { }

    public required string CompanyName { get; init; }
    public required string CustomerName { get; init; }
    public required string Description { get; init; }
    public required string DashboardLink { get; init; }
    public required string ContactLink { get; init; }
    public required string CompanyAddress { get; init; }

}