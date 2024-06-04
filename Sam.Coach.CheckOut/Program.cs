using Microsoft.Extensions.DependencyInjection;

namespace Sam.Coach.CheckOut;

public class Program
{
    /// <summary>
    /// This part I've done for myself
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public static async Task Main(string[] args)
    {
        var services = new ServiceCollection();

        ConfigureServices(services);

        var serviceProvider = services.BuildServiceProvider();

        var finder = serviceProvider.GetRequiredService<ILongestRisingSequenceFinder>();

        //check out
        var first = new[] { 4, 6, -3, 3, 7, 9, 10 };
        var second = new[] { 9, 6, 4, 5, 2, 0, 1, 2, 3, 0 };

        var result = await finder.Find(first, second);

        if (result != null)
        {
            Console.WriteLine("The array with the longest rising sequence is:");
            foreach (var item in result)
            {
                Console.Write(item + " ");
            }
        }
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<ILongestRisingSequenceFinder, LongestRisingSequenceFinder>();
    }
}
