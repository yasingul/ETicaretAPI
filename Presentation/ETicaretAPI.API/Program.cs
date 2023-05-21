using ETicaretAPI.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//IoC konteyn�r�n oldu�u yap� Services katman�d�r.
builder.Services.AddPersistenceServices();      //Uygulamay� aya�a kald�rd���m�zda IoC konteyn�r art�k eri�ilebilir olacak.

//Cors Politikalar� i�in gerekli servisi ekledik.
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
    policy.WithOrigins("http://localhost:4200/", "https://localhost:4200/").AllowAnyHeader().AllowAnyMethod()
));                     

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
