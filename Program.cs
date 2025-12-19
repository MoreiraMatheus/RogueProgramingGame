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

    public void ShowEnemyStats() {
        Console.Write($" - {this.Name} ");
        for (int i = 0; i < 45 - this.Name.Length ; i++) {
            Console.Write("-");
        }
        Console.WriteLine("\n|                                                |");
        Console.Write("| HP: ");
        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = 0; i < this.Hp; i++) {
            Console.Write("/");
        }
        Console.ResetColor();
        if (this.Hp != this.MaxHp) {
            for (int i = 0; i < this.MaxHp - this.Hp; i++) {
                Console.Write("/");
            }
        }
        for (int i = 0; i < 43 - this.MaxHp; i++) {
            Console.Write(" ");
        }
        Console.Write("|\n|                                                |\n ");
        for (int i = 0; i < 48; i++) {
            Console.Write("-");
        }
        Console.Write("\n");
        Console.WriteLine("                      ==VS==");
    }

    public void EnemyDamaged(int damage) {
        if (this.Hp <= damage) {
            this.Hp = 0;
        }
        else {
            this.Hp -= damage;
        }
    }
}

class Interface {
    public void Cabecalho(){
        Console.Clear();
        this.Divider();
        Console.WriteLine("\t\tRogue Programing Game\n");
        this.Divider();
    }
    public void Divider(int tamanho = 50) {
        for (int i = 0; i < tamanho; i++) {
            Console.Write("-");
        }
        Console.Write("\n");
    }
    //TODO fazer aqui a função de interagir com as opções nativamente
    public void Choices(int numberChoiced, string[] choices) {
        string mensagemApresentada = "";
        for (int i= 0; i < choices.Length; i++) {
            mensagemApresentada += $"    {i + 1} - {choices[i]}\n";
        }
        while (true) {
            Console.Clear();
            this.Cabecalho();
            Console.WriteLine(mensagemApresentada.Replace($"    {numberChoiced}", $"--> {numberChoiced}"));
            ConsoleKeyInfo keyboardChoice = Console.ReadKey();
            if (keyboardChoice.Key == ConsoleKey.UpArrow) {
                if (numberChoiced > 1) {
                    numberChoiced--;
                }
            }
            else if (keyboardChoice.Key == ConsoleKey.DownArrow) {
                if (numberChoiced < choices.Length) {
                    numberChoiced++;
                }
            }
            else if (keyboardChoice.Key == ConsoleKey.Enter) {
                break;
            }
        }
    }
}

