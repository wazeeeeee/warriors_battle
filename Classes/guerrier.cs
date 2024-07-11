namespace Duels_de_Guerriers;

public class guerrier
{
    #region Attributs

    private string _name;
    private int _pv;
    private int _nbAttack;
    #endregion

    #region Propriétés
    public string Name { get => _name; set => _name = value; }
    public int PV { get => _pv; set => _pv = value; }
    public int NbAttack { get => _nbAttack; set => _nbAttack = value; }
    #endregion
    
    #region Constructeur
    public guerrier(string name)
    {
        Name = name;
        PV = 100;
        NbAttack = 0;
    }
    #endregion

    public override string ToString()
    {
        return $"{Name} à {PV} PV";
    }

    public virtual int Attack()
    {
        Random random = new Random();
        
        if (random.Next(1, 101) <= 20)
        {
            Console.WriteLine($"{Name} rate son attaque ( cheh ) !");
            return 0;
        }
        
        int damage = random.Next(0, 16);
        Console.WriteLine($"{Name} attaque et inflige {damage} points de dégâts.");
        return damage;
    }

    public virtual int Heal()
    {
        Random random = new Random();
        int heal = random.Next(6, 11);
        PV = Math.Min(100, PV + heal);
        return heal;
    }
    
    public virtual guerrier TryTransformToNain()
    {
        Random random = new Random();
        if (random.Next(1, 101) <= 30)
        {
            Console.WriteLine($"{Name} s'est transformé en Nain !");
            return new nain(Name) { PV = this.PV };
        }
        return this;
    }
    
    public virtual guerrier TryTransformToElfe()
    {
        Random random = new Random();
        if (random.Next(1, 101) <= 30)
        {
            Console.WriteLine($"{Name} s'est transformé en Elfe !");
            return new elfe(Name) { PV = this.PV };
        }

        return this;
    }
    
    public virtual void ReceiveDamage(int damage)
    {
        PV = Math.Max(0, PV - damage);
        Console.WriteLine($"{Name} a reçu {damage} points de dégâts. PV restants : {PV}");
    }

    public virtual void Reset()
    {
        PV = 100;
        NbAttack = 0;
    }
    
}