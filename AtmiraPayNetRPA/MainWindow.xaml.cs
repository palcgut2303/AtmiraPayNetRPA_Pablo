using OpenQA.Selenium;
using System.Net;
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
            // _webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            //_webDriver.Url = "http://localhost:5058/#";
        }

        

        private void TestCreatePaymentLetter(object sender, RoutedEventArgs e)
        {
            //recoger datos
            



        }

        private void TestLoginRegister(object sender, RoutedEventArgs e)
        {
            //REGISTER
            //string username = txtUsername.Text;
            //string emailRegister = txtEmailRegister.Text;
            //string passwordRegister = txtPasswordRegister.Text;
            //string fullName = txtFullname.Text;
            //DateTime birthdate = calendarBirthdate.SelectedDate.Value;

            //LOGIN
            string emailLogin = txtEmailLogin.Text;
            string passwordLogin = txtPasswordLogin.Text;


            _webDriver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _webDriver.Navigate().GoToUrl("http://localhost:5058/");
            _webDriver.Manage().Window.Maximize();

            Thread.Sleep(6000);



            //webElement = _webDriver.FindElement(By.Id("username"));
            //webElement.SendKeys(username);

            //webElement = _webDriver.FindElement(By.Id("fullname"));
            //webElement.SendKeys(fullName);

            //webElement = _webDriver.FindElement(By.Id("emailRegister"));
            //webElement.SendKeys(emailRegister);

            //webElement = _webDriver.FindElement(By.Id("passwordRegister"));
            //webElement.SendKeys(passwordRegister);

            //webElement = _webDriver.FindElement(By.Id("birthdate"));
            //webElement.SendKeys(birthdate.ToString("dd-MM-yyyy"));

            //webElement = _webDriver.FindElement(By.Id("btnRegister"));
            //webElement.Click();

            //LOGIN
            LoginPage loginPage = new LoginPage(_webDriver);
            loginPage.ClickLogin();
            loginPage.Login(emailLogin, passwordLogin);
            
            Thread.Sleep(6000);

            ListPaymentPage listPaymentPage = new ListPaymentPage(_webDriver);
            listPaymentPage.ClickHomebtn();

            CreatePaymentPage createPaymentPage = new CreatePaymentPage(_webDriver);
            createPaymentPage.ClickCreatePayment();

            createPaymentPage.CreatePayment("ES6621000418401234567891", "Santander", "Spain", "28001", "Calle Serrano", "1", "100", "ES6621000418401234567891", "Santander", "Spain", "ES6621000418401234567891", "Santander");
            createPaymentPage.ClickGenerar();

        }
    }
}