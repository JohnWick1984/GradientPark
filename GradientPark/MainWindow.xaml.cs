using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GradientPark.Properties;

namespace GradientPark
{
    public partial class MainWindow : Window
    {
        private string currentCulture = "ru";

        public MainWindow()
        {
            InitializeComponent();
            UpdateUI();
        }
        private void RuButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateLocalization("ru");
            UpdateUI();
        }
        private void FrenchButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateLocalization("fr");
            UpdateUI();
        }

        private void SpanishButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateLocalization("sp");
            UpdateUI();
        }

        private void IndButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateLocalization("id");
            UpdateUI();
        }

        private void UpdateLocalization(string culture)
        {
            currentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(currentCulture);
        }

        private Color[] GetColorsForCulture(string culture)
        {
            switch (culture)
            {
                case "ru":
                    return new Color[] { Colors.White, Colors.Blue, Colors.Red };
                case "fr":
                    return new Color[] { Colors.Blue, Colors.White, Colors.Red };
                case "sp":
                    return new Color[] { Colors.Red, Colors.Yellow, Colors.Red };
                case "id":
                    return new Color[] { Colors.White, Colors.Red };
                default:
                    return new Color[] { Colors.Transparent };
            }
        }

        private void UpdateUI()
        {
            MainButton.Content = Strings.Main;
            ServicesButton.Content = Strings.Services;
            ExcursionButton.Content = Strings.Excursions;
            HistoryButton.Content = Strings.History;
            NewsButton.Content = Strings.News;
            ContactsButton.Content = Strings.Contacts;
           

            SetButtonBackground(MainButton);
            SetButtonBackground(ServicesButton);
            SetButtonBackground(ExcursionButton);
            SetButtonBackground(HistoryButton);
            SetButtonBackground(NewsButton);
            SetButtonBackground(ContactsButton);
        }

        private void SetButtonBackground(Button button)
        {
            Color[] colors = GetColorsForCulture(currentCulture);

            LinearGradientBrush gradientBrush = new LinearGradientBrush();

            for (int i = 0; i < colors.Length; i++)
            {
                gradientBrush.GradientStops.Add(new GradientStop(colors[i], i * 1.0 / (colors.Length - 1)));
            }

            if (currentCulture == "fr" || currentCulture == "ru")
            {
                gradientBrush.StartPoint = new Point(0, 0);
                gradientBrush.EndPoint = new Point(0, 1);
            }
            else
            {
                gradientBrush.StartPoint = new Point(0, 0);
                gradientBrush.EndPoint = new Point(1, 0);
            }

            button.Background = gradientBrush;
        }
    }
}