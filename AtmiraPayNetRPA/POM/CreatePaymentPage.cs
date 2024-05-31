using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace AtmiraPayNetRPA.POM
{
    public class CreatePaymentPage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait wait;
        private Actions actions;
        public CreatePaymentPage(IWebDriver driver)
        {
            _driver = driver;

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 5));
            actions = new Actions(_driver);
        }



        IWebElement btnCreatePayment => _driver.FindElement(By.Id("createPayment"));
        IWebElement OriginAccountIBAN => _driver.FindElement(By.Id("OriginAccountIBAN"));
        IWebElement OriginBankName => _driver.FindElement(By.Id("OriginBankName"));

        IWebElement OriginCountryBank => _driver.FindElement(By.Id("OriginCountryBank"));
        IWebElement CP => _driver.FindElement(By.Id("CP"));
        IWebElement Street => _driver.FindElement(By.Id("Street"));
        IWebElement NumberStreet => _driver.FindElement(By.Id("NumberStreet"));
        IWebElement PayAmount => _driver.FindElement(By.Id("PayAmount"));
        IWebElement DestinationAccountIBAN => _driver.FindElement(By.Id("DestinationAccountIBAN"));
        IWebElement DestinationBankName => _driver.FindElement(By.Id("DestinationBankName"));
        IWebElement DestinationCountryBank => _driver.FindElement(By.Id("DestinationCountryBank"));
        IWebElement InterBankAccountIBAN => _driver.FindElement(By.Id("cuentaIntermediaria"));
        IWebElement InterBankName => _driver.FindElement(By.Id("nombreBancoIntermediario"));
        IWebElement BtnGenerar => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//*[@id=\"btnGenerar\"]")));

        IWebElement BtnBorrador => _driver.FindElement(By.Id("btnBorrador"));

        IWebElement BtnYesDialog => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[3]/div/div[6]/button[1]")));
        IWebElement BtnOkDialog => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[3]/div/div[6]/button[1]")));

        public void ClickCreatePayment()
        {
            btnCreatePayment.Click();
        }


        public void CreatePayment(string OriginAccountIBAN, string OriginBankName, string OriginCountryBank, string CP, string Street, string NumberStreet, string PayAmount, string DestinationAccountIBAN, string DestinationBankName, string DestinationCountryBank, string InterBankAccountIBAN, string InterBankName)
        {
            this.OriginAccountIBAN.SendKeys(OriginAccountIBAN);
            this.OriginBankName.SendKeys(OriginBankName);

            var selectElement = new SelectElement(this.OriginCountryBank);
            selectElement.SelectByText(OriginCountryBank);

            this.OriginCountryBank.SendKeys(OriginCountryBank);
            this.CP.SendKeys(CP);
            this.Street.SendKeys(Street);
            this.NumberStreet.SendKeys(NumberStreet);
            this.PayAmount.SendKeys(PayAmount);
            this.DestinationAccountIBAN.SendKeys(DestinationAccountIBAN);
            this.DestinationBankName.SendKeys(DestinationBankName);
            this.DestinationCountryBank.SendKeys(DestinationCountryBank);



            var selectElement2 = new SelectElement(this.DestinationCountryBank);
            selectElement2.SelectByText(DestinationCountryBank);

            if (InterBankAccountIBAN != "" && InterBankName != "")
            {

                this.InterBankAccountIBAN.SendKeys(InterBankAccountIBAN);
                this.InterBankName.SendKeys(InterBankName);
            }

        }

        public void ClickGenerar()
        {

            actions.MoveToElement(BtnGenerar).Click().Perform();
            BtnYesDialog.Click();

            try
            {
                IWebElement IconSuccess = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[3]/div/div[1]/div[2]")));
                BtnOkDialog.Click();

            }
            catch (Exception e)
            {
                throw new Exception("Error al generar el pago");

            }



        }

        public void ClickBorrador()
        {

            actions.MoveToElement(BtnBorrador).Click().Perform();
            BtnYesDialog.Click();
            try
            {
                IWebElement IconSuccess = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("/html/body/div[3]/div/div[1]/div[2]")));
                BtnOkDialog.Click();

            }
            catch (Exception e)
            {
                throw new Exception("Error al generar el pago");

            }

        }


    }
}
