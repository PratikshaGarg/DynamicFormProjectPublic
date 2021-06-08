using DynamicFormProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynamicFormProject.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        public readonly Item item;
        public MockDataStore()
        {
            item = new Item()
            {
                Title = "Music Form",
                Field = new List<FieldType>() { new FieldType() { Label = "Band Name", Type = "TextBox" }, new FieldType() { Label = "Genre", Type = "DropDown", DropDownValues = new List<string>() { "Rock", "Metal", "Jazz" } }, new FieldType() { Label = "Rating out of 5", Type = "NumericTextBox" }}                           
            };
        }
        
    }
}
