using System;
using System.Windows;

namespace FuelCalculatorApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CalculateButton.Click += CalculateButton_Click; 
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
             
                if (string.IsNullOrWhiteSpace(LitersTextBox.Text))
                {
                    MessageBox.Show("Введите количество топлива!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                double liters = double.Parse(LitersTextBox.Text);
                double distance = GetSelectedDistance();

                if (liters <= 0)
                {
                    MessageBox.Show("Количество топлива должно быть больше 0!", "Ошибка",
                                MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                double consumption = liters / distance;
                ResultTextBox.Text = consumption.ToString("F2");
            }
            catch (FormatException)
            {
                MessageBox.Show("Пожалуйста, введите корректное числовое значение!", "Ошибка",
                            MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка",
                            MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private double GetSelectedDistance()
        {
            if (Radio1Km.IsChecked == true) return 1;
            if (Radio5Km.IsChecked == true) return 5;
            return 20; 
        }
    }
}
