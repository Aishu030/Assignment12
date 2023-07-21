using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

//Assignment12

namespace Assignment12
{
    internal class Program
    {
        static void Main(string[] args)
        {



            Console.WriteLine("Enter a piece of text:"); //user input
            string inputText = Console.ReadLine();

            // word count
            int wCount = wordCount(inputText);
            Console.WriteLine($"Word Count: {wCount}");

            // email validation
            List<string> emails = eValidation(inputText);
            if (emails.Count > 0)
            {
                Console.WriteLine("****Email addresses found*****");
                foreach (string email in emails)
                {
                    Console.WriteLine(email);
                }
            }
            else
            {
                Console.WriteLine("No email addresses found!!!!!");
            }

            //mobile number extraction
            List<string> mobileNumbers = NumExtraction(inputText);
            if (mobileNumbers.Count > 0)
            {
                Console.WriteLine("Mobile numbers found:");
                foreach (string number in mobileNumbers)
                {
                    Console.WriteLine(number);
                }
            }
            else
            {
                Console.WriteLine("No mobile numbers found!!!!");
            }

            //Custom Regex
            Console.WriteLine("Enter a custom regular expression:"); //prmpt user to input 
            string customRegex = Console.ReadLine();
            List<string> customMatches = CustomRegex(inputText, customRegex);
            if (customMatches.Count > 0)
            {
                Console.WriteLine("************Custom regex matches**************");
                foreach (string match in customMatches)
                {
                    Console.WriteLine(match);
                }
                Console.WriteLine("Press any key to exit");
            }
            else
            {
                Console.WriteLine("No matches found !!!!!!");
            }


            Console.ReadKey();
        }



        static int wordCount(string input)
        {
            return Regex.Matches(input, @"[^\s]+").Count;
        }

        static List<string> eValidation(string input)
        {
            List<string> emails = new List<string>();
            string emailPattern = @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}";
            MatchCollection matches = Regex.Matches(input, emailPattern);
            foreach (Match match in matches)
            {
                emails.Add(match.Value);
            }
            return emails;
        }

        static List<string> NumExtraction(string input)
        {
            List<string> mobileNumbers = new List<string>();
            string mobileNumberPattern = @"\d{10}";
            MatchCollection matches = Regex.Matches(input, mobileNumberPattern);
            foreach (Match match in matches)
            {
                mobileNumbers.Add(match.Value);
            }
            return mobileNumbers;
        }

        static List<string> CustomRegex(string input, string pattern)
        {
            List<string> matches = new List<string>();
            MatchCollection customMatches = Regex.Matches(input, pattern);
            foreach (Match match in customMatches)
            {
                matches.Add(match.Value);
            }
            return matches;

        }
    }
}

      