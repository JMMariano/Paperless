using Paperless.Models;
using Paperless.Controllers;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ColorTimer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Repository repository = new Repository();
            ColorTimerController controller = new ColorTimerController(repository);
            MainWindow window = new MainWindow(controller);
            window.ColorTimers = repository.ColorTimers.ToList();
            window.GenerateColorGrid();
            window.Show();
        }
    }

}
