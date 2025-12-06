using System;

class Player {
    public string Name;
    public string Gender;
    public string PlayerClass;
    public int Hp = 10;
    public int Str;
    public int Def;
    public int Spd;
}

class RogueProgramingGame {
    static void Main() {
        Player Jogador = new Player();

        while (true) {
            int menu;
            Console.Write("1 - Novo Jogo\n2 - Carregar\n3 - Sair\nSelecione uma opção: ");
            menu = int.Parse(Console.ReadLine());

            if (menu == 1) {
                Console.Clear();
                Console.Write("Digite seu nome: ");
                Jogador.Name = Console.ReadLine();

                Console.Write("Qual seu gênero: ");
                Jogador.Gender = Console.ReadLine();

                Console.WriteLine($"Muito prazer {Jogador.Name}, vamos começar nossa aventura, mas antes escolha sua classe:\n");

                int playerClassChecker;
                while (true) {
                    Console.Write("1 - Guerreiro\n2 - Tank\n3 - Ladino\nSua classe será: ");
                    playerClassChecker = int.Parse(Console.ReadLine());

                    if (playerClassChecker == 1) {
                        Jogador.Hp += 2;
                        Jogador.Str = 5;
                        Jogador.Def = 2;
                        Jogador.Spd = 1;
                        Jogador.PlayerClass = "Guerreiro";
                        break;
                    }
                    else if (playerClassChecker == 2) {
                        Jogador.Hp += 2;
                        Jogador.Str = 2;
                        Jogador.Def = 5;
                        Jogador.Spd = 1;
                        Jogador.PlayerClass = "Tank";
                        break;
                    }
                    else if (playerClassChecker == 3) {
                        Jogador.Hp ++;
                        Jogador.Str = 3;
                        Jogador.Def = 1;
                        Jogador.Spd = 5;
                        Jogador.PlayerClass = "Ladino";
                        break;
                    }
                    else {
                        Console.Clear();
                        Console.WriteLine("Escolha uma classe válida.\n");
                    }
                }

                Console.WriteLine($"Você jogará como {Jogador.PlayerClass}, excelente escolha! Agora sim podemos dar inicio a sua jornada.");
                break;
            }
            else if (menu == 2) {
                Console.WriteLine("Nada por aqui ainda");
                break;
            }
            else {
                break;
            }   
        }

        Console.WriteLine("\nFim do programa");
    }
}