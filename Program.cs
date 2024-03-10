using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Full_Version_of_Converter_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string A = "a = Decimal to Binary"; 
            string B = "b = Binary to Decimal";
            string C = "c = Decimal to Octal";
            string D = "d = Octal to Decimal";

            Console.WriteLine("Choose a Converter: "); //Ask Users to Choose
            Console.WriteLine($"\n{A} \n{B} \n{C} \n{D}"); //Prints ABCD

            switch (Console.ReadLine())
            {
                case "a":
                {
                        DecToBin();
                        break;
                }
                case "b":
                {
                        BinToDec();
                        break;
                }
                case "c":
                {
                        DecToOct();
                        break;
                }
                case "d":
                {
                        OctToDec();
                        break;
                }
            }
        }
        static void DecToBin() //The operation of DecBin
        {
            string Binary = "";
            int Remainder;

            Console.WriteLine("Enter a Decimal To Convert: "); //Ask User for Decimal
            int Decimal = int.Parse(Console.ReadLine());
          
            Console.WriteLine($"Step by Step Conversion of {Decimal} to Binary ");
            while (Decimal > 0)
            {
                Remainder = Decimal % 2;
                Binary = Convert.ToString(Remainder) + Binary;

                Console.WriteLine($"{Decimal} / 2 = {Decimal / 2} \tRemainder = {Remainder}  \tBinary = {Binary}");

                Decimal /= 2;
            }
            Console.WriteLine();
            Binary = Convert.ToString(Binary);
            Console.WriteLine($"Binary Number: {Binary} "); //Decimal converts to Binary
            Console.ReadLine();
        }
        
        static void BinToDec()
        {
            Console.Write("Enter the Binary Number To Convert: ");
            int Binary = int.Parse(Console.ReadLine());
            int Decimal = 0;
            int base1 = 1;

            Console.WriteLine($"Step by Step Conversion of {Binary} to Decimal ");
            while (Binary > 0)
            {
                int Remainder = Binary % 10;
                Binary = Binary / 10;
                Decimal += Remainder * base1;
                Console.WriteLine($"   {Remainder} * 2^{base1 - 1} + {Binary} = {Remainder * (int)Math.Pow(2, base1 - 1) + Binary}");

                base1 = base1 * 2;
            }
            Console.WriteLine();
            Console.Write($"Decimal of the Binary : {Decimal} ");
            Console.ReadLine();
        }

        static void DecToOct()
        {
            Console.Write("Enter the Decimal Number To Convert: ");
            int Decimal = Convert.ToInt32(Console.ReadLine());

            int[] Octal = new int[100];
            int i = 0;

            Console.WriteLine($"Step by Step Conversion of {Decimal} to Octal ");

            while (Decimal != 0)
            {
                int remainder = Decimal % 8;
                Octal[i] = remainder;
                Decimal /= 8;

                Console.WriteLine($"   {remainder} * 8^{i} + {Decimal} = {Octal[i] * (int)Math.Pow(8, i) + Decimal}");

                i++;
            }
            Console.WriteLine();
            Console.Write("\nOctal Number: ");
            for (int j = i - 1; j >= 0; j--)
            {
                Console.Write(Octal[j]);
            }

            Console.ReadLine();
        }
        static void OctToDec()
        {
            Console.Write("Enter the Octal Number To Convert: ");
            int Octal = Convert.ToInt32(Console.ReadLine());

            int Decimal = 0;
            int baseValue = 1;
            int TempOctalNumber = Octal;

            bool isValidOctal = true;

            // Check if the octal number contains digits less than 8
            while (TempOctalNumber > 0)
            {
                int digit = TempOctalNumber % 10;
                if (digit >= 8)
                {
                    isValidOctal = false;
                    break;
                }
                TempOctalNumber /= 10;
            }

            if (!isValidOctal)
            {
                Console.WriteLine("Invalid octal number. Please enter a valid octal number.");
            }
            else
            {
                Console.WriteLine($"Step by Step Conversion of {Octal} to Decimal ");

                while (Octal > 0)
                {
                    int Digit = Octal % 10;
                    Console.WriteLine($"   {Digit} * {baseValue} + {Decimal} = {Digit * baseValue + Decimal}");
                    Decimal += Digit * baseValue;
                    baseValue *= 8;
                    Octal /= 10;
                }
                Console.WriteLine();
                Console.WriteLine($"Decimal Number: {Decimal}");
            }
            Console.ReadLine();
        }
    }
}
