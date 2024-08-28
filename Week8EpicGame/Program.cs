string folderPath = @"C:\data";
string heroFile = "heroes.txt";
string villainFile = "villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));
string[] weapon = { "magic wand", "plastic fork", "banana", "wooden sword" };

string hero = GetRandomValueFromArray(heroes);
string heroWeapon = GetRandomValueFromArray(weapon);
int heroHp = GetCharacterHp(hero);
int maxHeroStrike = heroHp;
Console.WriteLine($"Today {hero} ({heroHp} HP) with {heroWeapon} saves the day!");

string villain = GetRandomValueFromArray(villains);
string villainWeapon = GetRandomValueFromArray(weapon);
int villainHp = GetCharacterHp(villain);
int maxvillainStike = villainHp;
Console.WriteLine($"Today {villain} ({villainHp} HP) with {villainWeapon} tries to take over the world!");

while(villainHp > 0 && heroHp > 0)
{
    heroHp -= Hit(villain, maxvillainStike);
    villainHp -= Hit(hero, maxHeroStrike);
}

if (heroHp > 0)
{
    Console.WriteLine($"{hero} saves the day!");
}
else if (villainHp > 0)
{
    Console.WriteLine("Dark side wins!");
}
else
{
    Console.WriteLine("Draw!");
}

static string GetRandomValueFromArray(string[] values)
{
    Random rnd = new();
    int randomIndex = rnd.Next(0, values.Length);
    return values[randomIndex];
}

static int GetCharacterHp(string characterName)
{
    if (characterName.Length < 10)
    {
        return 10;
    }
    return characterName.Length;
}

static int Hit(string attacker, int maxStike)
{
    Random rnd = new();
    int strike = rnd.Next(0, maxStike);

    if (strike ==  0)
    {
        Console.WriteLine($"{attacker} missed the target!");
    }
    else if (strike == maxStike - 1)
    {
        Console.WriteLine($"{attacker} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{attacker} hit {strike}!");
    }
    return strike;
}
