using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PruebaTecnica
{
    [TestClass]
    public class CasoPrueba_003
    {
        [TestMethod]
        public void TestMethod1()
        {
            string chromeDriver = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\..\\driver\\");
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            var driver = new ChromeDriver(chromeDriver, options);

            try
            {
                //Ingresando el sitio
                driver.Navigate().GoToUrl("https://demoqa.com/");
                Thread.Sleep(2000);
                IWebElement? Card = driver.FindElements(By.CssSelector(".card.mt-4.top-card"))?.ToList()[2];
                Card?.Click();
                Thread.Sleep(2000);

                // Btn
                IWebElement alertBox = driver.FindElement(By.XPath("//div[contains(@class, 'element-list') and contains(@class, 'show')]/ul/li[@id='item-1']"));
                alertBox.Click();

                IWebElement clickMe = driver.FindElement(By.Id("promtButton"));
                clickMe.Click();

                IAlert alert = driver.SwitchTo().Alert();
                alert.SendKeys("Kerym's");
                alert.Accept();
                Thread.Sleep(5000);
                driver.ExecuteScript("alert('Test Ejecutado Exitosamente')");
                Thread.Sleep(5000);
                driver.Quit();
            }
            catch (Exception e)
            {

                driver.ExecuteAsyncScript("alert('ha ocurrido un error ejecutando el test " + e.Message + "')");
                throw;
            }
        }
    }
}
