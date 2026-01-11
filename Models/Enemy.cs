namespace RogueProgramingGame;

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
        int playerChoiceChecker = 1;

        while (true) {
            playerChoiceChecker = Interface.BatleChoices(playerChoiceChecker, Player, this, battleMessage: battleMessage);
            if (playerChoiceChecker == 1) {
                Interface.Cabecalho();
                Damaged(Player.Str);
                if (Hp == 0) {
                    Console.WriteLine("Você venceu, o seu inimigo foi derrotado!");
                    Interface.Await();
                    break;
                }
            }
            else if (playerChoiceChecker == 2) {
                Interface.Cabecalho();
                Console.WriteLine("O Goblin te encara, desconfiado.");
                Interface.Await();
            }
            else if (playerChoiceChecker == 3) {
                Interface.Cabecalho();
                Console.WriteLine("Você fugiu da luta");
                Interface.Await();
                break;
            }
            Player.Damaged(Str);
        }
    }
}