using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver("C:\\ChromeDriver");
            WebDriverWait myWait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            
            driver.Navigate().GoToUrl("https://www.linkedin.com/");

            driver.FindElement(By.Id("login-email")).SendKeys("dummya481@gmail.com");
            driver.FindElement(By.Id("login-password")).SendKeys("asdfghjkl");
            driver.FindElement(By.Id("login-submit")).Click();
            driver.FindElement(By.LinkText("request a new one.")).Click();
            driver.FindElement(By.Name("userName")).SendKeys("dummya481@gmail.com");
            driver.FindElement(By.Id("btnSubmitResetRequest")).Click();
            
            driver.Navigate().GoToUrl("http://mail.google.com");
            myWait.Until(ExpectedConditions.ElementExists(By.Name("identifier")));
            driver.FindElement(By.Name("identifier")).SendKeys("dummya481@gmail.com");
            driver.FindElement(By.XPath("//*[@id='identifierNext']/content")).Click();
            myWait.Until(ExpectedConditions.ElementExists(By.Name("password")));
            driver.FindElement(By.XPath("//*[@id='password']/div[1]/div/div[1]/input")).SendKeys("asdfghjkl@12345");
            driver.FindElement(By.XPath("//*[@id='passwordNext']")).Click();
            //driver.FindElement(By.CssSelector("div.cP td[contains(text(),'Account Recovery - Stack Overflow')]")).Click();
                
        }
    }
}
