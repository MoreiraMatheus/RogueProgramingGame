namespace RogueProgramingGame.Models;

public class Enemy : Entity {
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

    public void EnemyBattle(Player Player, string battleMessage) {
        Models.Enums.BattleOptions battleOptionChoiced;

        while (true) {
            battleOptionChoiced = Controllers.Interface.BattleChoices(Player, this);
            if (battleOptionChoiced == Models.Enums.BattleOptions.Lutar) {
                View.Interface.Header();
                Damaged(Player.Str);
                if (Hp == 0) {
                    Console.WriteLine("Você venceu, o seu inimigo foi derrotado!");
                    View.Interface.Await();
                    break;
                }
            }
            else if (battleOptionChoiced == Models.Enums.BattleOptions.Aguardar) {
                View.Interface.Header();
                Console.WriteLine("O Inimigo te encara, desconfiado.");
                View.Interface.Await();
            }
            else if (battleOptionChoiced == Models.Enums.BattleOptions.Correr) {
                View.Interface.Header();
                Console.WriteLine("Você fugiu da luta");
                View.Interface.Await();
                break;
            }
            else if (battleOptionChoiced == Models.Enums.BattleOptions.Inventario) {
                View.Interface.Header();
                Console.WriteLine("Nada na bolsa");
                break;
            }
            Player.Damaged(Str);
        }
    }
}