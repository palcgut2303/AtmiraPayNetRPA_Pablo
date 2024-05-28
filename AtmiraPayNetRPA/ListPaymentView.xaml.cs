using AtmiraPayNetRPA.POM;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
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

namespace AtmiraPayNetRPA
{
    /// <summary>
    /// Lógica de interacción para ListPaymentView.xaml
    /// </summary>
    public partial class ListPaymentView : Window
    {
        IWebDriver _drive;
       
        ListPaymentPage ListPayment;

        public ICommand ButtonCommand { get; set; }



        public ListPaymentView(IWebDriver driver)
        {
            InitializeComponent();

            _drive = driver;

            ListPayment = new ListPaymentPage(_drive);

            List<TableData> tableData = ListPayment.GetTableDatas();

            dataGrid.ItemsSource = tableData;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //// Obtener el botón que fue clicado
            //Button button = sender as Button;

            //if (button != null)
            //{
            //    // Obtener el contexto de datos del botón
            //    var dataContext = button.DataContext;

            //    // Verificar el tipo de datos (asumimos que es una instancia de tu clase de datos)
            //    if (dataContext is TableData data)
            //    {
            //        // Aquí puedes acceder a los datos del registro correspondiente
            //        string bancoOrigen = data.BancoOrigen;
            //        string bancoBeneficiario = data.BancoBeneficiario;
            //        string cantidad = data.Cantidad;
            //        string divisa = data.Divisa;
            //        string estado = data.Estado;

            //        // Lógica para generar y descargar el PDF usando los datos del registro
            //        DownloadPdf(bancoOrigen, bancoBeneficiario, cantidad, divisa, estado);
            //    }
            //}
        }

        //// Método para manejar la generación y descarga del PDF
        //private void DownloadPdf(string bancoOrigen, string bancoBeneficiario, string cantidad, string divisa, string estado)
        //{
        //    // Tu lógica para generar y descargar el PDF
        //}
    }
}
