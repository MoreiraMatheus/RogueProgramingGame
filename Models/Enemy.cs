namespace RogueProgramingGame.Models;

public class Enemy : Entity {
    //TODO usar as funções presentes na interface da View
    public void ShowEnemyStats(bool ShowVersus = true) {
        View.Interface.TitleBox(Name);
        View.Interface.MenuEmptyLine();
        View.Interface.ShowHP(Hp, MaxHp);
        View.Interface.MenuEmptyLine();
        View.Interface.Divider();
        View.Interface.ShowVersus();
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