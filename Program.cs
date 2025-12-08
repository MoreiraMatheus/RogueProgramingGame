using System;
using System.Threading.Channels;

class Player {
    public string Name;
    public char Gender;
    public string PlayerClass;
    public int Hp = 10;
    public int MaxHp = 10;
    public int Str = 0;
    public int Def = 0;
    public int Spd = 0;
    public int Xp = 0;
    public void ShowPlayerStats() {
        //TODO Revisar essa função para poder fechar a caixa de informações do player
        Console.Write(" - ");
        if (this.Gender == 'F') {
            Console.ForegroundColor = ConsoleColor.Magenta;
        }
        else{
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        Console.Write(this.Name);
        Console.ResetColor();
        Console.Write($" - {this.PlayerClass} ");
        for (int i = 0; i< 92 - this.Name.Length - this.PlayerClass.Length; i++) {
            Console.Write("-");
        }
        Console.Write("\n|\n| HP: ");
        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = 0; i<this.Hp; i++) {
            Console.Write("/");
        }
        Console.ResetColor();
        if (this.Hp != this.MaxHp) {
            for (int i = 0; i<this.MaxHp - this.Hp; i++) {
                Console.Write("/");
            }
        }
        Console.WriteLine($"\n| STR: {this.Str} DEF: {this.Def} SPD: {this.Spd}\n|");
        Console.Write(" ");
        for (int i = 0; i < 98; i++) {
            Console.Write("-");
        }
        Console.Write("\n");
    }

    //TODO Criar função para atualizar as informações do jogador
}

class RogueProgramingGame {
    static void Main() {
        Player Jogador = new Player();

        while (true) {
            //TODO Apresentar o menu inicial de forma mais amigável
            int menu;
            Console.Write(" 1 - Novo Jogo\n 2 - Carregar\n 3 - Sair\nSelecione uma opção: ");
            menu = int.Parse(Console.ReadLine());

            if (menu == 1) {
                Console.Clear();

                string PlayerNameChecker;
                while (true) {
                    Console.Write("Digite seu nome: ");
                    PlayerNameChecker = Console.ReadLine();
                    PlayerNameChecker = PlayerNameChecker.Trim();
                    PlayerNameChecker = PlayerNameChecker.ToLower();
                    if (PlayerNameChecker == "") {
                        Console.Clear();
                        Console.WriteLine("O nome do jogador é obrigatório.");
                    }
                    else if (PlayerNameChecker.Length > 20) {
                        Console.Clear();
                        Console.WriteLine("Por favor, digite um nome menor (limite de 20 caracteres).");
                    }
                    else {
                        PlayerNameChecker = PlayerNameChecker.ToUpper().Substring(0,1) + PlayerNameChecker.Substring(1, PlayerNameChecker.Length - 1);
                        Jogador.Name = PlayerNameChecker;
                        break;
                    }
                }

                char playerGenderChecker;
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
                    Console.Write("1 - Guerreiro\n2 - Tank\n3 - Ladino\nSua classe será: ");
                    playerClassChecker = int.Parse(Console.ReadLine());

                    if (playerClassChecker == 1) {
                        Jogador.Hp += 2;
                        Jogador.MaxHp += 2;
                        Jogador.Str = 5;
                        Jogador.Def = 2;
                        Jogador.Spd = 1;
                        Jogador.PlayerClass = "Guerreiro(a)";
                        break;
                    }
                    else if (playerClassChecker == 2) {
                        Jogador.Hp += 2;
                        Jogador.MaxHp += 2;
                        Jogador.Str = 2;
                        Jogador.Def = 5;
                        Jogador.Spd = 1;
                        Jogador.PlayerClass = "Tank";
                        break;
                    }
                    else if (playerClassChecker == 3) {
                        Jogador.Hp ++;
                        Jogador.MaxHp ++;
                        Jogador.Str = 3;
                        Jogador.Def = 1;
                        Jogador.Spd = 5;
                        Jogador.PlayerClass = "Ladino(a)";
                        break;
                    }
                    else {
                        Console.Clear();
                        Console.WriteLine("Escolha uma classe válida.\n");
                    }
                }
                Console.Clear();
                Jogador.ShowPlayerStats();
                Console.WriteLine($"Você jogará como {Jogador.PlayerClass}, excelente escolha! Agora sim podemos dar inicio a sua jornada.\n");
                Console.WriteLine("Você está em uma floresta, olha ao seu redor e não vê nada, a não ser um inimigo, um Goblin!");

                //TODO fazer uma função que simule as lutas contra os inimigos

                //Inimigo 1
                int playerChoiceChecker = 0;
                while (true) {
                    Console.WriteLine("O que você faz?\n1 - Atacar\n2 - Defender");
                    playerChoiceChecker = int.Parse(Console.ReadLine());
                    if (playerChoiceChecker == 1) {
                        Console.Clear();
                        Console.WriteLine("O goblin foi derrotado, parabéns!");
                        break;
                    }
                    else if(playerChoiceChecker == 2){
                        Console.Clear();
                        Console.WriteLine("O Goblin te encara, desconfiado.");
                    }
                    else {
                        Console.Clear();
                        Console.WriteLine("Escolha uma opção válida.");
                    }
                }

                //Inimigo 2
                Console.WriteLine("Seguindo adiante você encontra com outro inimigo, dessa vez um Troll!");
                playerChoiceChecker = 0;
                while (true) {
                    Console.WriteLine("O que você faz?\n1 - Atacar\n2 - Defender");
                    playerChoiceChecker = int.Parse(Console.ReadLine());
                    if (playerChoiceChecker == 1) {
                        Console.Clear();
                        Console.WriteLine("O Troll foi derrotado, parabéns!");
                        break;
                    }
                    else if (playerChoiceChecker == 2) {
                        Console.Clear();
                        Console.WriteLine("O Troll te encara, desconfiado.");
                    }
                    else {
                        Console.Clear();
                        Console.WriteLine("Escolha uma opção válida.");
                    }
                }

                //Inimigo 3
                Console.WriteLine("Após derrotar o troll você encontra com seu inimigo final, um poderoso golem de pedra!");
                playerChoiceChecker = 0;
                while (true) {
                    Console.WriteLine("O que você faz?\n1 - Atacar\n2 - Defender");
                    playerChoiceChecker = int.Parse(Console.ReadLine());
                    if (playerChoiceChecker == 1) {
                        Console.Clear();
                        Console.WriteLine("O golem foi derrotado, parabéns!");
                        break;
                    }
                    else if (playerChoiceChecker == 2) {
                        Console.Clear();
                        Console.WriteLine("O golem te encara, desconfiado.");
                    }
                    else {
                        Console.Clear();
                        Console.WriteLine("Escolha uma opção válida.");
                    }
                }

                Console.WriteLine("Você chegou até o fim da sua jornada.");
                break;
            }
            else if (menu == 2) {
                Console.WriteLine("Nada por aqui ainda");
                break;
            }
            else if (menu == 3) {
                break;
            }   
            else if (menu == 4) {
                Console.WriteLine("Debug, use essa parte do código para testar funções");
            }
        }
        Console.WriteLine("\nFim do programa");
    }
}