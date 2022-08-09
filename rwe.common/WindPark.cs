namespace rwe.common;

public class WindPark {
	public string Name { get; set; }

	public string Description { get; set; }

	public int Id { get; set; }

	public string Region { get; set; }

	public string Country { get; set; }

	public virtual HashSet<Turbine> Turbines { set; get; } = new();

}
