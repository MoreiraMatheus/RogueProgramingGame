using System.Runtime.CompilerServices;

namespace RogueProgramingGame {
    public class Creature {
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

    public class Player : Creature {
        public char Gender;
        public string PlayerClass;
        public int Xp = 0;

        public void ChoseGender(char newGender) { 
            Gender = newGender;
        }
        public void ChoseGender() {
            int newGender = 1;
            Interface.Choices(ref newGender, ["M", "F"], "Qual seu gênero: ");
            Gender = newGender == 1 ? 'M' : 'F';
        }

        public void ShowPlayerStats() {
            Console.Write(" - ");
            if (Gender == 'F') {
                Console.ForegroundColor = ConsoleColor.Magenta;
            }
            else {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            Console.Write(Name);
            Console.ResetColor();
            Console.Write($" - {PlayerClass} ");
            for (int i = 0; i < 42 - Name.Length - PlayerClass.Length; i++) {
                Console.Write("-");
            }
            Console.WriteLine("\n|                                                |");
            Console.Write("| HP: ");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < Hp; i++) {
                Console.Write("/");
            }
            Console.ResetColor();
            if (Hp != MaxHp) {
                for (int i = 0; i < MaxHp - Hp; i++) {
                    Console.Write("/");
                }
            }
            for (int i = 0; i < 43 - MaxHp; i++) {
                Console.Write(" ");
            }
            Console.Write($"|\n| STR: {Str} DEF: {Def} SPD: {Spd}");
            for (int i = 0; i < 30 - Str.ToString().Length - Def.ToString().Length - Spd.ToString().Length; i++) {
                Console.Write(" ");
            }
            Console.Write("|\n|                                                |\n ");
            for (int i = 0; i < 48; i++) {
                Console.Write("-");
            }
            Console.Write("\n");
        }
    }

    public class Enemy : Creature {
        public void ShowEnemyStats(bool ShowVersus = true) {
            Console.Write($" - {Name} ");
            for (int i = 0; i < 45 - Name.Length; i++) {
                Console.Write("-");
            }
            Console.WriteLine("\n|                                                |");
            Console.Write("| HP: ");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < Hp; i++) {
                Console.Write("/");
            }
            Console.ResetColor();
            if (Hp != MaxHp) {
                for (int i = 0; i < MaxHp - Hp; i++) {
                    Console.Write("/");
                }
            }
            for (int i = 0; i < 43 - MaxHp; i++) {
                Console.Write(" ");
            }
            Console.Write("|\n|                                                |\n ");
            for (int i = 0; i < 48; i++) {
                Console.Write("-");
            }
            Console.Write("\n");

            if (ShowVersus) {
                Console.WriteLine("                      ==VS==");
            }
        }
    }
}
