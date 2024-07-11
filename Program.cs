    using Duels_de_Guerriers;

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
                int damage = YourHero.Attack();
                if (damage > 0)
                {
                    guerrier2.ReceiveDamage(damage);
                }
                
                Console.WriteLine("");
            
                if (guerrier2.PV > 0)
                {
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
                if (YourHero.PV < 100)
                {
                    int healAmount = YourHero.Heal();
                    Console.WriteLine($"{YourHero.Name} se soigne de {healAmount} PV");
                    Console.WriteLine($"{YourHero.Name} a maintenant {YourHero.PV} PV");
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine($"{YourHero.Name} a déjà tous ses PV ({YourHero.PV})");
                    Console.WriteLine("");
                }
                
                int damage = guerrier2.Attack();
                YourHero.ReceiveDamage(damage);
                Console.WriteLine($"{guerrier2.Name} attaque et inflige {damage} points de dégâts à {YourHero.Name}");
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

    void CreateCharactere()
    {
        Console.Clear();
        Console.Write("\t--- Create your charactere ---");
        Console.Write("\n\tSelect your name : ");
        string Name = Console.ReadLine();
        Console.Write("\n\tSelect your type");
        Console.WriteLine("\n\tG: Guerrier, N: Nain, E: Elfe");
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        if (keyInfo.Key == ConsoleKey.G)
        {
            Console.WriteLine("\nVous avez choisi la classe Guerrier !");
            YourHero = new guerrier(Name);
            Console.WriteLine($"Le guerrier {YourHero.ToString()}.");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        else if (keyInfo.Key == ConsoleKey.N)
        {
            Console.WriteLine("Vous avez choisi la classe Nain !");
            YourHero = new nain(Name);
            Console.WriteLine($"Le guerrier {YourHero.ToString()}.");
            Console.ReadKey();
            Console.Clear();
            Menu();
        }
        else if (keyInfo.Key == ConsoleKey.E)
        {
            Console.WriteLine("Vous avez choisi la classe Elfe !");
            YourHero = new elfe(Name);
            Console.WriteLine($"Le guerrier {YourHero.ToString()}.");
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
    }

    void Menu()
    {
        bool isEnd = false;

        do
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("\t --- Warriors Duel ---");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\tStart Battle\t\t1");
            Console.WriteLine("\tCreate a charactere\t2");
            
            Console.WriteLine("\nSelect menu : ");
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
    
    Menu();
   

    #region Libraries
    static void RedColors()
    {
        Console.ForegroundColor = ConsoleColor.Red;
    }
    static void GreenColors()
    {
        Console.ForegroundColor = ConsoleColor.Green;
    }
    static void WhiteColors()
    {
        Console.ForegroundColor = ConsoleColor.White;
    }
    #endregion