using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App01
{
    public class Encryptor
    {
        public string Encrypt(string text)
        {
            string encrypted = "";
            for(int i = 0; i < text.Length; i++)
            {
                int ch = (int)text[i]; //ascii of character
                encrypted+=ch.ToString();
            }

            return encrypted;
        }

        public bool Match(string encryptedText, string normalText)
        {
            return encryptedText == Encrypt(normalText);
        }
        
    }
}
