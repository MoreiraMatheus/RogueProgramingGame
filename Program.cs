using System;
using System.Reflection.Metadata;
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
        for (int i = 0; i< 42 - this.Name.Length - this.PlayerClass.Length; i++) {
            Console.Write("-");
        }
        Console.WriteLine("\n|                                                |");
        Console.Write("| HP: ");
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
        for (int i = 0; i < 43 - this.MaxHp; i++) {
            Console.Write(" ");
        }
        Console.Write($"|\n| STR: {this.Str} DEF: {this.Def} SPD: {this.Spd}");
        for (int i = 0; i < 30 - this.Str.ToString().Length - this.Def.ToString().Length - this.Spd.ToString().Length; i++) {
            Console.Write(" ");
        }
        Console.Write("|\n|                                                |\n ");
        for (int i = 0; i < 48; i++) {
            Console.Write("-");
        }
        Console.Write("\n");
    } 
}

class Enemy {
    public string Name;
    public int Hp;
    public int MaxHp;
    //TODO criar inimigos aqui

}

class Interface {
    public void Cabecalho(){
        Console.WriteLine("\t\tRogue Programing Game\n");
    }
    public void Divider(int tamanho = 50) {
        for (int i = 0; i < tamanho; i++) {
            Console.Write("-");
        }
        Console.Write("\n");
    }
    public void Choices(int numberChoiced, string[] choices) {
        string mensagemApresentada = "";
        for (int i= 0; i < choices.Length; i++) {
            mensagemApresentada += $"    {i + 1} - {choices[i]}\n";
        }
        Console.WriteLine(mensagemApresentada.Replace($"    {numberChoiced}", $"--> {numberChoiced}"));
    }
}

class RogueProgramingGame {
    static void Main() {
        Player Jogador = new Player();
        Interface Tela = new Interface();
        ConsoleKeyInfo keyboardChoice;

        while (true) {
            int menu = 1;
            Tela.Cabecalho();
            Tela.Choices(menu, ["Novo Jogo", "Carregar", "Sair"]);
            Tela.Divider();
            while (true) {
                keyboardChoice = Console.ReadKey();
                if (keyboardChoice.Key == ConsoleKey.UpArrow) {
                    if (menu > 1) {
                        menu--;
                    }
                    Console.Clear();
                    Tela.Cabecalho();
                    Tela.Choices(menu, ["Novo Jogo", "Carregar", "Sair"]);
                    Tela.Divider();
                }
                else if (keyboardChoice.Key == ConsoleKey.DownArrow) {
                    if (menu < 3) {
                        menu++;
                    }
                    Console.Clear();
                    Tela.Cabecalho();
                    Tela.Choices(menu, ["Novo Jogo", "Carregar", "Sair"]);
                    Tela.Divider();
                }
                else if (keyboardChoice.Key == ConsoleKey.Enter) {
                    Console.Clear();
                    break;
                }
            }

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

                Console.Clear();
                int playerGenderChecker = 1;
                Console.WriteLine("Qual seu gênero: ");
                Tela.Choices(playerGenderChecker, ["M", "F"]);
                while (true) {
                    keyboardChoice = Console.ReadKey();

                    if (keyboardChoice.Key == ConsoleKey.UpArrow) {
                        playerGenderChecker = 1;
                        Console.Clear();
                        Console.WriteLine("Qual seu gênero:");
                        Tela.Choices(playerGenderChecker, ["M", "F"]);
                        Tela.Divider();
                    }
                    else if (keyboardChoice.Key == ConsoleKey.DownArrow) {
                        playerGenderChecker = 2;
                        Console.Clear();
                        Console.WriteLine("Qual seu gênero:");
                        Tela.Choices(playerGenderChecker, ["M", "F"]);
                        Tela.Divider();
                    }
                    else if (keyboardChoice.Key == ConsoleKey.Enter) {
                        Jogador.Gender = playerGenderChecker == 1 ? 'M' : 'F';
                        if (playerGenderChecker == 1) {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                        }
                        break;
                    }
                }

                Console.Write(Jogador.Name);
                Console.ResetColor();
                Console.Write(" vamos começar nossa aventura, mas antes escolha sua classe:\n");

                int playerClassChecker = 0;
                while (true) {
                    //TODO Fazer aqui também a função de apresentar o menu de forma mais agradável
                    Console.Write("1 - Guerreiro\n2 - Tank\n3 - Ladino\nSua classe será: ");
                    playerClassChecker = int.Parse(Console.ReadLine());

                    if (playerClassChecker == 1) {
                        Jogador.PlayerClass = "Guerreiro(a)";
                        Jogador.Hp += 2;
                        Jogador.MaxHp += 2;
                        Jogador.Str = 5;
                        Jogador.Def = 2;
                        Jogador.Spd = 1;
                        break;
                    }
                    else if (playerClassChecker == 2) {
                        Jogador.PlayerClass = "Tank";
                        Jogador.Hp += 2;
                        Jogador.MaxHp += 2;
                        Jogador.Str = 2;
                        Jogador.Def = 5;
                        Jogador.Spd = 1;
                        break;
                    }
                    else if (playerClassChecker == 3) {
                        Jogador.PlayerClass = "Ladino(a)";
                        Jogador.Hp ++;
                        Jogador.MaxHp ++;
                        Jogador.Str = 3;
                        Jogador.Def = 1;
                        Jogador.Spd = 5;
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
                Console.WriteLine("Saindo...");
                break;
            }   

        }
        Console.WriteLine("\nFim do programa");
    }
}