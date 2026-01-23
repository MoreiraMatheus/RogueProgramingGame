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
        Models.Player jogador = new Models.Player();

        View.Interface.Header();
        jogador.ShowStats();
        Console.WriteLine($"Você jogará como {jogador.PlayerClass}, excelente escolha! Agora sim podemos dar inicio a sua jornada.");
        View.Interface.Await();
        
        //Batalhas
        string msgDeBatalha = "";
        string nomeInimigo = "";
        string[] inimigosDisponiveis = { "Golem", "Troll", "Goblin", "Gargula", "Orc", "Slime", "Lobisomem", "Esqueleto", "Dinossauro", "Zumbi" };
        for (int i = 0; i < 5; i++) {
            Models.Enemy enemy = new Models.Enemy();
            Random random = new Random();
            enemy.Name = inimigosDisponiveis[random.Next(0, inimigosDisponiveis.Length)];

            if (i == 0) {
                msgDeBatalha = "Você está em uma floresta, olha ao seu redor e não vê nada, a não ser um inimigo.\nO que você faz?";
            }
            else {
                msgDeBatalha = "Seguindo adiante você encontra com outro inimigo!";
            }

            BattleSystem.Battle(jogador, enemy, msgDeBatalha);
        }

        //Fim do jogo
        View.Interface.Header();
        Console.WriteLine("Você chegou até o fim da sua jornada.");
        jogador.ShowStats();
    }

    public static void LoadGame() {
        //TODO fazer uma forma de retomar o save
        Console.WriteLine("Nada por aqui ainda.");
    }

    public static void ExitGame() {
        Console.Write("Saindo");
        for (int i = 0; i < 3; i++) {
            Thread.Sleep(1000);
            Console.Write(".");
        }
        Thread.Sleep(1000);
    }
}