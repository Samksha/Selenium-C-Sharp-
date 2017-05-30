using System;
using System.IO;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using YamlDotNet;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace ConsoleApp2
{
	class Program
	{
		public static void search(IWebDriver driver, String url, String txt)
		{
			driver.Navigate().GoToUrl(url);
			IWebElement element = driver.FindElement(By.CssSelector("input[name = 'q']"));
			element.SendKeys(txt);
			element.Submit();
		}

		public static void accessLink(IWebDriver driver)
		{
			WebDriverWait myWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
			myWait.Until(ExpectedConditions.ElementExists(By.LinkText("Bing Translator")));
			driver.FindElement(By.LinkText("Bing Translator")).Click();
		}

		public static void enterText(IWebDriver driver, String input)
		{
			WebDriverWait myWait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
			myWait.Until(ExpectedConditions.ElementExists(By.XPath("//*[contains(@class, 'srcTextarea')]")));
			driver.FindElement(By.XPath("//*[contains(@class, 'srcTextarea')]")).SendKeys(input);
		}

		public static void changeLanguage(IWebDriver driver, String language)
		{
			driver.FindElement(By.XPath(".//*[@id='content']/div/div[2]/div[3]/div[1]/div[1]/div[1]/div/div[1]")).Click();
			driver.FindElement(By.CssSelector("div.col.translationContainer.destinationText td[value = '" + language + "']")).Click();
			//driver.FindElement(By.XPath(".//*[@id='content']/div/div[2]/div[3]/div[1]/div[1]/div[1]/table/tbody/tr[13]/td[1]")).Click();         
		}

		public static void chkInput(IWebDriver driver)
		{
			IWebElement inputBox = driver.FindElement(By.XPath("//*[contains(@class, 'srcTextarea')]"));
			String textInsideInputBox = inputBox.GetAttribute("value");
			if (string.IsNullOrEmpty(textInsideInputBox))
			{
				Console.WriteLine("Input field is empty");
			}
			else
			{
				Console.WriteLine("Input field is not empty");
			}
		}

		public static void chkOutput(IWebDriver driver, String result)
		{
            IWebElement outputBox = driver.FindElement(By.CssSelector("div#destText"));
            String text = outputBox.Text;

            if (text.Equals(result))
            {
                Console.WriteLine("Test Result is same");
            }
            else
            {
                Console.WriteLine("Error! Wrong Test Result");
            }
        }
	
		static void Main(string[] args)
		{
		    IWebDriver driver = new ChromeDriver("C:\\ChromeDriver");
            var input1 = File.OpenText("C:/Users/samkshabhardwaj/Documents/Visual Studio 2017/Projects/ConsoleApp2/ConsoleApp2/Yaml.yml");
            var deserializerBuilder = new DeserializerBuilder().WithNamingConvention(new CamelCaseNamingConvention());
            var deserializer = deserializerBuilder.Build();

            YamlReader reader =  deserializer.Deserialize<YamlReader>(input1);

            String Url = reader.Url;
            String Input = reader.TestData;
            String Result = reader.TestResult;
            String SearchTerm = reader.SearchKey;
            String Language = reader.Language;
            
		    search(driver, Url, SearchTerm);
		    accessLink(driver);
		    enterText(driver, Input);
		    changeLanguage(driver, Language);
		    chkInput(driver);
            Thread.Sleep(1000);
		    chkOutput(driver, Result);
	}
	}
}
