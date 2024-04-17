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
            strategies = JsonConvert.DeserializeObject<List<Strategy>>(jsonData);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deserializing JSON: {ex.Message}");
            strategies = null;
        }
        return strategies;
    }

    public async Task<Strategy> GetStrategy(string strategyName)
    {

        List<Strategy> strategies;

        try
        {

            strategies = await Stratagies();
            var strategy = strategies.FirstOrDefault(x=>x.Name == strategyName);
            return strategy;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deserializing JSON: {ex.Message}");
        }
        return null;
    }
}
