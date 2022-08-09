using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using NUnit.Framework;
using rwe.common;

namespace rwe.tests;

[TestFixture]
public class Tests {

	IConfigurationRoot configuration;
	readonly RweSettingsOptions rweSettingsOptions;

	public Tests() {
		configuration = new ConfigurationBuilder()
				               .AddJsonFile("appsettings.json")
				               .Build();

		rweSettingsOptions = new RweSettingsOptions();
		configuration.GetSection("RweSettings").Bind(rweSettingsOptions);

	}

	[Test]
	public async Task GetParks() {
		using (var httpClient = new HttpClient()) {
			var client = new WindparkClient(httpClient, Options.Create(rweSettingsOptions));
			var parks = await client.GetParks();
			Assert.AreEqual(2, parks.Count);

			Assert.AreEqual(6, parks[0].Turbines.Count);
		}
	}
	[Test]
	public async Task GetPark() {
		using (var httpClient = new HttpClient()) {
			var client = new WindparkClient(httpClient, Options.Create(rweSettingsOptions));
			var park = await client.GetPark(1);
			Assert.IsNotNull(park);

			Assert.AreEqual(6, park.Turbines.Count);
		}
	}

}
