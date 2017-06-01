using System;
using System.Windows.Automation;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using NUnit;
using NUnit.Framework;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            Application calcApp = Application.Launch("calc.exe");
            Window window = calcApp.GetWindow("Calculator", InitializeOption.NoCache);
            Button testButton = window.Get<Button>(SearchCriteria.ByText("2"));
            testButton.Click();
            window.Get<Button>(SearchCriteria.ByAutomationId("93")).Click();
            window.Get<Button>(SearchCriteria.ByAutomationId("132")).Click();
            window.Get<Button>(SearchCriteria.ByAutomationId("121")).Click();
            Label result = window.Get<Label>(SearchCriteria.ByAutomationId("150"));
            if (result.Text.Equals("4"))
                Console.Write("Valid");
            Console.ReadKey();
            /*result.Focus();
            Keyboard.Instance.HoldKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.CONTROL);
            Keyboard.Instance.Enter("C");
            Keyboard.Instance.LeaveKey(TestStack.White.WindowsAPI.KeyboardInput.SpecialKeys.CONTROL);*/
        }
    }
}
