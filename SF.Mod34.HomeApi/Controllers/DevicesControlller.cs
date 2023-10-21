using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SF.Mod34.HomeApi.Configuration;
using SF.Mod34.HomeApi.Contracts;

namespace SF.Mod34.HomeApi.Controllers;

/// <summary>
/// Контроллер статусов устройств
/// </summary>
[ApiController]
[Route("[controller]")]
public class DevicesController : ControllerBase
{
	private IOptions<HomeOptions> _options;
	private IMapper _mapper;

	public DevicesController(IOptions<HomeOptions> options, IMapper mapper)
	{
		_options = options;
		_mapper = mapper;
	}

	/// <summary>
	/// Просмотр списка подключенных устройств
	/// </summary>
	[HttpGet]
	[Route("")]
	public IActionResult Get()
	{
		return StatusCode(200, "Устройства отсутствуют");
	}

	/// <summary>
	/// Добавление нового устройства
	/// </summary>
	[HttpPost]
	[Route("Add")]
	public IActionResult Add(
		[FromBody] // Атрибут, указывающий, откуда брать значение объекта
		AddDeviceRequest request // Объект запроса
	){
		if (request.CurrentVolts < 120)
		{
			ModelState.AddModelError("currentVolts", "Devices with voltage less then 120V are not supported");
			return BadRequest(ModelState);
		}
		return StatusCode(200, $"Устройство {request.Name} добавлено!");
	}
}
