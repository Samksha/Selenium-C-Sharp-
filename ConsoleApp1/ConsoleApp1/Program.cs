using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ConsoleApp1
{
	class Program
	{
		static void Main(string[] args)
		{
			//Console.Write("Hello World");
			IWebDriver driver = new ChromeDriver("C:\\ChromeDriver");
			driver.Navigate().GoToUrl("http://mail.google.com");

			// Find the text input element by its name
			IWebElement element = driver.FindElement(By.Name("identifier"));

			// Enter username and Click next
			element.SendKeys("dummya481@gmail.com");
			driver.FindElement(By.XPath("//*[@id='identifierNext']/content")).Click();

			//Explicit wait
			WebDriverWait myWait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
			myWait.Until(ExpectedConditions.ElementExists(By.Name("password")));

			//pwd = asdfghjkl@12345
			driver.FindElement(By.XPath("//*[@id='password']/div[1]/div/div[1]/input")).SendKeys("asdfghjkl@12345");
			driver.FindElement(By.XPath("//*[@id='passwordNext']")).Click();

			myWait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(text(),'COMPOSE')]")));
			driver.FindElement(By.XPath("//div[contains(text(),'COMPOSE')]")).Click();

			myWait.Until(ExpectedConditions.ElementExists(By.XPath("//*[contains(@name, 'to')]")));

			//Get initial number of unread mails 
			String title = driver.Title;
			Console.WriteLine(title);
			int a = title.IndexOf('(');
			int b = title.IndexOf(')');
			int ini = Convert.ToInt32(title.Substring(a + 1, b-a-1));
			Console.WriteLine(ini);

			//Type content, send mail and refresh
			driver.FindElement(By.XPath("//*[contains(@name, 'to')]")).SendKeys("dummya481@gmail.com");
			driver.FindElement(By.XPath("//*[contains(@name, 'subjectbox')]")).SendKeys("Auto-generated mail");
			driver.FindElement(By.XPath("//*[contains(@class, 'Am Al editable LW-avf')]")).SendKeys("This mail has been generated automatically.");
			driver.FindElement(By.XPath("//*[contains(text(), 'Send')]")).Click();
			driver.FindElement(By.XPath("//*[contains(@class, 'asf T-I-J3 J-J5-Ji')]")).Click();

			//Get final number of unread mails
			driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5000));
			String title2 = driver.Title;
			Console.WriteLine(title2);
			int a1 = title2.IndexOf('(');
			int b1 = title2.IndexOf(')');
			int fin = Convert.ToInt32(title2.Substring(a1 + 1, b1-a1-1));
			Console.WriteLine(fin);

			if (fin - ini == 1)
				Console.WriteLine("Mail sent and receied at inbox");
    	else
    		Console.WriteLine("Nope");
			Console.ReadKey();
		}
	}
}
