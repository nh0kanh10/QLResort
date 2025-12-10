using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.ClassHoTro
{
    public class ComboBoxItem
    {
        public string ID { get; set; } 
        public string Text { get; set; }  

        public ComboBoxItem(string key, string value) {
            ID = key;
            Text = value;
        }
        public override string ToString()
        {
            return Text;
        }
    }
}
