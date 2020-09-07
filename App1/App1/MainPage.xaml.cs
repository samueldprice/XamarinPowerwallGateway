using App1.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace App1
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private ViewModel _viewModel;

        public MainPage()
        {
            InitializeComponent();
            _viewModel = new ViewModel();
            BindingContext = _viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (Application.Current as App).PowerwallService.Subscribe(NewValues);
        }


        private void NewValues(Aggregates aggregates)
        {
            _viewModel.Battery = aggregates.Battery?.InstantPower;
            _viewModel.Grid = aggregates.Site?.InstantPower;
            _viewModel.Home = aggregates.Load?.InstantPower;
            _viewModel.Solar = aggregates.Solar?.InstantPower;
            _viewModel.Errors = aggregates?.ErrorMessage;
        }
    }
}
