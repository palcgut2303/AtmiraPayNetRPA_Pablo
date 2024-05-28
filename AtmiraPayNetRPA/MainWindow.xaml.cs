using AtmiraPayNetRPA.POM;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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
        private WebDriverWait wait;
        public MainWindow()
        {
            InitializeComponent();
            
        }

        IWebElement errorOcurred => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"app\"]/div/main/article/form/div[1]/p")));
        IWebElement errorOcurredSweetAlert => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"swal2-html-container\"]")));




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

                wait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 5));

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
                    ShowSuccess(errorOcurredSweetAlert.Text);
                }
                else
                {
                    createPaymentPage.ClickBorrador();
                    ShowSuccess(errorOcurredSweetAlert.Text);
                }
            }
            catch (Exception ex)
            {
                try
                {
                    ShowError(errorOcurred.Text, ex);
                }
                catch (Exception ex2)
                {
                    ShowError(errorOcurredSweetAlert.Text, ex);
                }
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

        private void ShowSuccess(string message)
        {
            // Mostrar el mensaje de error en un MessageBox
            MessageBox.Show(message, "Information", MessageBoxButton.OK, MessageBoxImage.Information);


            // Mostrar el mensaje de error en el TextBlock
            SuccessTextBlock.Text = $"{message}\n";

            SuccesLabel.Visibility = Visibility.Visible;
            SuccessTextBlock.Visibility = Visibility.Visible;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //TXT DEL LOGIN
            string emailLogin = txtEmailLogin.Text;
            string passwordLogin = txtPasswordLogin.Text;

            _webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _webDriver.Navigate().GoToUrl("http://localhost:5058/");

            _webDriver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(5);

            _webDriver.Manage().Window.Maximize();

            wait = new WebDriverWait(_webDriver, new TimeSpan(0, 0, 5));

            //LOGIN
            LoginPage loginPage = new LoginPage(_webDriver);
            loginPage.ClickLogin();
            loginPage.Login(emailLogin, passwordLogin);

            ListPaymentPage listPaymentPage = new ListPaymentPage(_webDriver);
            listPaymentPage.ClickHomebtn();

            ListPaymentView listPaymentPage2 = new(_webDriver);
            listPaymentPage2.Show();
            Close();

        }
    }
}