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
            newFeature = "METHODS!";
            
            score = 0;
            multiplier = 1;
            health = 100;
            medPack = 25;
            lives = 3;

            ShowHud();

            Console.WriteLine("First we will simulate 5 rounds of battle.");
            Pause();

            ShowHud();
            SimFight();

            ShowHud();
            
            SimFight();
            ShowHud();
            
            SimFight();
            ShowHud();
           
            SimFight();
            ShowHud();
            
            SimFight();
            ShowHud();
            

            Console.WriteLine("Now the demo will end");
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
            Console.WriteLine("  Welcome to " + gameName + " Now with " + newFeature.PadRight(38) + "By Schnurr Studio");
            Console.WriteLine(".------------------------------------------------------------------------------------------.");
            Console.WriteLine("|        Health: " + hudHealth.PadRight(12) + "Lives: " + hudLives.PadRight(12) + "Score: " + hudScore.PadRight(12) + "Multiplier: " + hudMult.PadRight(12) + "|");
            Console.WriteLine("'------------------------------------------------------------------------------------------'");
            Console.WriteLine("");

        }


        static void Pause()
        {
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue");
            Console.WriteLine("");
            Console.ReadKey();
        }

        static void SimFight()
        {
            if (health == 0 && lives == 0)
            {
                Console.WriteLine("");
                Console.WriteLine("The player is out of lives!");
                Pause();
                
            }

            else
            {
                Random rand = new Random();
                int damage = rand.Next(0, 100);
                TakeDamage(damage);

                if (health < 0)
                {
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

                        Console.Clear();
                        Console.WriteLine("");
                        Console.WriteLine("Player is out of lives!");
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("GAME OVER");
                        Console.ResetColor();
                        Console.WriteLine("!");
                        Console.WriteLine("");
                        Console.WriteLine("Score and multiplier have been reset!");
                        Pause();

                    }

                    else
                    {
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
                Console.WriteLine("Player is dead and cannot simulate battles!");
                Pause();

                ShowHud();

            }

            else
            {
                Random rand = new Random();
                int scoreUp = rand.Next(1, 5);
                float scoreTot = scoreUp * multiplier;
                scoreTot = (float)Math.Round(scoreTot, 1);

                Console.WriteLine("");
                Console.WriteLine("Player has won a battle!");
                Console.WriteLine("");
                Console.WriteLine("Player received " + scoreUp + " points, x " + multiplier + " for a total of " + scoreTot + " points!");
                Console.WriteLine("");
                Console.WriteLine("Multiplier has gone up!");
                Pause();

                score = (score + scoreTot);
                multiplier = (multiplier + 0.1f);

                score = (float)Math.Round(score, 1);
                multiplier = (float)Math.Round(multiplier, 2);

                ShowHud();
            }
        }

        static void TakeDamage(int damage)
        {
            health = health - damage;

            Console.WriteLine("Player took " + damage + " damage!");
                       
        }
    }
}
