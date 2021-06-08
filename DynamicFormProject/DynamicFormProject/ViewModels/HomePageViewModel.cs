using DynamicFormProject.Models;
using DynamicFormProject.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace DynamicFormProject.ViewModels
{
    public class HomePageViewModel: BaseViewModel
    {
        public Item Item { get; set; } = new Item();     
        private ObservableCollection<FieldType> dataSource = new ObservableCollection<FieldType>();
        public ObservableCollection<FieldType> DataSource
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
            foreach (FieldType x in Item.Field)
                DataSource.Add(x);            
        }

        public void OnAppearing()
        {          
            if(Application.Current.Properties.ContainsKey("Item"))
               Item = (Item)Application.Current.Properties["Item"];
            foreach (FieldType f1 in Item.Field)
            {
                if (f1.Type == "DropDown" && Application.Current.Properties.ContainsKey("SelectedIndex"))
                    f1.Index = (int)Application.Current.Properties["SelectedIndex"];
            }
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
                    Application.Current.Properties["SelectedIndex"] = f1.Index;
            }
            Application.Current.Properties["Item"] = Item;
        }
       
    }
}
