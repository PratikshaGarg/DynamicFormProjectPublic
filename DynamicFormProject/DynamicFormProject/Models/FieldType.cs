using DynamicFormProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DynamicFormProject.Models
{
    public class FieldType : BaseViewModel
    {
        public string Label { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }

        public string SelectedItem { get; set; }
        private int index = -1;
        public int Index
        {
            get => index;
            set => SetProperty(ref index, value);
        }
        public List<string> DropDownValues { get; set; }
    }
}
