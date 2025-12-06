using System;

class Player {
    public string Name;
    public char Gender = 'M';
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
                char playerGenderChecker;
                

                Console.Clear();
                Console.Write("Digite seu nome: ");
                Jogador.Name = Console.ReadLine(); 

                while (true) {
                    Console.Write("Qual seu gênero (M/F): ");
                    playerGenderChecker = (char)Console.Read();
                    Console.ReadLine(); //Limpa o "buffer"

                    if (playerGenderChecker == 'F' || playerGenderChecker == 'f') {
                        Jogador.Gender = 'F';
                        Console.Write("Muito prazer ");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;
                    }
                    else if (playerGenderChecker == 'M' || playerGenderChecker == 'm') {
                        Jogador.Gender = 'M';
                        Console.Write("Muito prazer ");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    }
                    else {
                        Console.WriteLine("Não identificado, por favor digite uma opção válida.\n");
                    }
                }
                Console.Write(Jogador.Name);
                Console.ResetColor();
                Console.Write(" vamos começar nossa aventura, mas antes escolha sua classe:\n");

                int playerClassChecker = 0;
                while (true) {
                    Console.Write("1 - Guerreiro\n2 - Tank\n3 - Ladino\nSua classe será: \n");
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

                //TODO Adicionar uma história bem curta e um sistema de pancadaria
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