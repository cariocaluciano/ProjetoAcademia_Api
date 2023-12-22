using ProjetoAcademia_Api.Classes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<CrudAcademia>();
builder.Services.AddScoped<CrudAlunos>();
builder.Services.AddScoped<VerificaLoginAcademia>();
builder.Services.AddScoped<EnviaEmailVerificacao>();

builder.Services.AddCors(Opts =>
{
	Opts.AddPolicy("AllowSpecificOrigin",
				builder =>
				{
					builder.WithOrigins("http://127.0.0.1:5500")
					  .AllowAnyHeader()
					  .AllowAnyMethod();
				});
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
