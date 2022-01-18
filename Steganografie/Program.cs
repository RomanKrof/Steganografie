using System;
using System.Drawing;

namespace Steganografie
{
    
    class Program
    {
        static void Main(string[] args)
        {
            //Bitmap b = new Bitmap();

            if (ArgumentsOK(args) == true)
            {
                if(args[0] == "--hide")
                {
                    Bitmap bm = new Bitmap(args[2]);
                    Hide(bm, args[1]);
                }

                if (args[0] == "--show")
                {
                    Bitmap bm = new Bitmap(args[1]);
                }
            }        
            //foreach (var s in args)
            //{
            //    Console.WriteLine(s);
            //}
        }
        static bool ArgumentsOK(string[] h)
        {
            return true;
        }

        public static void Hide(Bitmap b, string s)
        {
            int j = 5;
            int i = 10;

            foreach(char ch in s)
            {
                Color c = b.GetPixel(j, i);
                Color setPix = Color.FromArgb(c.R, c.G, ch);
                b.SetPixel(j, i, setPix);
                j += 2;
                i += 2;
            }

            Color Last = b.GetPixel(b.Width-1, b.Height-1);
            Color setLast = Color.FromArgb(Last.R, Last.B, s.Length);
            b.SetPixel(b.Width - 1, b.Height - 1, setLast);
            b.Save("Kamen.png");
        }
    }
}