class RogueProgramingGame {
    static void Main() {
        Player Jogador = new Player();
        Interface Tela = new Interface();

        while (true) {
            int menu = 1;
            while (true) {
                Tela.Cabecalho();
                Tela.Choices(menu, ["Novo Jogo", "Carregar", "Sair"]);

                if (menu == 1) {
                    string PlayerNameChecker;
                    while (true) {
                        Tela.Cabecalho();
                        Console.Write("Digite seu nome: ");
                        PlayerNameChecker = Console.ReadLine();
                        PlayerNameChecker = PlayerNameChecker.Trim();
                        PlayerNameChecker = PlayerNameChecker.ToLower();
                        if (PlayerNameChecker == "") {
                            Tela.Cabecalho();
                            Console.WriteLine("O nome do jogador é obrigatório.");
                        }
                        else if (PlayerNameChecker.Length > 20) {
                            Tela.Cabecalho();
                            Console.WriteLine("Por favor, digite um nome menor (limite de 20 caracteres).");
                        }
                        else {
                            PlayerNameChecker = PlayerNameChecker.ToUpper().Substring(0, 1) + PlayerNameChecker.Substring(1, PlayerNameChecker.Length - 1);
                            Jogador.Name = PlayerNameChecker;
                            break;
                        }
                    }

                    int playerGenderChecker = 1;
                    Tela.Cabecalho();
                    Console.WriteLine("Qual seu gênero: ");
                    Tela.Choices(playerGenderChecker, ["M", "F"]);
                    Jogador.Gender = playerGenderChecker == 1 ? 'M' : 'F';

                    int playerClassChecker = 1;
                    while (true) {
                        Tela.Cabecalho();
                        Console.Write($"Certo {Jogador.Name} vamos começar nossa aventura, mas antes escolha sua classe:\n");
                        Tela.Choices(playerClassChecker, ["Guerreiro", "Tank", "Ladino"]);
                        if (playerClassChecker == 1) {
                            Jogador.PlayerClass = "Guerreiro(a)";
                            Jogador.Hp += 2;
                            Jogador.MaxHp += 2;
                            Jogador.Str = 5;
                            Jogador.Def = 2;
                            Jogador.Spd = 1;
                        }
                        else if (playerClassChecker == 2) {
                            Jogador.PlayerClass = "Tank";
                            Jogador.Hp += 2;
                            Jogador.MaxHp += 2;
                            Jogador.Str = 2;
                            Jogador.Def = 5;
                            Jogador.Spd = 1;
                        }
                        else if (playerClassChecker == 3) {
                            Jogador.PlayerClass = "Ladino(a)";
                            Jogador.Hp++;
                            Jogador.MaxHp++;
                            Jogador.Str = 3;
                            Jogador.Def = 1;
                            Jogador.Spd = 5;
                        }
                        break;
                    }
                    while (true) {
                        Tela.Cabecalho();
                        Jogador.ShowPlayerStats();
                        Console.WriteLine($"Você jogará como {Jogador.PlayerClass}, excelente escolha! Agora sim podemos dar inicio a sua jornada.\nTecle ENTER para iniciar.");
                        ConsoleKeyInfo keyboardChoice = Console.ReadKey();
                        if (keyboardChoice.Key == ConsoleKey.Enter) {
                            break;
                        }
                    }
                    //TODO Polir as mensagens de retorno

                    //Inimigo 1
                    Enemy firstEnemy = new Enemy();
                    firstEnemy.Name = "Goblin";
                    firstEnemy.MaxHp = 10;
                    firstEnemy.Hp = 10;
                    int playerChoiceChecker = 1;
                    while (true) {
                        Tela.Cabecalho();
                        Console.WriteLine("Você está em uma floresta, olha ao seu redor e não vê nada, a não ser um inimigo.\nO que você faz?");
                        firstEnemy.ShowEnemyStats();
                        Jogador.ShowPlayerStats();
                        Tela.Choices(playerChoiceChecker, ["Lutar", "Aguardar", "Correr"]);
                        if (playerChoiceChecker == 1) {
                            Tela.Cabecalho();
                            firstEnemy.EnemyDamaged(Jogador.Str);
                            if (firstEnemy.Hp == 0) {
                                Console.WriteLine("Você venceu, o seu inimigo foi derrotado!");
                                break;
                            }
                        }
                        else if (playerChoiceChecker == 2) {
                            Tela.Cabecalho();
                            Console.WriteLine("O Goblin te encara, desconfiado.");
                        }
                        else if (playerChoiceChecker == 3) {
                            Tela.Cabecalho();
                            Console.WriteLine("Você fugiu da luta");
                            break;
                        }
                    }

                    //Inimigo 2
                    Enemy secondEnemy = new Enemy();
                    secondEnemy.Name = "Troll";
                    secondEnemy.MaxHp = 10;
                    secondEnemy.Hp = 10;
                    playerChoiceChecker = 1;
                    while (true) {
                        Tela.Cabecalho();
                        Console.WriteLine("Seguindo adiante você encontra com outro inimigo!");
                        secondEnemy.ShowEnemyStats();
                        Jogador.ShowPlayerStats();
                        Tela.Choices(playerChoiceChecker, ["Lutar", "Aguardar", "Correr"]);
                        if (playerChoiceChecker == 1) {
                            Tela.Cabecalho();
                            secondEnemy.EnemyDamaged(Jogador.Str);
                            if (secondEnemy.Hp == 0) {
                                Console.WriteLine("Você venceu, o seu inimigo foi derrotado!");
                                break;
                            }
                        }
                        else if (playerChoiceChecker == 2) {
                            Tela.Cabecalho();
                            Console.WriteLine("O Troll te encara, desconfiado.");
                        }
                        else if (playerChoiceChecker == 3) {
                            Tela.Cabecalho();
                            Console.WriteLine("Você fugiu da luta");
                            break;
                        }
                    }

                    //Inimigo 3
                    Enemy thirdEnemy = new Enemy();
                    thirdEnemy.Name = "Golem";
                    thirdEnemy.MaxHp = 10;
                    thirdEnemy.Hp = 10;
                    playerChoiceChecker = 1;
                    while (true) {
                        Tela.Cabecalho();
                        Console.WriteLine("Após derrotar seu segundo inimigo você encontra com seu adversário final!");
                        thirdEnemy.ShowEnemyStats();
                        Jogador.ShowPlayerStats();
                        Tela.Choices(playerChoiceChecker, ["Lutar", "Aguardar", "Correr"]);
                        if (playerChoiceChecker == 1) {
                            Tela.Cabecalho();
                            thirdEnemy.EnemyDamaged(Jogador.Str);
                            if (thirdEnemy.Hp == 0) {
                                Console.WriteLine("Você venceu, o seu inimigo foi derrotado!");
                                break;
                            }
                        }
                        else if (playerChoiceChecker == 2) {
                            Tela.Cabecalho();
                            Console.WriteLine("O golem te encara, desconfiado.");
                        }
                        else if (playerChoiceChecker == 3) {
                            Tela.Cabecalho();
                            Console.WriteLine("Você fugiu");
                            break;
                        }
                    }
                    Tela.Cabecalho();
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
        }
        Console.WriteLine("\nFim do programa");
    }
}