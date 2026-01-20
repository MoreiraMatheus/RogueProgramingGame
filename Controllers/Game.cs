namespace RogueProgramingGame.Controllers;

public static class Game {
    public static void Start() {
        //MenuOptions EscolhaMenu = Interface.MenuChoices();
        Models.Enums.MenuOptions EscolhaMenu =  Controllers.Interface.Choices<Models.Enums.MenuOptions>();

        if (EscolhaMenu == Models.Enums.MenuOptions.Novo_Jogo) {
            NewGame();
        }
        else if (EscolhaMenu == Models.Enums.MenuOptions.Carregar) {
            LoadGame();
        }
        else if (EscolhaMenu == Models.Enums.MenuOptions.Sair) {
            ExitGame();
        }
    }

    public static void NewGame() {
        //Criando o jogador
        Models.Player Jogador = new Models.Player();

        View.Interface.Header();
        Jogador.ShowPlayerStats();
        Console.WriteLine($"Você jogará como {Jogador.PlayerClass}, excelente escolha! Agora sim podemos dar inicio a sua jornada.");
        View.Interface.Await();

        //Inimigo 1
        Models.Enemy firstEnemy = new Models.Enemy();
        firstEnemy.Name = "Goblin";
        firstEnemy.Str = 1;
        firstEnemy.EnemyBattle(Jogador, "Você está em uma floresta, olha ao seu redor e não vê nada, a não ser um inimigo.\nO que você faz?");

        //Inimigo 2
        Models.Enemy secondEnemy = new Models.Enemy();
        secondEnemy.Name = "Troll";
        secondEnemy.Str = 1;
        secondEnemy.EnemyBattle(Jogador, "Seguindo adiante você encontra com outro inimigo!");

        //Inimigo 3
        Models.Enemy thirdEnemy = new Models.Enemy();
        thirdEnemy.Name = "Golem";
        thirdEnemy.Str = 1;
        thirdEnemy.EnemyBattle(Jogador, "Após derrotar seu segundo inimigo você encontra com seu adversário final!");

        //Fim do jogo
        View.Interface.Header();
        Console.WriteLine("Você chegou até o fim da sua jornada.");
        Jogador.ShowPlayerStats();
    }

    public static void LoadGame() {
        Console.WriteLine("Nada por aqui ainda.");
    }

    public static void ExitGame() {
        Console.WriteLine("Saindo...");
    }
}