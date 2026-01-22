namespace RogueProgramingGame.Controllers;

public static class Game {
    public static void Start() {
        Models.Enums.MenuOptions EscolhaMenu =  Interface.Choices<Models.Enums.MenuOptions>();

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
        Jogador.ShowStats();
        Console.WriteLine($"Você jogará como {Jogador.PlayerClass}, excelente escolha! Agora sim podemos dar inicio a sua jornada.");
        View.Interface.Await();

        //TODO Criar uma forma de gerar 3 inimigos aleatórios

        //Inimigo 1
        Models.Enemy firstEnemy = new Models.Enemy();
        firstEnemy.Name = "Goblin";
        firstEnemy.Str = 1;
        BattleSystem.Battle(Jogador, firstEnemy, "Você está em uma floresta, olha ao seu redor e não vê nada, a não ser um inimigo.\nO que você faz?");

        //Inimigo 2
        Models.Enemy secondEnemy = new Models.Enemy();
        secondEnemy.Name = "Troll";
        secondEnemy.Str = 1;
        BattleSystem.Battle(Jogador, secondEnemy, "Seguindo adiante você encontra com outro inimigo!");

        //Inimigo 3
        Models.Enemy thirdEnemy = new Models.Enemy();
        thirdEnemy.Name = "Golem";
        thirdEnemy.Str = 1;
        BattleSystem.Battle(Jogador, thirdEnemy, "Após derrotar seu segundo inimigo você encontra com seu adversário final!");

        //Fim do jogo
        View.Interface.Header();
        Console.WriteLine("Você chegou até o fim da sua jornada.");
        Jogador.ShowStats();
    }

    public static void LoadGame() {
        //TODO fazer uma forma de retomar o save
        Console.WriteLine("Nada por aqui ainda.");
    }

    public static void ExitGame() {
        //TODO fazer os 3 pontinhos piscarem como se estivesse carregando
        Console.WriteLine("Saindo...");
    }
}