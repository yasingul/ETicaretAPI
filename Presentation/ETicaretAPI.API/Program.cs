using ETicaretAPI.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//IoC konteyn�r�n oldu�u yap� Services katman�d�r.
builder.Services.AddPersistenceServices();      //Uygulamay� aya�a kald�rd���m�zda IoC konteyn�r art�k eri�ilebilir olacak.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
