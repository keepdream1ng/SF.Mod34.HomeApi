using FluentValidation;
using SF.Mod34.HomeApi.Contracts.Models.Devices;

namespace SF.Mod34.HomeApi.Contracts.Validators.Devices;

public class AddDeviceRequestValidator : AbstractValidator<AddDeviceRequest>
{
	string[] _validLocations;

	/// <summary>
	/// Метод, конструктор, устанавливающий правила
	/// </summary>
	public AddDeviceRequestValidator()
	{
		_validLocations = new[]
		{
		   "Kitchen",
		   "Bathroom",
		   "Livingroom",
		   "Toilet"
	   };

		RuleFor(x => x.Name).NotEmpty();
		RuleFor(x => x.Manufacturer).NotEmpty();
		RuleFor(x => x.Model).NotEmpty();
		RuleFor(x => x.SerialNumber).NotEmpty();
		RuleFor(x => x.CurrentVolts).NotEmpty()
			.InclusiveBetween(120, 220)
			.WithMessage("Devices voltage below 120 and higher then 220 are not supported.");
		RuleFor(x => x.GasUsage).NotNull();
		RuleFor(x => x.Location).NotEmpty()
			.Must(BeSupported)
			.WithMessage($"Please choose one of the following locations: {string.Join(", ", _validLocations)}");
	}

	/// <summary>
	///  Метод кастомной валидации для свойства location
	/// </summary>
	private bool BeSupported(string location)
	{
		// Проверим, содержится ли значение в списке допустимых
		return _validLocations.Any(e => e == location);
	}
}
