using DynamicFormProject.Models;
using DynamicFormProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DynamicFormProject.DataTemplates
{
    public class DynamicLayoutTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TextBoxDataTemplate { get; set; }
        public DataTemplate NumericTextBoxDataTemplate { get; set; }
        public DataTemplate DropDownDataTemplate { get; set; }

        private Picker picker;
        public DynamicLayoutTemplateSelector()
        {
            TextBoxDataTemplate = new DataTemplate(() =>
            {
                StackLayout s1 = new StackLayout() { Orientation = StackOrientation.Horizontal, Margin = new Thickness(20, 20, 20, 0) };

                Label label1 = new Label() { Margin = new Thickness(10, 0, 0, 0), VerticalTextAlignment = TextAlignment.Center, FontSize = 20 };
                label1.SetBinding(Label.TextProperty, "Label");
                Entry entry = new Entry() { Margin = new Thickness(10,0,0,0), HorizontalOptions = LayoutOptions.FillAndExpand};
                entry.SetBinding(Entry.TextProperty, nameof(FieldType.Value));

                s1.Children.Add(label1);
                s1.Children.Add(entry);
                return s1;
            });

            NumericTextBoxDataTemplate = new DataTemplate(() =>
            {
                StackLayout s1 = new StackLayout() { Orientation = StackOrientation.Horizontal, Margin = new Thickness(20, 20, 20, 0) };

                Label label1 = new Label() { Margin = new Thickness(10, 0, 0, 0), VerticalTextAlignment = TextAlignment.Center, FontSize = 20 };
                label1.SetBinding(Label.TextProperty, "Label");
                Entry numEntry = new Entry() { Margin = new Thickness(10, 0, 10, 0), Keyboard = Keyboard.Numeric, HorizontalOptions = LayoutOptions.FillAndExpand };
                numEntry.SetBinding(Entry.TextProperty, nameof(FieldType.Value));

                s1.Children.Add(label1);
                s1.Children.Add(numEntry);
                return s1;
            });

            DropDownDataTemplate = new DataTemplate(() =>
            {
                StackLayout s1 = new StackLayout() { Orientation = StackOrientation.Horizontal, Margin = new Thickness(20, 20, 20, 0) };

                Label label1 = new Label() { Margin = new Thickness(10, 0, 0, 0), VerticalTextAlignment = TextAlignment.Center, FontSize = 20 };
                label1.SetBinding(Label.TextProperty, "Label");
                picker = new Picker() { Margin = new Thickness(10, 0, 10, 0), HorizontalOptions = LayoutOptions.FillAndExpand };
                picker.SetBinding(Picker.ItemsSourceProperty, "DropDownValues", BindingMode.TwoWay);
                picker.SetBinding(Picker.SelectedIndexProperty, "Index", BindingMode.TwoWay);               
                s1.Children.Add(label1);
                s1.Children.Add(picker);
                return s1;
            });
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item.GetType() == typeof(FieldType))
            {
                switch(((FieldType)item).Type)
                {
                    case "TextBox":
                        return TextBoxDataTemplate;
                    case "NumericTextBox":
                        return NumericTextBoxDataTemplate;
                    case "DropDown":
                        return DropDownDataTemplate;
                }
            }
            return TextBoxDataTemplate;
        }
    }
}
