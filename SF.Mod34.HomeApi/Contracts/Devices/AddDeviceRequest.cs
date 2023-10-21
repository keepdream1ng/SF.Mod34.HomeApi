using System.ComponentModel.DataAnnotations;

namespace SF.Mod34.HomeApi.Contracts;
public class AddDeviceRequest
{
	[Required]
	public string Name { get; set; }
	[Required]
	public string Manufacturer { get; set; }
	[Required]
	public string Model { get; set; }
	[Required]
	public string SerialNumber { get; set; }
	[Required]
	[Range(120, 220, ErrorMessage = "Electric system suppors voltage from {1} to {2} volts")]
	public int CurrentVolts { get; set; }
	[Required]
	public bool GasUsage { get; set; }
	[Required]
	public string Location { get; set; }
}
