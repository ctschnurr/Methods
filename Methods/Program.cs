using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methods
{
    internal class Program
    {

        static string gameName;
        static string studioName;
        static string newFeature;

        static float score;
        static float multiplier;
        static int health;
        static int medPack;
        static int lives;

        static ConsoleKeyInfo choice;

        static void Main(string[] args)
        {
            gameName = "STATS TESTER!";
            studioName = "Schnurr Studio!";
            newFeature = "METHODS!";

            score = 0;
            multiplier = 1;
            health = 100;
            medPack = 25;
            lives = 3;

            ShowHud();

            while (choice.Key != ConsoleKey.D0)
            {
                ShowHud();
                makeChoice();
            }

            Console.WriteLine("");
            Console.Write("Thank you for playing " + gameName + " By " + studioName);
            Pause();


        }

        static void ShowHud()
        {
            string hudHealth = health.ToString();
            string hudLives = lives.ToString();
            string hudScore = score.ToString();
            string hudMult = multiplier.ToString();

            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("  Welcome to " + gameName + " Now with " + newFeature.PadRight(38) + "By " + studioName);
            Console.WriteLine(".------------------------------------------------------------------------------------------.");
            Console.WriteLine("|        Health: " + hudHealth.PadRight(12) + "Lives: " + hudLives.PadRight(12) + "Score: " + hudScore.PadRight(12) + "Multiplier: " + hudMult.PadRight(12) + "|");
            Console.WriteLine("'------------------------------------------------------------------------------------------'");
            Console.WriteLine("");
        }

        static void makeChoice()
        {
            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine("");
            Console.WriteLine("  1 - Simulate random damage");
            Console.WriteLine("  2 - Simulate battle won");
            Console.WriteLine("  3 - Add Health");
            Console.WriteLine("  4 - Add a Life");
            Console.WriteLine("  0 - Exit");
            Console.WriteLine("");
            Console.Write("Enter Choice: ");

            choice = Console.ReadKey(true);
            Console.WriteLine("");

            if (choice.Key == ConsoleKey.D1)
            {
                SimFight();
            }

            if (choice.Key == ConsoleKey.D2)
            {
                SimWin();
            }

            if (choice.Key == ConsoleKey.D3)
            {
                Heal();
            }

            if (choice.Key == ConsoleKey.D4)
            {
                Life();
            }
        }

        static void Life()
        {
            if (lives == 0 && health == 0)
            {
                health = health + 100;

                Console.WriteLine("");
                Console.Write("Player has been revived!");
                Pause();
            }

            else
            {
                lives = lives + 1;

                Console.WriteLine("");
                Console.Write("Player received a 1Up!");
                Pause();
            }
        }

        static void Heal()
        {
            if (health == 0 && lives == 0)
            {
                Console.WriteLine("");
                Console.Write("The player is dead and cannot be healed!");
                Pause();
            }

            else
            {
                health = health + medPack;

                Console.WriteLine("");
                Console.Write("Player received a +" + medPack + " health pack!");
                Pause();
            }
        }


        static void Pause()
        {
            Console.ReadKey(true);
            Console.WriteLine("");
        }

        static void SimFight()
        {
            if (health == 0 && lives == 0)
            {
                Console.WriteLine("");
                Console.Write("The player is out of lives!");
                Pause();

            }

            else
            {
                Random rand = new Random();
                int harm = rand.Next(0, 100);
                TakeDamage(harm);

                if (health < 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.Write("Player has ");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("DIED");
                    Console.ResetColor();
                    Console.WriteLine("!");
                    lives = (lives - 1);


                    if (lives == -1)
                    {
                        health = 0;
                        lives = 0;
                        score = 0;
                        multiplier = 1;

                        Pause();
                        Console.Clear();
                        Console.WriteLine("");
                        Console.WriteLine("Player is out of lives!");
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("GAME OVER");
                        Console.ResetColor();
                        Console.WriteLine("!");
                        Console.WriteLine("");
                        Console.Write("Score and multiplier have been reset!");
                    }

                    else
                    {
                        Console.WriteLine("");
                        Console.Write("One life hase been used.");
                        health = 100;
                    }
                }
                Pause();
            }
        }

        static void SimWin()
        {
            if (lives == 0 && health == 0)
            {
                Console.WriteLine("");
                Console.Write("Player is dead and cannot simulate battles!");
                Pause();
            }

            else
            {

                Random rand = new Random();
                int scoreUp = rand.Next(1, 5);

                score = score + AddScore(scoreUp, multiplier);
                multiplier = (multiplier + 0.1f);

                score = (float)Math.Round(score, 1);
                multiplier = (float)Math.Round(multiplier, 2);
            }
        }

        static float AddScore(int pointsEarned, float scoreMultiplier)
        {
            float scoreTot = pointsEarned * scoreMultiplier;
            scoreTot = (float)Math.Round(scoreTot, 1);

            Console.WriteLine("");
            Console.WriteLine("Player has won a battle!");
            Console.WriteLine("");
            Console.WriteLine("Player received " + pointsEarned + " points, x " + scoreMultiplier + " for a total of " + scoreTot + " points!");
            Console.WriteLine("");
            Console.Write("Multiplier has gone up!");
            Pause();
            return scoreTot;

        }

        static void TakeDamage(int damage)
        {
            health = health - damage;
            Console.WriteLine("");
            Console.Write("Player took " + damage + " damage!");
        }
    }
}
