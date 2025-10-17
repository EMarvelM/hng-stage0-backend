using System.Net.Http;
using System.Threading.Tasks;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/me", async () =>
{
    string Status = "failed";

    var meResponse = new MeResponseDto {
        Status = Status,
        User = new User {
            Email = "maviwurd@gmail.com",
            Name = "Egbe Marvelous Martins",
            Stack = "C# / ASP.NET Core"
        }
    };

    using HttpClient client = new HttpClient();
    string url = "https://catfact.ninja/fact";

    
    try
    {
        HttpResponseMessage response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode) {
            // JsonSerializer.Serialize(await response.Content.ReadFromJsonAsync<FactResponse>());
            var responseObj = await response.Content.ReadFromJsonAsync<FactResponse>();
            meResponse.Fact = responseObj.Fact;
            meResponse.Status = "success";
            return meResponse;
        }
    }
    catch (HttpRequestException e)
    {
        Console.WriteLine($"Request error: {e.Message}");
    }
    catch (Exception e)
    {
        Console.WriteLine($"An unexpected error occured: {e.Message}");
    }

    return meResponse;
})
.WithName("Me")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}


public class User
{
    public string Email { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Stack { get; set; } = string.Empty;
}

public class MeResponseDto
{
    public string Status { get; set; } = "failed";
    public User User { get; set; } = null; 
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
    public string Fact { get; set; } = string.Empty;
}

public class FactResponse {
    public string Fact { get; set; } = string.Empty;
    public int Id { get; set; }
    public int Status { get; set; }
    public bool IsCanceled { get; set; }
    public bool IsCompletedSuccessfully { get; set; }
    public bool CreationOptions { get; set; }
    public object? AsyncState { get; set; } = null;
    public bool IsFaulted { get; set; }
    public Exception? Exception { get; set; }
}