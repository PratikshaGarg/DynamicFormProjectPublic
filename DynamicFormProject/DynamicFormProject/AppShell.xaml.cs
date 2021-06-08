using DynamicFormProject.ViewModels;
using DynamicFormProject.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DynamicFormProject
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();           
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        }

        //private async void OnMenuItemClicked(object sender, EventArgs e)
        //{
        //    await Shell.Current.GoToAsync("//LoginPage");
        //}
    }
}
