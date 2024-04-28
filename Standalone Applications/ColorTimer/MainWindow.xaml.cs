using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Paperless.Controllers;
using Paperless.Data;
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;

// TODO: Rename projects and namespaces to not have redundancy (e.g. too many things are named ColorTimer)
namespace ColorTimerApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IList<Paperless.Models.ColorTimer> ColorTimers { get; set; } = new List<Paperless.Models.ColorTimer>();
        public ColorTimerController _colorTimerController;

        public MainWindow(ColorTimerContext colorTimerContext)
        {
            InitializeComponent();
            _colorTimerController = new ColorTimerController(colorTimerContext);
        }

        private async void InitializeColorGrid()
        {
            var res = await _colorTimerController.GetAllColorTimers();

            if (res != null)
            {
                ColorTimers.ToList().AddRange(res.ToList());
                
                for (int i = 0; i < ColorTimers.Count; i++)
                {
                    var button = new ColorTimerButton(
                        ColorTimers[i].Color,
                        ColorTimers[i].ColorHexCode,
                        ColorTimers[i].TotalTimeElapsed,
                        _colorTimerController);

                    ColorTimerGrid.Children.Add(button);
                }
            }
        }

        private void AddColor_Click(object sender, RoutedEventArgs e)
        {
            var colorName = ColorNameTextBox.Text;
            var colorHexCode = ColorHexCodeTextBox.Text;

            _colorTimerController.CreateColor(colorName, colorHexCode);
            IList<Paperless.Models.ColorTimer> currentColorTimers = _colorTimerController.GetAllColors().ToList();
            var newColorTimersFromServer = currentColorTimers.Except(ColorTimers, comparer: new Paperless.Models.ColorTimer()).ToList();

            for (int i = 0; i < newColorTimersFromServer.Count; i++)
            {
                var button = new ColorTimerButton(
                    newColorTimersFromServer[i].Color,
                    newColorTimersFromServer[i].ColorHexCode,
                    newColorTimersFromServer[i].TotalTimeElapsed,
                    _colorTimerController);

                ColorTimerGrid.Children.Add(button);
            }
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}