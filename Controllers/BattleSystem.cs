namespace RogueProgramingGame.Controllers; 
public static class BattleSystem {
    public static void Battle(Models.Player player, Models.Enemy enemy, string battleMessage) {
        Models.Enums.BattleOptions battleOptionChoiced;

        while (true) {
            battleOptionChoiced = Interface.BattleChoices(player, enemy);

            if (battleOptionChoiced == Models.Enums.BattleOptions.Lutar) {
                Lutar(player, enemy);
            }
            else if (battleOptionChoiced == Models.Enums.BattleOptions.Aguardar) {
                Aguardar();
            }
            else if (battleOptionChoiced == Models.Enums.BattleOptions.Correr) {
                Correr();
                break;
            }
            else if (battleOptionChoiced == Models.Enums.BattleOptions.Inventario) {
                Inventario(player);
            }
            if (enemy.Hp == 0) {
                View.Interface.Await("Você venceu, o seu inimigo foi derrotado!");
                break;
            }
            player.Damaged(enemy.Str);
            View.Interface.Await($"Você foi atingido e recebeu {enemy.Str} de dano");
        }
    }

    private static void Lutar(Models.Player player, Models.Enemy enemy) {
        Console.Clear();
        View.Interface.Header();
        enemy.Damaged(player.Str);
        View.Interface.Await($"Você acertou o seu inimigo.");
        View.Interface.Await($"{enemy.Name} recebeu {player.Str} de dano.");
    }

    private static void Aguardar() {
        Console.Clear();
        View.Interface.Header();
        View.Interface.Await("O Inimigo te encara, desconfiado.");
    }

    private static void Correr() {
        Console.Clear();
        View.Interface.Header();
        View.Interface.Await("Você fugiu da luta e evitou receber dano.");
    }

    private static void Inventario(Models.Player player) {
        Console.Clear();
        View.Interface.Header();
        if (player.BackPack.Length >= 1) {
            Console.WriteLine("Itens na bolsa:");
            View.Interface.ShowBackPackItems(player.BackPack);
            View.Interface.Await();
        }
        else {
            View.Interface.Await("Nada na bolsa.");
        }
    }
}
