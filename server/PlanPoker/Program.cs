using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace PlanPoker
{
    /// <summary>
    /// Запуск программы.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Основной метод запуска.
        /// </summary>
        /// <param name="args">Для консоли.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Создание хоста.
        /// </summary>
        /// <param name="args">Из консоли.</param>
        /// <returns>Хост с конфигурацией sturtup.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
