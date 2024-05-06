using System.ComponentModel;
using System.Windows;
using Paperless.Controllers;
using Paperless.Data;

namespace ColorTimerApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields

        private const int GUEST_ID = 1;

        public IList<Paperless.Models.ColorTimer> ColorTimers { get; set; } = new List<Paperless.Models.ColorTimer>();
        public ColorTimerController _colorTimerController;

        #endregion

        #region Constructors

        public MainWindow(ColorTimerContext colorTimerContext)
        {
            _colorTimerController = new ColorTimerController(colorTimerContext);
            InitializeComponent();
            InitializeColorGrid();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the initial color grid by fetching the current color timers. Uses the reserved id "GUEST_ID".
        /// </summary>
        private async void InitializeColorGrid()
        {
            var res = await _colorTimerController.GetColorTimersByUserId(GUEST_ID);

            if (res != null && res.Count > 0)
            {
                ColorTimers = ColorTimers.Concat(res).ToList();
                
                for (int i = 0; i < ColorTimers.Count; i++)
                {
                    var button = new ColorTimerButton(
                        (ColorTimers[i].Name ?? string.Empty),
                        (ColorTimers[i].ColorHexCode ?? string.Empty),
                        ColorTimers[i].TotalTimeElapsed,
                        _colorTimerController);

                    ColorTimerGrid.Children.Add(button);
                }
            }
        }

        private async void AddColor_Click(object sender, RoutedEventArgs e)
        {
            var colorName = ColorNameTextBox.Text;
            var colorHexCode = ColorHexCodeTextBox.Text;

            var res = await _colorTimerController.CreateColor(colorName, GUEST_ID, colorHexCode);

            // If color does not exist yet from server, get the current pool of colors
            if (res)
            {
                var currentColorTimers = await _colorTimerController.GetColorTimersByUserId(GUEST_ID);

                if (currentColorTimers != null)
                {
                    var newColorTimersFromServer = currentColorTimers.Except(ColorTimers, comparer: new Paperless.Models.ColorTimer()).ToList();

                    for (int i = 0; i < newColorTimersFromServer.Count; i++)
                    {
                        var button = new ColorTimerButton(
                            (newColorTimersFromServer[i].Name ?? string.Empty),
                            (newColorTimersFromServer[i].ColorHexCode ?? string.Empty),
                            newColorTimersFromServer[i].TotalTimeElapsed,
                            _colorTimerController);

                        ColorTimerGrid.Children.Add(button);
                    }

                    ColorTimers = ColorTimers.Concat(newColorTimersFromServer).ToList();
                }
            }
        }

        private async void Quit_Click(object sender, RoutedEventArgs e)
        {
            await _colorTimerController.StopRunningTimersByUserId(GUEST_ID);
            Application.Current.Shutdown();
        }

        private async void Window_Closing(object sender, CancelEventArgs e)
        {
            await _colorTimerController.StopRunningTimersByUserId(GUEST_ID);
            Application.Current.Shutdown();
        }

        #endregion
    }
}