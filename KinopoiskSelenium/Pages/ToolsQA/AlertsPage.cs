using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using OpenQA.Selenium;

namespace KinopoiskSelenium.Pages.ToolsQA
{
    public class AlertsPage : BasePage
    {
        private readonly string _url = "https://demoqa.com/alerts";
        private By _alertButton = By.Id("alertButton");
        private By _timerAlertButton = By.Id("timerAlertButton");
        private By _confirmButton = By.Id("confirmButton");
        private By _promtButton = By.Id("promtButton");
        private By _confirmResult = By.Id("confirmResult");
        private By _promptResult = By.Id("promptResult");
        private IAlert _alert;
        private Timestamp _startTime;
        private Timestamp _endTime;
        public string AlertText { get; private set; }
        public string ConfirmationResult { get; private set; }
        public int Seconds { get; private set; }

        public AlertsPage(ConciseApi conciseApi) : base(conciseApi)
        {
            OpenPage();
        }

        public override void OpenPage()
        {
            ConciseApi.Open(_url);
        }

        public void OpenAlert()
        {
            ConciseApi.Click(_alertButton);
            SwitchToAlert();
        }

        public void OpenTimerAlert()
        {
            ConciseApi.Click(_timerAlertButton);
            _startTime = DateTime.UtcNow.ToTimestamp();
            SwitchToAlert();
        }

        public void OpenConfirmAlert()
        {
            ConciseApi.Click(_confirmButton);
            SwitchToAlert();
        }

        public void OpenPromptAlert()
        {
            ConciseApi.Click(_promtButton);
            SwitchToAlert();
        }

        private void SwitchToAlert()
        {
            _alert = ConciseApi.GetAlert();
            _endTime = DateTime.UtcNow.ToTimestamp();
            AlertText = _alert.Text;
            Console.WriteLine(_alert.Text);
        }

        public void ConfirmAlert()
        {
            _alert.Accept();
            if (_startTime != null)
            {
                Seconds = (int)(_endTime - _startTime).Seconds;
                Console.WriteLine($"Time of appearing alert is {Seconds} seconds");
            }
        }

        public void ActConfirmationAlert(bool confirm)
        {
            if (confirm)
            {
                _alert.Accept();
                
            }
            else
            {
                _alert.Dismiss();
            }

            ConfirmationResult = ConciseApi.GetTextOfTheElement(_confirmResult);
            Console.WriteLine("Confirmation text: " + ConfirmationResult);

        }

        public void ActPromptAlert(bool confirm)
        {
            if (confirm)
            {
                _alert.SendKeys("test");
                _alert.Accept();
                ConfirmationResult = ConciseApi.GetTextOfTheElement(_promptResult);
                Console.WriteLine("Confirmation text: " + ConfirmationResult);

            }
            else
            {
                _alert.Dismiss();
                try
                {
                    //var text = ConciseApi.GetTextOfTheElement(_promptResult);
                    ConfirmationResult = ConciseApi.GetTextOfTheElement(_promptResult);
                }
                catch (Exception e)
                {
                    ConfirmationResult = String.Empty;
                    Console.WriteLine("No text as it was cancelled");
                }
            }

            
        }
    }
}
