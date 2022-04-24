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

namespace WPFcircuito
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int r1, r2, r3, r4, rx, ry, Ve;
        double Vab, i1, i2, determinante;

        public MainWindow()
        {
            InitializeComponent();
            r1 = 1;
            r2 = 1;
            r3 = 2;
            r4 = 3;
            Ve = 5;
        }

        private void signature_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("WFcruzlara_signature.exe");
        }

        private void calculate_Click(object sender, RoutedEventArgs e)
        {
            result.Content = "El valor del voltaje es: " + calcularVoltaje() + " V";
        }
        private double calcularVoltaje()
        {
            // Calculo de resistencias equivalentes
            rx = r1 + r3;
            ry = r2 + r3 + r4;

            // Calculo del determinante
            determinante = (rx - ry) - Math.Pow(r3, 2);

            // Calculo de las corrientes
            i1 = (Ve * ry) / determinante;
            i2 = (r3 * Ve) / determinante;

            // Calculo del voltaje
            Vab = r4 * i2;

            return Vab;
        }
    }
}
