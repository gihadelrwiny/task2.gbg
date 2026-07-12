using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using task21.DTO;

namespace Tests
{
    public class BooksTests :
    IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _client;

        public BooksTests(CustomWebApplicationFactory factory)
        {
            _client = factory.CreateClient();
        }
        [Fact]
       
        public async Task GetAll_Returns200()
        {
            // Register
            var registerDto = new RegisterDto
            {
                UserName = "testuser",
                Email = "user@gmail.com",
                Password = "User123@"
            };

            await _client.PostAsJsonAsync("/api/Auth/register", registerDto);

            // Login
            var loginDto = new LoginDto
            {
                Email = "user@gmail.com",
                Password = "User123@"
            };

            var loginResponse = await _client.PostAsJsonAsync("/api/Auth/login", loginDto);

            Assert.Equal(HttpStatusCode.OK, loginResponse.StatusCode);

            var auth = await loginResponse.Content.ReadFromJsonAsync<AuthResponseDto>();

            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", auth!.AccessToken);

            // Call protected endpoint
            var response = await _client.GetAsync("/api/v1/books");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
        [Fact]
        public async Task GetById_InvalidId_Returns404()
        {
            // Register
            var registerDto = new RegisterDto
            {
                UserName = "testuser2",
                Email = "user2@gmail.com",
                Password = "User123@"
            };

            await _client.PostAsJsonAsync("/api/Auth/register", registerDto);

            // Login
            var loginDto = new LoginDto
            {
                Email = "user2@gmail.com",
                Password = "User123@"
            };

            var loginResponse = await _client.PostAsJsonAsync("/api/Auth/login", loginDto);

            Assert.Equal(HttpStatusCode.OK, loginResponse.StatusCode);

            var auth = await loginResponse.Content.ReadFromJsonAsync<AuthResponseDto>();

            _client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", auth!.AccessToken);

            // Request invalid id
            var response = await _client.GetAsync("/api/v1/books/999");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using task21.DTO;

namespace Tests
    {
        public class BooksTests :
        IClassFixture<CustomWebApplicationFactory>
        {
            private readonly HttpClient _client;

            public BooksTests(CustomWebApplicationFactory factory)
            {
                _client = factory.CreateClient();
            }
            [Fact]

            public async Task GetAll_Returns200()
            {
                // Register
                var registerDto = new RegisterDto
                {
                    UserName = "testuser",
                    Email = "user@gmail.com",
                    Password = "User123@"
                };

                await _client.PostAsJsonAsync("/api/Auth/register", registerDto);

                // Login
                var loginDto = new LoginDto
                {
                    Email = "user@gmail.com",
                    Password = "User123@"
                };

                var loginResponse = await _client.PostAsJsonAsync("/api/Auth/login", loginDto);

                Assert.Equal(HttpStatusCode.OK, loginResponse.StatusCode);

                var auth = await loginResponse.Content.ReadFromJsonAsync<AuthResponseDto>();

                _client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", auth!.AccessToken);

                // Call protected endpoint
                var response = await _client.GetAsync("/api/v1/books");

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
            [Fact]
            public async Task GetById_InvalidId_Returns404()
            {
                // Register
                var registerDto = new RegisterDto
                {
                    UserName = "testuser2",
                    Email = "user2@gmail.com",
                    Password = "User123@"
                };

                await _client.PostAsJsonAsync("/api/Auth/register", registerDto);

                // Login
                var loginDto = new LoginDto
                {
                    Email = "user2@gmail.com",
                    Password = "User123@"
                };

                var loginResponse = await _client.PostAsJsonAsync("/api/Auth/login", loginDto);

                Assert.Equal(HttpStatusCode.OK, loginResponse.StatusCode);

                var auth = await loginResponse.Content.ReadFromJsonAsync<AuthResponseDto>();

                _client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", auth!.AccessToken);

                // Request invalid id
                var response = await _client.GetAsync("/api/v1/books/999");

                Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
            }
            [Fact]
            public async Task CreateBook_WithoutAuth_Returns401()
            {
                var dto = new
                {
                    Name = "Book",
                    Author = "Me",
                    Price = 100
                };

                var response =
                    await _client.PostAsJsonAsync(
                        "/api/v1/books",
                        dto);

                Assert.Equal(HttpStatusCode.Unauthorized,
                    response.StatusCode);
            }
        }
    }

}
}
