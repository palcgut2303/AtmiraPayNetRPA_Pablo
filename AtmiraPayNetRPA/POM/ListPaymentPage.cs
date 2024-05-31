using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmiraPayNetRPA.POM
{

    public class TableData
    {

        public int PaymentId { get; set; } 
        public string BancoOrigen { get; set; }
        public string BancoBeneficiario { get; set; }
        public string Cantidad { get; set; }
        public string Divisa { get; set; }
        public string Estado { get; set; }
        public IWebElement? DownloadButton { get; set; }

        public string UrlPDF { get; set; } 
    }

    public class ListPaymentPage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait wait;
        public ListPaymentPage(IWebDriver driver)
        {
            this._driver = driver;
            wait = new WebDriverWait(_driver, new TimeSpan(0, 0, 5));
        }

        IWebElement btnHomeListPayment => wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("viewPayment")));

        public void ClickHomebtn()
        {
            btnHomeListPayment.Click();
        }

        public List<TableData> GetTableDatas()
        {
            List<TableData> tableDatas = new List<TableData>();

            var rows = _driver.FindElements(By.XPath("//*[@id=\"app\"]/div/main/article/div/table/tbody/tr"));

            foreach (var row in rows)
            {
                var columns = row.FindElements(By.TagName("td"));
               
                if(columns.Count == 0)
                {
                    return null;
                }
                else
                {
                    if (columns[5].Text == "GENERADO")
                    {
                        var downloadButton = columns[6].FindElement(By.TagName("button"));
                        tableDatas.Add(new TableData
                        {
                            PaymentId = int.Parse(columns[0].Text),
                            BancoOrigen = columns[1].Text,
                            BancoBeneficiario = columns[2].Text,
                            Cantidad = columns[3].Text,
                            Divisa = columns[4].Text,
                            Estado = columns[5].Text,
                            DownloadButton = downloadButton
                        });
                    }
                    else
                    {
                        tableDatas.Add(new TableData
                        {
                            PaymentId = int.Parse(columns[0].Text),
                            BancoOrigen = columns[1].Text,
                            BancoBeneficiario = columns[2].Text,
                            Cantidad = columns[3].Text,
                            Divisa = columns[4].Text,
                            Estado = columns[5].Text
                        });
                    }
                }
                

                

                
            }

            return tableDatas;
        }

    }
}
