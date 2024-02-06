var builder = WebApplication.CreateBuilder(args);

// Lägg till tjänster till DI-containern.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Konfigurera HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
