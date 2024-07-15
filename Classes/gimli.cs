using Duels_de_Guerriers;
public class gimli : guerrier
{
    private int _pvShield;
        
    public int Shield { get => _pvShield; set => _pvShield = Math.Max(0, Math.Min(value, 50)); }
        
    public gimli(string name) : base(name)
    {
        Shield = 25;
    }
    
    public override string ToString()
    {
        return $"{base.ToString()}, Bouclier : {Shield}";
    }

    public override int Attack()
    {
        Random random = new Random();
            
        if (random.Next(1, 101) <= 20)
        {
            Console.WriteLine($"{Name} rate son attaque !");
            return 0;
        }
        
        int damage = random.Next(0, 16);
        int damage2 = random.Next(0, 16) + damage; 
        Console.WriteLine($"{Name} attaque et inflige {damage2} de dégâts !");
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
