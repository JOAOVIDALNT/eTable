using CommonTestUtilities.Builders.Requests;
using FluentAssertions;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace API.Test.User
{
    public class RegisterUserTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _httpClient;
        public RegisterUserTest(CustomWebApplicationFactory factory) => _httpClient = factory.CreateClient();


        [Fact]
        public async Task Success()
        {
            var request = RegisterUserRequestBuilder.Build();

            var response = await _httpClient.PostAsJsonAsync("User", request);

            response.StatusCode.Should().Be(HttpStatusCode.Created);

            await using var responseBody = await response.Content.ReadAsStreamAsync();

            var responseData = await JsonDocument.ParseAsync(responseBody);

            responseData.RootElement.GetProperty("name").GetString().Should().NotBeNullOrWhiteSpace().And.Be(request.Name);
        }
    }
}
