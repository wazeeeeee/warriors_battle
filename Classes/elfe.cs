using Duels_de_Guerriers;


    public class elfe : guerrier
    {
        private int _attack90;
        
        public int Attack90 { get => _attack90; set => _attack90 = value; }
        
        public elfe(string name) : base(name)
        {
            Attack90 = 0;
        }

        public override int Attack()
        {
            Random random = new Random();
        
            if (random.Next(1, 101) <= 10)
            {
                Console.WriteLine($"{Name} rate son attaque ( cheh ) !");
                return 0;
            }
        
            int damage = random.Next(0, 16);
            Console.WriteLine($"{Name} attaque et inflige {damage} points de dégâts.");
            return damage;
        }
    }
