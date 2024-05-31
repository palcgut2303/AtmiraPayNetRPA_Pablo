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

            if(tableData.Count() != 0)
            {
                dataGrid.ItemsSource = tableData;
            }
            else {
                tableData = new List<TableData>
                {
                    new TableData { PaymentId = 0, DownloadButton = null, UrlPDF = "", BancoOrigen = "No hay registros", BancoBeneficiario = "No hay registros", Cantidad = "0",Divisa = "No hay registro",Estado = "No hay registros"  }
                };
                dataGrid.ItemsSource = tableData;
            }
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Obtener el botón que fue clicado
            Button button = sender as Button;

            if (button != null)
            {
                var dataContext = button.DataContext;


                if (dataContext is TableData data)
                {
                    var idCheck = data.PaymentId;

                    if (idCheck != 0)
                    {
                        var WebElement = data.DownloadButton;
                        var id = data.PaymentId;

                        WebElement.Click();

                        System.Threading.Thread.Sleep(5000);

                        string downloadPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads";
                        string fileName = "CartaDePago_" + data.PaymentId + ".pdf";

                        string filePath = Path.Combine(downloadPath, fileName);


                        if (File.Exists(filePath))
                        {
                            MessageBox.Show($"PDF descargado en: {filePath}", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);

                            try
                            {

                                data.UrlPDF = filePath;

                                dataGrid.Items.Refresh();

                                Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"No se pudo abrir el archivo PDF: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el archivo descargado.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    

                }
            }
        }

    }
}
