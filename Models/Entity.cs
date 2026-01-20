namespace RogueProgramingGame.Models;

//TODO revisar essa classe e transformar ela em uma classe abstrata ou coisa parecida
public class Entity {
    public string Name;
    public int Hp = 10;
    public int MaxHp = 10;
    public int Str = 0;
    public int Def = 0;
    public int Spd = 0;

    public void ShowStatsSimple() {
        Console.WriteLine(Name);
        Console.WriteLine($"HP: {Hp}/{MaxHp}");
        Console.WriteLine($"STR: {Str}");
        Console.WriteLine($"DEF: {Def}");
        Console.WriteLine($"SPD: {Spd}");
    }

    public void Damaged(int damage) {
        if (Hp <= damage) {
            Hp = 0;
        }
        else {
            Hp -= damage;
        }
    }
}