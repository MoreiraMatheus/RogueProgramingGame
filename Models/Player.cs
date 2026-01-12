namespace RogueProgramingGame;

public class Player : Entity {
    public char Gender;
    public string PlayerClass;
    public int Xp = 0;

    public void ChoseGender() {
        int newGender = (int)Interface.GenderChoices();
        Gender = newGender == 0 ? 'M' : 'F';
    }
    public void ChoseGender(char newGender) {
        Gender = newGender;
    }

    public void ChoseName() {
        string PlayerNameChecker;
        while (true) {
            Interface.Cabecalho();
            Console.Write("Digite seu nome: ");
            PlayerNameChecker = Console.ReadLine();
            PlayerNameChecker = PlayerNameChecker.Trim();
            PlayerNameChecker = PlayerNameChecker.ToLower();
            if (PlayerNameChecker == "") {
                Interface.Cabecalho();
                Console.WriteLine("O nome do jogador é obrigatório.");
            }
            else if (PlayerNameChecker.Length > 20) {
                Interface.Cabecalho();
                Console.WriteLine("Por favor, digite um nome menor (limite de 20 caracteres).");
            }
            else {
                PlayerNameChecker = PlayerNameChecker.ToUpper().Substring(0, 1) + PlayerNameChecker.Substring(1, PlayerNameChecker.Length - 1);
                Name = PlayerNameChecker;
                break;
            }
        }
    }

    public void ChoseClass() {
        PlayerClassOptions playerClass = Interface.ClassChoices();

        if (playerClass == PlayerClassOptions.Guerreiro) {
            PlayerClass = "Guerreiro(a)";
            Hp += 2;
            MaxHp += 2;
            Str = 5;
            Def = 2;
            Spd = 1;
        }
        else if (playerClass == PlayerClassOptions.Tank) {
            PlayerClass = "Tank";
            Hp += 2;
            MaxHp += 2;
            Str = 2;
            Def = 5;
            Spd = 1;
        }
        else if (playerClass == PlayerClassOptions.Ladino) {
            PlayerClass = "Ladino(a)";
            Hp++;
            MaxHp++;
            Str = 3;
            Def = 1;
            Spd = 5;
        }
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

    public Player() {
        ChoseName();
        ChoseGender();
        ChoseClass();
    }
}