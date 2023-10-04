Console.WriteLine("MAgos, Ninjas y Samurais");

public class Human
{
    public string Name { get; set; }
    public int Strength { get; set; }
    public int Intelligence { get; set; }
    public int Dexterity { get; set; }
    public int Health { get; set; }



    public Human(string name, int str, int intel, int dex, int hp)
    {
        Name = name;
        Strength = str;
        Intelligence = intel;
        Dexterity = dex;
        Health = hp;
    }

    // Build Attack method
    public virtual int Attack(Human target)
    {
        int dmg = Strength * 3;
        target.Health -= dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        return target.Health;
    }
}

public class Wizard : Human
{
    public Wizard() : base("wizard", 5, 25, 5, 50)
    { }

    public override int Attack(Human target)
    {
        int dmg = Intelligence * 3;
        target.Health -= dmg;
        Health += dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        return target.Health;
    }

    public int Heal(Human target)
    {
        int heal = Intelligence * 3;
        target.Health += heal;
        Console.WriteLine($"{Name} healed {target.Name} for {heal} health!");
        return target.Health;
    }
}

public class Ninja : Human
{
    public Ninja() : base("ninja", 15, 15, 75, 100)
    { }

    public override int Attack(Human target)
    {
        int dmg = Dexterity;
        Random rand = new Random();
        if (rand.Next(0, 100) < 20)
        {
            dmg += 10;
        }
        target.Health -= dmg;
        Console.WriteLine($"{Name} attacked {target.Name} for {dmg} damage!");
        return target.Health;
    }

    public int Steal(Human target)
    {
        int dmg = 5;
        target.Health -= dmg;
        Health += dmg;
        Console.WriteLine($"{Name} stole {dmg} health from {target.Name}!");
        return target.Health;
    }
}

public class Samurai : Human
{
    public Samurai() : base("samurai", 20, 10, 5, 200)
    { }

    public override int Attack(Human target)
    {
        base.Attack(target);
        if (target.Health < 50)
        {
            target.Health = 0;
            Console.WriteLine($"{Name} attacked {target.Name} for {target.Health} damage and killed them!");
        }
        return target.Health;
    }

    public int Meditate()
    {
        Health = 200;
        Console.WriteLine($"{Name} meditated and healed to full health!");
        return Health;
    }
}