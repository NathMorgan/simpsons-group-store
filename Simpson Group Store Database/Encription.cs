using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Simpson_Group_Store_Database
{
    public class Encryption
    {
        UTF8Encoding encoder = new UTF8Encoding();

        public string sha256encrypt(string phrase)
        {
            SHA256Managed sha256 = new SHA256Managed();
            byte[] hashedData = sha256.ComputeHash(encoder.GetBytes(phrase));

            return byteArrayToString(hashedData);
        }

        public string byteArrayToString(byte[] inputArray)
        {
            StringBuilder output = new StringBuilder("");
            for (int i = 0; i < inputArray.Length; i++)
            {
                output.Append(inputArray[i].ToString("X2"));
            }
            return output.ToString();
        }
    }
}