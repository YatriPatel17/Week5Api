namespace Week5Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddAuthorization();
        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddOpenApi();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI(c => 
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Week5Api V1");
            c.RoutePrefix = "swagger"; 
        });
        

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.MapGet("/hello", () => "Your API has been updated through CI and CD");

        app.Run();
    }
}
