namespace RogueProgramingGame.Controllers; 
public static class BattleSystem {
    public static void Battle(Models.Player player, Models.Enemy enemy, string battleMessage) {
        Models.Enums.BattleOptions battleOptionChoiced;

        while (true) {
            battleOptionChoiced = Interface.BattleChoices(player, enemy);
            if (battleOptionChoiced == Models.Enums.BattleOptions.Lutar) {
                View.Interface.Header();
                View.Interface.Await("Você acertou o seu inimigo.");
                enemy.Damaged(player.Str);
                if (enemy.Hp == 0) {
                    //Console.WriteLine();
                    View.Interface.Await("Você venceu, o seu inimigo foi derrotado!");
                    break;
                }
            }
            else if (battleOptionChoiced == Models.Enums.BattleOptions.Aguardar) {
                View.Interface.Header();
                View.Interface.Await("O Inimigo te encara, desconfiado.");
            }
            else if (battleOptionChoiced == Models.Enums.BattleOptions.Correr) {
                View.Interface.Header();
                View.Interface.Await("Você fugiu da luta");
                break;
            }
            else if (battleOptionChoiced == Models.Enums.BattleOptions.Inventario) {
                View.Interface.Header();
                View.Interface.Await("Nada na bolsa");
                break;
            }
            player.Damaged(enemy.Str);
        }
    }
}
