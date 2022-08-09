using rwe.common;

namespace rwe.worker;

public class RweWorker : BackgroundService {
	readonly WindparkClient windparkClient;
	private readonly ILogger<RweWorker> _logger;

	public RweWorker(WindparkClient windparkClient, ILogger<RweWorker> logger) {
		this.windparkClient = windparkClient;
		_logger = logger;
	}

	protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
		while (!stoppingToken.IsCancellationRequested) {
			_logger.LogInformation("Worker running at UTC: {utcTime}, now: {localTime}",
															DateTimeOffset.UtcNow, DateTimeOffset.Now);

			// get data
			var parks = windparkClient.GetParks();


			await Task.Delay(1 * 60 * 1000, stoppingToken);
		}
	}
}
