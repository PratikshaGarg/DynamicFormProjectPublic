using DynamicFormProject.ViewModels;
using System;
using System.Collections.Generic;

namespace DynamicFormProject.Models
{
    public class Item
    {
        public string Title { get; set; }
        public List<FieldType> Field { get; set; }
    }
}