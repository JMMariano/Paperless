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
using Color = System.Windows.Media.Color;
using ColorConverter = System.Windows.Media.ColorConverter;

// TODO: Rename projects and namespaces to not have redundancy (e.g. too many things are named ColorTimer)
namespace ColorTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IList<Paperless.Models.ColorTimer> ColorTimers { get; set; }
        public ColorTimerController colorTimerController;

        public MainWindow(ColorTimerController controller)
        {
            InitializeComponent();
            colorTimerController = controller;
        }

        public void GenerateColorGrid()
        {
            ColorGrid.Children.Clear();

            for (int i = 0; i < ColorTimers.Count; i++)
            {
                var button = new ColorTimerButton(
                    ColorTimers[i].Color,
                    ColorTimers[i].ColorHexCode,
                    ColorTimers[i].TotalTimeElapsed,
                    colorTimerController);

                ColorGrid.Children.Add(button);
            }
        }

        private void AddColor_Click(object sender, RoutedEventArgs e)
        {
            var colorName = ColorNameTextBox.Text;
            var colorHexCode = ColorHexCodeTextBox.Text;

            colorTimerController.CreateColor(colorName, colorHexCode);
            IList<Paperless.Models.ColorTimer> currentColorTimers = colorTimerController.GetAllColors().ToList();
            var newColorTimersFromServer = currentColorTimers.Except(ColorTimers, comparer: new Paperless.Models.ColorTimer()).ToList();

            for (int i = 0; i < newColorTimersFromServer.Count; i++)
            {
                var button = new ColorTimerButton(
                    newColorTimersFromServer[i].Color,
                    newColorTimersFromServer[i].ColorHexCode,
                    newColorTimersFromServer[i].TotalTimeElapsed,
                    colorTimerController);

                ColorGrid.Children.Add(button);
            }
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            colorTimerController.UpdateFile();
            Application.Current.Shutdown();
        }

        private void ColorTimer_Closing(object sender, CancelEventArgs e)
        {
            colorTimerController.UpdateFile();
        }
    }
}