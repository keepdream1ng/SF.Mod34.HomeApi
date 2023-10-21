using System.ComponentModel.DataAnnotations;

namespace SF.Mod34.HomeApi.Contracts.Models.Devices;
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
	public int CurrentVolts { get; set; }
	[Required]
	public bool GasUsage { get; set; }
	[Required]
	public string Location { get; set; }
}
