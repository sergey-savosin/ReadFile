using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace ReadFile
{
    class Program
    {
        public static void PrintCountsAndChars(byte[] bytes, Encoding enc)
        {

            // Display the name of the encoding used.
            Console.Write("{0,-25} :", enc.ToString());

            // Display the exact character count.
            int iCC = enc.GetCharCount(bytes);
            Console.Write(" {0,-3}", iCC);

            // Display the maximum character count.
            int iMCC = enc.GetMaxCharCount(bytes.Length);
            Console.Write(" {0,-3} :", iMCC);

            // Decode the bytes and display the characters.
            char[] chars = enc.GetChars(bytes);
            Console.WriteLine(chars);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("ara!");
            string line;
            StringBuilder sb = new StringBuilder();

            /* прочесть строку из файла */
            using (StreamReader sr = new StreamReader(@"file1.txt"))
            {
                line = sr.ReadLine();
            }
            if (line != null)
                Console.WriteLine("line=");// + line);
            else
            {
                Console.WriteLine("file is empty. Exit.");
                return;
            }

            /* разбор строки */
            string p, res;
            int i=2;
            while (i < line.Length)
            {
                p = line.Substring(i, 2);

                byte byteValue;
                bool bres;
                bres = Byte.TryParse(p, NumberStyles.AllowHexSpecifier, null, out byteValue);
                if (bres)
                    Console.Write("{0}", (char)byteValue);
                else
                    Console.WriteLine("fai ");

                i += 2;
            }

        }
    }
}
