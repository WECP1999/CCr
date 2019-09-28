using System;
using System.Collections.Generic;
using System.Linq;
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
            expresion = "^((\"[\\w -\\s] + \")|([\\w-]+(?:\\.[\\w-]+)*)|(\"[\\w -\\s] + \")([\\w-]+(?:\\.[\\w-]+)*))" +
                "(@((?:[\\w-]+\\.)*\\w[\\w-]{0,66})\\.([a-z]{2,6}(?:\\.[a-z]{2})?)$)|" +
                "(@\\[?((25[0-5]\\.|2[0-4][0-9]\\.|1[0-9]{2}\\.|[0-9]{1,2}\\.))((25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\\.)" +
                "{2}(25[0-5]|2[0-4][0-9]|1[0-9]{2}|[0-9]{1,2})\\]?$)";
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
            expresion = @"^[0-9]+(\.[0-9]{1,2})?";
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
            expresion = @"^[0-9]+(\.[0-9]{1,2})?";
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

    }
}
