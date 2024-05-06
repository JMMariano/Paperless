using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Paperless.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ColorTimerApplication
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var services = new ServiceCollection();
            services.AddDbContext<ColorTimerContext>(options =>
                options.UseSqlServer(builder.Build().GetConnectionString("DefaultConnection")));
            services.AddSingleton<MainWindow>();

            var serviceProvider = services.BuildServiceProvider();
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }

}
