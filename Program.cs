
namespace RogueProgramingGame {
    public class RogueProgramingGame {

        static void Main() {
            Player Jogador = new Player();
            int menu = 1;
            Interface.Choices(ref menu, ["Novo Jogo", "Carregar", "Sair"]);

            if (menu == 1) {
                //Criando o jogador
                Jogador.ChoseName();
                Jogador.ChoseGender();
                Jogador.ChoseClass();

                Interface.Cabecalho();
                Jogador.ShowPlayerStats();
                Console.WriteLine($"Você jogará como {Jogador.PlayerClass}, excelente escolha! Agora sim podemos dar inicio a sua jornada.");
                Interface.Await();

                //Inimigo 1
                Enemy firstEnemy = new Enemy();
                firstEnemy.Name = "Goblin";
                firstEnemy.Str = 1;
                firstEnemy.EnemyBattle(Jogador, "Você está em uma floresta, olha ao seu redor e não vê nada, a não ser um inimigo.\nO que você faz?");

                //Inimigo 2
                Enemy secondEnemy = new Enemy();
                secondEnemy.Name = "Troll";
                secondEnemy.Str = 1;
                secondEnemy.EnemyBattle(Jogador, "Seguindo adiante você encontra com outro inimigo!");

                //Inimigo 3
                Enemy thirdEnemy = new Enemy();
                thirdEnemy.Name = "Golem";
                thirdEnemy.Str = 1;
                thirdEnemy.EnemyBattle(Jogador, "Após derrotar seu segundo inimigo você encontra com seu adversário final!");

                //Fim do jogo
                Interface.Cabecalho();
                Console.WriteLine("Você chegou até o fim da sua jornada.");
                Jogador.ShowPlayerStats();
            }
            else if (menu == 2) {
                Console.WriteLine("Nada por aqui ainda");
            }
            else if (menu == 3) {
                Console.WriteLine("Saindo...");
            }
            Console.WriteLine("\nFim do programa");
        }
    }
}