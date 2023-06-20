using BugTracker.Application.Common.Interfaces;
using BugTracker.Persistance;
using IdentityModel.Client;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;

namespace BugTracker.IntegrationTests.Common
{
    public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
			try
			{
				builder.ConfigureServices(services =>
				{
                    var serviceProvider = new ServiceCollection()
					.AddEntityFrameworkInMemoryDatabase()
					.BuildServiceProvider();

					services.AddDbContext<BugDbContext>(options =>
					{
						options.UseInMemoryDatabase("InMemoryDatabase");
						options.UseInternalServiceProvider(serviceProvider);
					});

					services.AddScoped<IBugDbContext>(provider => provider.GetService<BugDbContext>());

					var sp = services.BuildServiceProvider();
					using var scope = sp.CreateScope();

					var scopedService = scope.ServiceProvider;
					var context = scopedService.GetRequiredService<BugDbContext>();
					var logger = scopedService.GetRequiredService<ILogger<CustomWebApplicationFactory<TProgram>>>();

					context.Database.EnsureCreated();

					try
					{
						Utilities.InitilizeDbForTests(context);
					}
					catch (Exception ex)
					{
						logger.LogError(ex, "An error occured seeding the " +
							$"database with test messages. Error: {ex.Message}");
					}
					
                })
					.UseSerilog()
					.UseEnvironment("Test");
			}
			catch (Exception ex)
			{

				throw;
			}

            builder.UseEnvironment("Development");
        }

		public async Task<HttpClient> GetAuthenticatedClientAsync()
		{
			var client = CreateClient();

			var token = await GetAccessTokenAsync(client, "alice", "Pass123$");
			client.SetBearerToken(token);

			return client;
		}

        private async Task<string> GetAccessTokenAsync(HttpClient client, string userName, string password)
        {
			var disco = await client.GetDiscoveryDocumentAsync();

			if (disco.IsError)
			{
				throw new Exception(disco.Error);
			}

			var response = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
			{
				Address = disco.TokenEndpoint,
				ClientId = "client",
				ClientSecret = "secret",
				Scope = "openid profile BugTracker api1",
				UserName = userName,
				Password = password
			});

			if (response.IsError)
			{
				throw new Exception(response.Error);
			}

			return response.AccessToken;

        }
    }
}
