using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Util
{
    public class RegexUtilities
    {
         bool invalid = false;
        public bool validarMail(string email)
        {
            invalid = false;
            if (string.IsNullOrEmpty(email)) return false;

            /*En MSDN están los siguientes parámetros, que el VS2010 me da error diciendo que no existe sobrecarga al método REPLACE con 5 PARÁMETROS:
	      RegexOptions.None, TimeSpan.FromMilliseconds(200)*/

            //usar IdnMapping Class para convertir nombres de dominio UNICODE
            try { email = Regex.Replace(email, @"(@)(.+)$", this.DomainMapper); }
            
            /*En el ejemplo de MSDN dice: RegexMatchTimeoutException, pero da error
            y el intellisense no da ninguna otra referencia que no sea TimeoutException; sin embargo así también funciona*/

            catch (TimeoutException) { return false; }

            if (invalid) return false;

            //Acá retorna TRUE si es válido el formato de correo electrónico
            try
            {
                return Regex.IsMatch(email, @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$", RegexOptions.IgnoreCase);
            }
            catch (TimeoutException) { return false; };

        }
        private string DomainMapper(Match match)
        {   // la clase IndMapping con los valores de propiedades por defecto 
            IdnMapping idn = new IdnMapping();
            string nombreDominio = match.Groups[2].Value;
            try { nombreDominio = idn.GetAscii(nombreDominio); }
            catch (ArgumentException) { invalid = true; }

            return match.Groups[1].Value + nombreDominio;
        }
    }
    
}
