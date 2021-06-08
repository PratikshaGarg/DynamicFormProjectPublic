using DynamicFormProject.Models;
using DynamicFormProject.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DynamicFormProject.ViewModels
{
    public class HomePageViewModel: BaseViewModel
    {
        public Item Item { get; set; } = new Item();     
        private List<FieldType> dataSource;
        public List<FieldType> DataSource
        {
            get => dataSource;
            set => SetProperty(ref dataSource, value);
        }
        private string selectedItem;
        public string SelectedItem
        {
            get => selectedItem;
            set => SetProperty(ref selectedItem, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public HomePageViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            Item = (DataStore as MockDataStore).item;
            Title = Item.Title;
            DataSource = Item.Field;
            //foreach (FieldType f1 in Item.Field)
            //{
            //    Value = f1.Value;
            //}
        }

        private void OnCancel()
        {
            Application.Current.Quit();
        }
        private void OnSave()
        {
            Item = (DataStore as MockDataStore).item;
            foreach (FieldType f1 in Item.Field)
            {
                if (f1.Type == "DropDown")
                    f1.SelectedItem = SelectedItem;
            }

            Application.Current.Properties["Item"] = Item;
        }
    }
}
