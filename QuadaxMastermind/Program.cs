using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadaxMastermind
{
    class Program
    {
        static string generateCode()
        {
            var code = "";
            var rand = new Random();
            for (var i = 0; i < 4; i++)
            {
                code += rand.Next(1, 7);
            }
            return code;
        }
        static bool checkInputInvalid(string input)
        {
            for (var i=0; i<input.Length; i++)
            {
                if (!Char.IsDigit(input[i]))
                {
                    return true;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mastermind!");
            Console.WriteLine("Your 4 digit code has been generated. You may begin guessing.");
            var code = generateCode();
            bool won = false;
            for (var i=10; i>0; i--)
            {
                string guess = Console.ReadLine();
                string result = "";
                if (guess.Length != 4 || checkInputInvalid(guess))
                {
                    Console.WriteLine("Your guess is invalid and has not been counted.");
                    i++;
                    continue;
                }
                if (code.Equals(guess))
                {
                    Console.WriteLine("You have solved the puzzle!");
                    won = true;
                    break;
                }
                List<char> archiveCharacters = new List<char>();
                List<int> guessedPositions = new List<int>();
                for (var g=0; g<4; g++)
                {
                    if (guess[g] == code[g])
                    {
                        result += "+";
                        guessedPositions.Add(g);
                    }
                }
                for (var g = 0; g < 4; g++)
                {
                    for (var f = 0; f<4; f++)
                    {
                        if ((code[f] == guess[g]) && !guessedPositions.Contains(f) && !archiveCharacters.Contains(guess[g]))
                        {
                            result += "-";
                            archiveCharacters.Add(guess[g]);
                            break;
                        }
                    }
                }
                Console.WriteLine(result);
            }
            if (!won)
            {
                Console.WriteLine("Sorry, but you failed to solve the puzzle in 10 tries.");
            }
            Console.ReadLine();
        }
        
    }
}
