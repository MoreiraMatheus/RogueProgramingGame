namespace RogueProgramingGame.Controllers; 
public static class BattleSystem {
    public static void Battle(Models.Player player, Models.Enemy enemy, string battleMessage) {
        Models.Enums.BattleOptions battleOptionChoiced;

        while (true) {
            //TODO apresentar as mensagens sem pular direto pra próxima tela
            battleOptionChoiced = Controllers.Interface.BattleChoices(player, enemy);
            if (battleOptionChoiced == Models.Enums.BattleOptions.Lutar) {
                View.Interface.Header();
                enemy.Damaged(player.Str);
                if (enemy.Hp == 0) {
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
            player.Damaged(enemy.Str);
        }
    }
}
