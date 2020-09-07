using App1.Models;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    public partial class App : Application
    {
        const string displayText = "displayText";
        public Service<Aggregates> PowerwallService;
        private PowerwallRestClient _powerwallRestClient;

        public string DisplayText { get; set; }

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            _powerwallRestClient = new PowerwallRestClient();
            PowerwallService = new Service<Aggregates>();
            PowerwallService.Start(() =>
            {
                return _powerwallRestClient.Get().GetAwaiter().GetResult();
            });
        }

        protected override void OnStart()
        {
            if (Properties.ContainsKey(displayText))
            {
                DisplayText = (string)Properties[displayText];
            }
        }

        protected override void OnSleep()
        {
            Properties[displayText] = DisplayText;
        }

        protected override void OnResume()
        {
        }
    }
}
