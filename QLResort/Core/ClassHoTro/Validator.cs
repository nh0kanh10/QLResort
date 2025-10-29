using QLResort.Core.Model;
using QLResort.Core.Model.ToolHoTro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLResort.Core.ClassHoTro
{
    public static class Validator
    {
        public static bool IsEqualString(string a,string b)
        {
            return a.Trim().ToUpper() == b.Trim().ToUpper();
        }
        public static bool IsRequired(string input)
        {
            return !string.IsNullOrWhiteSpace(input);
        }

        public static bool IsRequired(string input,int max)
        {
            return !string.IsNullOrWhiteSpace(input) && input.Length <= max;
        }
        public static bool MaxLength(string input, int max)
        {
            if (input == null) return true; 
            return input.Length <= max;
        }

        public static bool IsEmail(string input)
        {
            if (input == null) return false;
            return input.Contains("@") && input.Contains(".");
        }

        public static bool IsNumber(string input)
        {
            if (input == null) return false;
            int temp;
            return int.TryParse(input, out temp);
        }

        public static bool IsPhoneNumber(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;
            if (input.Length < 9 || input.Length > 11) return false;

            foreach (char c in input)
            {
                if (!char.IsDigit(c)) return false;
            }

            return true;
        }
    }
}
