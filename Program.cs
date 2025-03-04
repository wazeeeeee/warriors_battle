﻿    using Duels_de_Guerriers;

    guerrier YourHero = null;
    
    void Battle()
    {
        Console.Clear();
        
        guerrier guerrier2 = new guerrier("The enemy");
        
        Console.WriteLine("\nA : Attack, H : Heal, F : FF");

        bool isEnd = false;
        while (!isEnd)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.A)
            {
                GreenColors();
                int damage = YourHero.Attack();
                if (damage > 0)
                {
                    guerrier2.ReceiveDamage(damage);
                }
                
                Console.WriteLine("");
            
                if (guerrier2.PV > 0)
                {
                    RedColors();
                    damage = guerrier2.Attack();
                    if (damage > 0)
                    {
                        YourHero.ReceiveDamage(damage);
                    }
                    
                    Console.WriteLine("");
                }
            }
            else if (keyInfo.Key == ConsoleKey.H)
            {
                YellowColors();
                if (YourHero.PV < 100)
                {
                    int healAmount = YourHero.Heal();
                    Console.WriteLine($"{YourHero.Name} se soigne de {healAmount} PV");
                    Console.WriteLine($"{YourHero.Name} a maintenant {YourHero.PV} PV");
                    WhiteColors();
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine($"{YourHero.Name} a déjà tous ses PV ({YourHero.PV})");
                    WhiteColors();
                    Console.WriteLine("");
                }
                
                int damage = guerrier2.Attack();
                GreenColors();
                YourHero.ReceiveDamage(damage);
                RedColors();
                Console.WriteLine($"{guerrier2.Name} attaque et inflige {damage} points de dégâts à {YourHero.Name}");
                GreenColors();
                Console.WriteLine($"{YourHero.Name} a maintenant {YourHero.PV} PV");
                Console.WriteLine("");
            }
            else if (keyInfo.Key == ConsoleKey.F)
            {
                Console.Clear();
                Console.WriteLine("Reset le jeux...");
        
                YourHero.Reset();
                guerrier2.Reset();
        
                Console.WriteLine($"{YourHero.Name} et {guerrier2.Name} on reset leur point de vie.");
                Console.WriteLine("Retour au menu dans 3 seconds...");
        
                Thread.Sleep(3000);
                Console.Clear();
                Menu(); 
            }
            else
            {
                RedColors();
                Console.WriteLine("Input not valid !");
                WhiteColors();
            }
            
            if (YourHero.PV == 0 || guerrier2.PV == 0)
            {
                if (YourHero.PV == 0)
                {
                    Console.Clear();
                    RedColors();
                    Console.Beep();
                    Console.WriteLine($"\n\n{guerrier2.Name} à Vaincue {YourHero.Name}");
                }
                else if (guerrier2.PV == 0)
                {
                    Console.Clear();
                    GreenColors();
                    Console.Beep();
                    Console.WriteLine($"\n\n{YourHero.Name} à Vaincue {guerrier2.Name}");  
                }
                isEnd = true;
            }
        }
    }
    
    string CreateCharactere()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("\t--- Create your charactere ---");
        WhiteColors();
        Console.Write("\n\tSelect your name : ");
        string Name = Console.ReadLine();
        if (Name == "")
        {
            RedColors();
            Console.WriteLine("Error ! You can't entry empty.");
            Thread.Sleep(1000);
            Console.ResetColor();
            return CreateCharactere();
        }
        Console.Write("\n\tSelect your type");
        Console.WriteLine("\n\tG: Guerrier, N: Nain, E: Elfe, B: Gimli");
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        if (keyInfo.Key == ConsoleKey.G)
        {
            Console.Clear();
            Console.WriteLine("\nVous avez choisi la classe Guerrier !");
            YourHero = new guerrier(Name);
            Console.WriteLine($"Le guerrier {YourHero.ToString()}.");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        else if (keyInfo.Key == ConsoleKey.N)
        {
            Console.Clear();
            Console.WriteLine("Vous avez choisi la classe Nain !");
            YourHero = new nain(Name);
            Console.WriteLine($"Le nain {YourHero.ToString()}.");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        else if (keyInfo.Key == ConsoleKey.E)
        {
            Console.Clear();
            Console.WriteLine("Vous avez choisi la classe Elfe !");
            YourHero = new elfe(Name);
            Console.Write($"\nL'efle {YourHero.ToString()}.");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        else
        {
            RedColors();
            Console.WriteLine("Input not valid !");
            WhiteColors();
        }

        return "";
    }

    void Menu()
    {
        bool isEnd = false;

        do
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\t --- Warriors Duel ---");
            Console.WriteLine($"\tYour charactere : {YourHero.ToString()}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\tStart Battle\t\t1");
            Console.WriteLine("\tRecreate a charactere\t2");
            
            Console.Write("\nSelect menu : ");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.D1)
            {
                isEnd = true;
                Battle();
            }
            else if (keyInfo.Key == ConsoleKey.D2)
            {
                isEnd = true;
                CreateCharactere();
            }
            else
            {
                Console.Clear();
                RedColors();
                Console.WriteLine("Input not valid !");
                WhiteColors();
            }
        } while (!isEnd);
    }
    
    CreateCharactere();
   

    #region Libraries
    void RedColors()
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }
    void GreenColors()
    {
        Console.ForegroundColor = ConsoleColor.Green;
    }
    void WhiteColors()
    {
        Console.ForegroundColor = ConsoleColor.White;
    }
    void YellowColors()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
    }
    #endregion