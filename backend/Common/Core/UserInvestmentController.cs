using backend.Common.Data;
using backend.Common.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
namespace backend.core;

public class UserInvestmentController
{


    public async Task<List<Strategy>> Stratagies()
    {

        List<Strategy> strategies;

        try
        {
            string jsonData = File.ReadAllText("./strategies.json");
            strategies = JsonConvert.DeserializeObject<List<Strategy>>(jsonData); // Or JsonSerializer.Deserialize for .NET Core 3.1+
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deserializing JSON: {ex.Message}");
            strategies = null; // Handle the error as needed, potentially exiting the program
        }
        return strategies;
    }
}
