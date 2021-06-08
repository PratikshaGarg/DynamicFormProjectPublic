using DynamicFormProject.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DynamicFormProject.Models
{
    public class FieldType
    {
        public string Label { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }

        public string SelectedItem { get; set; }
        public int Index { get; set; } = 2;
        public List<string> DropDownValues { get; set; }
    }
}
