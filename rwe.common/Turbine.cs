namespace rwe.common;

public class Turbine {
	public int Id { get; set; }

	public string Name { get; set; }

	public string? Manufacturer { get; set; }

	public int Version { get; set; }

	public int MaxProduction { get; set; }

	// Megawatt
	public decimal CurrentProduction { get; set; }

	public decimal Windspeed { get; set; }

	public string? WindDirection { get; set; }
}