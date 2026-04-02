using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace OptimalWeight
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик нажатия кнопки расчёта
        /// </summary>
        /// <param name="sender">Источник события</param>
        /// <param name="e">Аргументы события</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var calculator = new WeightCalculator();

            bool isMale = RbMale.IsChecked == true;

            var result = calculator.Calculate(TxbHeight.Text, TxbWeight.Text, isMale);

            if (!result.success)
                MessageBox.Show(result.message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                TxbResult.Text = result.message;
        }
    }
}
