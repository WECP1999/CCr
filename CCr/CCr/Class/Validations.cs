using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CCr.Class
{
    class Validations
    {
        private string expresion;

        public bool validateEmail(string email)
        {
            expresion = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool validateName(string name)
        {
            expresion = @"^([A-ZÁÉÍÓÚÑ]{1}[a-záéíóúñ]+\s*)+$";
            if (Regex.IsMatch(name, expresion))
            {
                if (Regex.Replace(name, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
        public bool validateText(string text)
        {
            expresion = @"^([A-ZÁÉÍÓÚÑa-záéíóúñ]+\s*)+$";
            if (Regex.IsMatch(text, expresion))
            {
                if (Regex.Replace(text, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public bool validateFon(string text)
        {
            expresion = @"^[267]{1}[0-9]{3}-?[0-9]{4}$";
            if (Regex.IsMatch(text, expresion))
            {
                if (Regex.Replace(text, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public bool validateMoney(string text)
        {
            expresion = @"^[0-9]+(\.[0-9]{1,2})?$";
            if (Regex.IsMatch(text, expresion))
            {
                if (Regex.Replace(text, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public bool validateNumber(string text)
        {
            expresion = @"^[0-9]+$";
            if (Regex.IsMatch(text, expresion))
            {
                if (Regex.Replace(text, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public bool validateDUI(string text)
        {
            expresion = @"^[0-9]{8}\-?[0-9]{1}$";
            if (Regex.IsMatch(text, expresion))
            {
                if (Regex.Replace(text, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public bool validateUs(string text)
        {
            expresion = @"^[A-Za-z0-9\.\\\$\#_@]+$";
            if (Regex.IsMatch(text, expresion))
            {
                if (Regex.Replace(text, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public bool valideteAnotherThing(string regex,string text)
        {
            expresion = regex;
            if (Regex.IsMatch(text, expresion))
            {
                if (Regex.Replace(text, expresion, string.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public static string GetSHA256(string str)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(str));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

    }
}
