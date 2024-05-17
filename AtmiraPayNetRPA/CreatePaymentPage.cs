using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AtmiraPayNetRPA
{
    public class CreatePaymentPage
    {
        private readonly IWebDriver driver;

        public CreatePaymentPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        IWebElement btnCreatePayment => driver.FindElement(By.Id("createPayment"));
        IWebElement OriginAccountIBAN => driver.FindElement(By.Id("OriginAccountIBAN"));
        IWebElement OriginBankName => driver.FindElement(By.Id("OriginBankName"));
        IWebElement OriginCountryBank => driver.FindElement(By.Id("OriginCountryBank"));
        IWebElement CP => driver.FindElement(By.Id("CP"));
        IWebElement Street => driver.FindElement(By.Id("Street"));
        IWebElement NumberStreet => driver.FindElement(By.Id("NumberStreet"));
        IWebElement PayAmount => driver.FindElement(By.Id("PayAmount"));
        IWebElement DestinationAccountIBAN => driver.FindElement(By.Id("DestinationAccountIBAN"));
        IWebElement DestinationBankName => driver.FindElement(By.Id("DestinationBankName"));
        IWebElement DestinationCountryBank => driver.FindElement(By.Id("DestinationCountryBank"));
        IWebElement InterBankAccountIBAN => driver.FindElement(By.Id("InterBankAccountIBAN"));
        IWebElement InterBankName => driver.FindElement(By.Id("InterBankName"));
        IWebElement BtnGenerar => driver.FindElement(By.Id("btnGenerar"));

        IWebElement BtnBorrador => driver.FindElement(By.Id("btnBorrador"));

        public void ClickCreatePayment()
        {
            btnCreatePayment.Click();
        }

        public void CreatePayment(string OriginAccountIBAN, string OriginBankName, string OriginCountryBank, string CP, string Street, string NumberStreet, string PayAmount, string DestinationAccountIBAN, string DestinationBankName, string DestinationCountryBank, string InterBankAccountIBAN, string InterBankName)
        {
            this.OriginAccountIBAN.SendKeys(OriginAccountIBAN);
            this.OriginBankName.SendKeys(OriginBankName);
            this.OriginCountryBank.SendKeys(OriginCountryBank);
            this.CP.SendKeys(CP);
            this.Street.SendKeys(Street);
            this.NumberStreet.SendKeys(NumberStreet);
            this.PayAmount.SendKeys(PayAmount);
            this.DestinationAccountIBAN.SendKeys(DestinationAccountIBAN);
            this.DestinationBankName.SendKeys(DestinationBankName);
            this.DestinationCountryBank.SendKeys(DestinationCountryBank);

            if(InterBankAccountIBAN != null && InterBankName != null)
            {
                this.InterBankAccountIBAN.SendKeys(InterBankAccountIBAN);
                this.InterBankName.SendKeys(InterBankName);
            }
            
        }

        public void ClickGenerar()
        {
            BtnGenerar.Click();
        }

        public void ClickBorrador()
        {
            BtnBorrador.Click();
        }
    }
}
