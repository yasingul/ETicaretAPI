using ETicaretAPI.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//IoC konteynýrýn olduðu yapý Services katmanýdýr.
builder.Services.AddPersistenceServices();      //Uygulamayý ayaða kaldýrdýðýmýzda IoC konteynýr artýk eriþilebilir olacak.
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
