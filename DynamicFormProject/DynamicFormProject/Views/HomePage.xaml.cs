using DynamicFormProject.DataTemplates;
using DynamicFormProject.Models;
using DynamicFormProject.Services;
using DynamicFormProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DynamicFormProject.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            ContentPanel.ItemTemplate = new DynamicLayoutTemplateSelector();
            BindingContext = new HomePageViewModel();
        }

        protected override void OnAppearing()
        {
            (BindingContext as HomePageViewModel).Item = ((BindingContext as HomePageViewModel).DataStore as MockDataStore).item;
            var test = (BindingContext as HomePageViewModel).SelectedItem;
        }
    }
}