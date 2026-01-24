namespace RogueProgramingGame.Models;

public class Player : Entity {
    public char Gender;
    public string PlayerClass;
    public int Xp = 0;
    public string[] BackPack = ["Poção de cura", "Bomba de fumaça", "Chave do pálio"];

    public void ChoseGender() {
        View.Interface.Header();
        int newGender = (int)Controllers.Interface.Choices <Enums.GenderOptions>();
        Gender = newGender == 0 ? 'M' : 'F';
    }
    public void ChoseGender(char newGender) {
        Gender = newGender;
    }

    public void ChoseName() {
        string PlayerNameChecker;
        while (true) {
            View.Interface.Header();
            Console.Write("Digite seu nome: ");
            PlayerNameChecker = Console.ReadLine();
            PlayerNameChecker = PlayerNameChecker.Trim();
            PlayerNameChecker = PlayerNameChecker.ToLower();
            if (PlayerNameChecker == "") {
                View.Interface.Header();
                View.Interface.Await("O nome do jogador é obrigatório.");
            }
            else if (PlayerNameChecker.Length > 20) {
                View.Interface.Header();
                View.Interface.Await("Por favor, digite um nome menor (limite de 20 caracteres).");
            }
            else {
                PlayerNameChecker = PlayerNameChecker.ToUpper().Substring(0, 1) + PlayerNameChecker.Substring(1, PlayerNameChecker.Length - 1);
                break;
            }
        }
        Name = PlayerNameChecker;
    }

    public void ChoseClass() {
        Enums.PlayerClassOptions playerClass = Controllers.Interface.Choices<Enums.PlayerClassOptions>();

        if (playerClass == Enums.PlayerClassOptions.Guerreiro) {
            PlayerClass = "Guerreiro(a)";
            Hp += 2;
            MaxHp += 2;
            Str = 5;
            Def = 2;
            Spd = 1;
        }
        else if (playerClass == Enums.PlayerClassOptions.Tank) {
            PlayerClass = "Tank";
            Hp += 2;
            MaxHp += 2; 
            Str = 2;
            Def = 5;
            Spd = 1;
        }
        else if (playerClass == Enums.PlayerClassOptions.Ladino) {
            PlayerClass = "Ladino(a)";
            Hp++;
            MaxHp++;
            Str = 3;
            Def = 1;
            Spd = 5;
        }
    }

    public void ShowStats() {
        View.Interface.TitleBox(this);
        View.Interface.MenuEmptyLine();
        View.Interface.ShowHP(Hp, MaxHp);
        View.Interface.AddInMenuBox($"STR: {Str} DEF: {Def} SPD: {Spd}");
        View.Interface.MenuEmptyLine();
        View.Interface.Divider();
    }

    public Player() {
        ChoseName();
        ChoseGender();
        ChoseClass();
    }
}