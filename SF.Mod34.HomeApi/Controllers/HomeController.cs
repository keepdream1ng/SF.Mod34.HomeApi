﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SF.Mod34.HomeApi.Configuration;
using SF.Mod34.HomeApi.Contracts;
using System.Text;

namespace SF.Mod34.HomeApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
   private IOptions<HomeOptions> _options;
   private IMapper _mapper;
  
   // Инициализация конфигурации при вызове конструктора
   public HomeController(IOptions<HomeOptions> options, IMapper mapper)
   {
       _options = options;
       _mapper = mapper;
   }
 
   /// <summary>
   /// Метод для получения информации о доме
   /// </summary>
   [HttpGet] // Для обслуживания Get-запросов
   [Route("info")] // Настройка маршрута с помощью атрибутов
   public IActionResult Info()
   {
       // Получим запрос, "смапив" конфигурацию на модель запроса
       var infoResponse = _mapper.Map<HomeOptions, InfoResponse>(_options.Value);
       // Вернём ответ
       return StatusCode(200, infoResponse);
   }
}

