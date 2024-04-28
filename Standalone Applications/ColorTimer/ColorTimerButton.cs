using Paperless.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace ColorTimerApplication
{
    class ColorTimerButton : Button
    {
        private DispatcherTimer Timer = new DispatcherTimer();
        ColorTimerController ColorTimerController;

        public string ColorName;
        public long TimeElapsed;


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

        private void ColorTimerButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (Timer.IsEnabled)
            {
                Timer.Stop();
                ColorTimerController.StopTimer(ColorName, TimeElapsed);
            }
            else
            {
                Timer.Start();
                ColorTimerController.StartTimer(ColorName);
            }
        }

        private void ColorTimerTick(object sender, EventArgs e)
        {
            TimeElapsed += 1;
            this.Content = TimeElapsed.ToString();
        }
    }
}
