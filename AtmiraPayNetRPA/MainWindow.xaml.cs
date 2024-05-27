using OpenQA.Selenium;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AtmiraPayNetRPA
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IWebDriver _webDriver;

        public MainWindow()
        {
            InitializeComponent();
        }



        private void TestData(object sender, RoutedEventArgs e)
        {
            try
            {
                //TXT DEL LOGIN
                string emailLogin = txtEmailLogin.Text;
                string passwordLogin = txtPasswordLogin.Text;


                //TXT DEL PAGO
                string IBANBankOrigin = txtIBANOrigin.Text;
                string bankNameOrigin = txtBankNameOrigin.Text;
                string countryOrigin = txtCountryOrigin.Text;

                string IBANBankDestination = txtIBANDestination.Text;
                string bankNameDestination = txtBankNameDestination.Text;
                string countryDestination = txtCountryDestination.Text;



                string? IBANBankInter = txtIBANInter.Text;
                string bankNameInter = txtBankNameInter.Text;

                string CP = txtCp.Text;
                string Street = txtStreet.Text;
                string NumberStreet = txtNumberStreet.Text;
                string PayAmount = txtPayAmount.Text;


                _webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
                _webDriver.Navigate().GoToUrl("http://localhost:5058/");

                _webDriver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(5);

                _webDriver.Manage().Window.Maximize();

                //LOGIN
                LoginPage loginPage = new LoginPage(_webDriver);
                loginPage.ClickLogin();
                loginPage.Login(emailLogin, passwordLogin);



                ListPaymentPage listPaymentPage = new ListPaymentPage(_webDriver);
                listPaymentPage.ClickHomebtn();

                CreatePaymentPage createPaymentPage = new CreatePaymentPage(_webDriver);
                createPaymentPage.ClickCreatePayment();




                createPaymentPage.CreatePayment(IBANBankOrigin, bankNameOrigin, countryOrigin, CP, Street, NumberStreet, PayAmount, IBANBankDestination, bankNameDestination, countryDestination, IBANBankInter, bankNameInter);

                ComboBoxItem selectedItem = comboBoxTypeOperation.SelectedItem as ComboBoxItem;

                string tipoOperacion = selectedItem!.Content.ToString()!;

                if (tipoOperacion == "GENERAR")
                {
                    createPaymentPage.ClickGenerar();
                }
                else
                {
                    createPaymentPage.ClickBorrador();
                }
            }
            catch (NoSuchElementException ex)
            {
                // Manejar la excepción si no se encuentra el elemento
                ShowError("Error: El elemento no se encontró. ", ex);
            }
            catch (ElementClickInterceptedException ex)
            {
                // Manejar la excepción si el elemento no es clickeable
                ShowError("Error: El elemento no es clickeable. " ,ex);
            }
            catch (Exception ex)
            {
                ShowError("Error: Ocurrió un error inesperado. ", ex);
            }




        }

        private void ShowError(string message, Exception ex)
        {
            // Mostrar el mensaje de error en un MessageBox
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);


            // Mostrar el mensaje de error en el TextBlock
            ErrorTextBlock.Text = $"{message}\n{ex.Message}";

            ErrorLabel.Visibility = Visibility.Visible;
            ErrorTextBlock.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFolderDialog dialog = new();

            dialog.Multiselect = false;
            dialog.Title = "Select a folder";

            // Show open folder dialog box
            bool? result = dialog.ShowDialog();

            // Process open folder dialog box results
            if (result == true)
            {
                // Get the selected folder
                string fullPathToFolder = dialog.FolderName;
                string folderNameOnly = dialog.SafeFolderName;

                txtPathFolder.Text = fullPathToFolder;
            }
        }
    }
}