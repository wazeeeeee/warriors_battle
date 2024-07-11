using Duels_de_Guerriers;


    public class nain : guerrier
    {
        private int _pvShield;
        
        public int Shield { get => _pvShield; set => _pvShield = Math.Max(0, Math.Min(value, 50)); }
        
        public nain(string name) : base(name)
        {
            Shield = 50;
        }
        public override string ToString()
        {
            return $"{base.ToString()}, Bouclier : {Shield}";
        }
        
        public override int Attack()
        {
            Random random = new Random();
            
            if (random.Next(1, 101) <= 15)
            {
                Console.WriteLine($"{Name} rate son attaque !");
                return 0;
            }
        
            int damage = random.Next(0, 16) + 2; 
            Console.WriteLine($"{Name} attaque avec la puissance d'un nain de jardin et inflige {damage} de dégâts !");
            return damage;
        }
        
        public override void ReceiveDamage(int damage)
        {
            int damageToShield = Math.Min(damage, Shield);
            Shield -= damageToShield;
            int remainingDamage = damage - damageToShield;

            if (remainingDamage > 0)
            {
                base.ReceiveDamage(remainingDamage);
            }

            Console.WriteLine($"{Name} absorbe {damageToShield} dégâts avec son bouclier. Bouclier : {Shield}");
        }
        
        public override int Heal()
        {
            int healAmount = base.Heal();
            int shieldRepair = new Random().Next(5, 11);
            Shield = Math.Min(50, Shield + shieldRepair);
            Console.WriteLine($"{Name} répare son bouclier de {shieldRepair} points. Bouclier : {Shield}");
            return healAmount;
        }
        
        public override void Reset()
        {
            base.Reset();
            Shield = 50;
        }
    }
