using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace FeetConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            FeetConverter();            
        }

        private static void FeetConverter()
        {
            string _masterOutput = "";
            double _masterNumber = 0;

            try
            {
                Console.WriteLine("Enter a valid number in Feet/Inches format (including spaces where necessary)\nExample: 55' 1 1/2\"\n");
                string input = ValidateInput();

                input.Trim();
                input.Replace(" ", "");

                string[] sFeetTemp = input.Split('\'');

                string sFeet = sFeetTemp[0];
                _masterOutput += sFeet;

                string[] sInches = sFeetTemp[1].Split(' ');

                double adder = 0;

                foreach (string s in sInches)
                {
                    string res = "";

                    if (s.Contains("\""))
                        res = s.Replace("\"", "");
                    else
                        res = s;

                    if (res.Contains("/"))
                    {
                        string[] fraction = res.Split('/');
                        double num1;
                        double num2;
                        double.TryParse(fraction[0], out num1);
                        double.TryParse(fraction[1], out num2);
                        double resultant = (num1 / num2);
                        res = resultant.ToString();
                    }
                    else
                    {
                        double num;
                        bool bnum = double.TryParse(res, out num);
                    }

                    double dbl = 0;
                    bool bdbl = double.TryParse(res, out dbl);
                    if (bdbl)
                        adder += dbl;
                }
                adder = adder / 12;

                double.TryParse(sFeet, out _masterNumber);
                _masterNumber += adder;

                Console.WriteLine("Output: " + _masterNumber.ToString());
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Press Enter to try again.");
                Console.ReadKey();
                var filename = Assembly.GetExecutingAssembly().Location;
                System.Diagnostics.Process.Start(filename);
            }
        }

        private static string ValidateInput()
        {
            string input = Console.ReadLine();

            if (!input.Contains("'"))
            {
                Console.WriteLine("Must contain a ft. symbol \" ' \"\n");
                throw new FormatException();
            }
            else if (!input.Contains("\""))
            {
                Console.WriteLine("Must contain an inches symbol ' \" '\n");
                throw new FormatException();
            }
            else
                return input;
        }
    }
}