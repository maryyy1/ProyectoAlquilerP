using 


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
if (app.Environment.IsDevelopment()) { 
   // app.useSwa
}
app.UseHttpsRedirection();
app.UseAuthentication();
app.MapControllers();
app.MapGet("/", () => "Hello Puerco!");

app.Run();
