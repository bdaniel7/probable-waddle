using System.Text.Json;
using Microsoft.Extensions.Options;

namespace rwe.common;

public class WindparkClient {
	readonly HttpClient httpClient;
	readonly RweSettingsOptions rweOptions;

	public WindparkClient(HttpClient thisHttpClient, IOptions<RweSettingsOptions> rweSettings) {
		httpClient = thisHttpClient;
		rweOptions = rweSettings.Value;
	}

	public async Task<List<WindPark>> GetParks() {
		var response = await httpClient.GetAsync(rweOptions.ApiEndpoint);
		response.EnsureSuccessStatusCode();
		var parks = await response.Content.ReadAsStringAsync();

		return JsonSerializer.Deserialize<List<WindPark>>(parks);
	}

	public async Task<WindPark?> GetPark(int parkId) {
		var response = await httpClient.GetAsync($"{rweOptions.ApiEndpoint}/{parkId}");
		response.EnsureSuccessStatusCode();
		var park = await response.Content.ReadAsStringAsync();

		return JsonSerializer.Deserialize<WindPark>(park, new JsonSerializerOptions()
		                                                  {
                                                          PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                                                      });
	}
}
