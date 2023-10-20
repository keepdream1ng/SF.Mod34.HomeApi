using SF.Mod34.HomeApi.Configuration;
using AutoMapper;
using System.Reflection;

namespace SF.Mod34.HomeApi;

public class Program
{
	/// <summary>
	/// Загрузка конфигурации из файла Json/ getting custom config from file.
	/// </summary>
	private static IConfiguration _configuration = new ConfigurationBuilder()
													  .AddJsonFile("HomeOptions.json")
													  .Build();

	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.Configure<HomeOptions>(_configuration);

		builder.Services.AddControllers();
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		var assembly = Assembly.GetAssembly(typeof(MappingProfile));
		builder.Services.AddAutoMapper(assembly);

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();


		app.MapControllers();

		app.Run();
	}
}