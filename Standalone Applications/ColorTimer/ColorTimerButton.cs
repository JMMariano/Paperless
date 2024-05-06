using Paperless.Controllers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace ColorTimerApplication
{
    class ColorTimerButton : Button
    {
        #region Fields

        private const int GUEST_ID = 1;

        private DispatcherTimer Timer = new DispatcherTimer();
        ColorTimerController ColorTimerController;

        public string ColorName;
        public long TimeElapsed;

        #endregion

        #region Constructors

        public ColorTimerButton(string colorName, string hexCode, long timeElapsed, ColorTimerController controller)
        {
            ColorName = colorName;
            TimeElapsed = timeElapsed;
            ColorTimerController = controller;

            Timer.Tick += ColorTimerTick;
            Timer.Interval = TimeSpan.FromSeconds(1);
            Click += ColorTimerButton_OnClick;

            var color = (Color)ColorConverter.ConvertFromString(hexCode);
            var brush = new SolidColorBrush(color);
            this.Background = brush;
            this.Content = TimeElapsed.ToString();
        }

        #endregion

        #region Methods

        private async void ColorTimerButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Timer.IsEnabled)
            {
                Timer.Stop();
                await ColorTimerController.StopTimer(ColorName, GUEST_ID);
            }
            else
            {
                // Find all color timers from the parent and stop running timers on the client side
                if (sender is ColorTimerButton clickedButton)
                {
                    Window window = Window.GetWindow(clickedButton);

                    if (window != null)
                    {
                        IEnumerable<ColorTimerButton> currentButtons = FindVisualChildren<ColorTimerButton>(window)
                            .Where(i => i.Timer.IsEnabled);

                        foreach (var button in currentButtons)
                        {
                            if (button.Timer.IsEnabled)
                            {
                                button.Timer.IsEnabled = false;
                            }
                        }
                    }
                }

                Timer.Start();
                await ColorTimerController.StartTimer(ColorName, GUEST_ID);
            }
        }

        private void ColorTimerTick(object sender, EventArgs e)
        {
            TimeElapsed += 1;
            this.Content = TimeElapsed.ToString();
        }

        // Helper method to find all visual children of a specific type in the visual tree
        private IEnumerable<T> FindVisualChildren<T>(DependencyObject parent) where T : DependencyObject
        {
            if (parent != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(parent, i);

                    if (child is T typedChild)
                    {
                        yield return typedChild;
                    }

                    foreach (T foundChild in FindVisualChildren<T>(child))
                    {
                        yield return foundChild;
                    }
                }
            }
        }

        #endregion
    }
}