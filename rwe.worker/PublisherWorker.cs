namespace rwe.worker;

public class PublisherWorker : BackgroundService {

	private readonly ILogger<PublisherWorker> _logger;

	public PublisherWorker(ILogger<PublisherWorker> Logger) {
		_logger = Logger;
	}

	/// <inheritdoc />
	protected override async Task ExecuteAsync(CancellationToken stoppingToken) {

	}
}
