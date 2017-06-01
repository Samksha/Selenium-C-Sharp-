using System;
using NUnit.Framework;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace TestCalc.Test
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void AddTwoNumbers()
        {
            Application calcApp = Application.Launch("calc.exe");
            Window window = calcApp.GetWindow("Calculator", InitializeOption.NoCache);
            Button testButton = window.Get<Button>(SearchCriteria.ByText("2"));
            testButton.Click();
            window.Get<Button>(SearchCriteria.ByAutomationId("93")).Click();
            window.Get<Button>(SearchCriteria.ByAutomationId("132")).Click();
            window.Get<Button>(SearchCriteria.ByAutomationId("121")).Click();
            Label result = window.Get<Label>(SearchCriteria.ByAutomationId("150"));
            Assert.That("4", Is.EqualTo(result.Text));
        }
    }
}
