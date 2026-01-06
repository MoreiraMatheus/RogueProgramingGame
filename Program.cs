using System;
using System.Reflection.Metadata;
using System.Threading.Channels;

public class Creature {
    public string Name;
    public int Hp = 10;
    public int MaxHp = 10;
    public int Str = 0;
    public int Def = 0;
    public int Spd = 0;

    //TODO Criar função que mostra os status
    public void ShowStats() {

    }

    public void Damaged(int damage) {
        if (Hp <= damage) {
            Hp = 0;
        }
        else {
            Hp -= damage;
        }
    }
}

public class Player : Creature{
    public char Gender;
    public string PlayerClass;
    public int Xp = 0;
    public void ShowPlayerStats() {
        Console.Write(" - ");
        if (Gender == 'F') {
            Console.ForegroundColor = ConsoleColor.Magenta;
        }
        else{
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        Console.Write(Name);
        Console.ResetColor();
        Console.Write($" - {PlayerClass} ");
        for (int i = 0; i< 42 - Name.Length - PlayerClass.Length; i++) {
            Console.Write("-");
        }
        Console.WriteLine("\n|                                                |");
        Console.Write("| HP: ");
        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = 0; i<Hp; i++) {
            Console.Write("/");
        }
        Console.ResetColor();
        if (Hp != MaxHp) {
            for (int i = 0; i<MaxHp - Hp; i++) {
                Console.Write("/");
            }
        }
        for (int i = 0; i < 43 - MaxHp; i++) {
            Console.Write(" ");
        }
        Console.Write($"|\n| STR: {Str} DEF: {Def} SPD: {Spd}");
        for (int i = 0; i < 30 - Str.ToString().Length - Def.ToString().Length - Spd.ToString().Length; i++) {
            Console.Write(" ");
        }
        Console.Write("|\n|                                                |\n ");
        for (int i = 0; i < 48; i++) {
            Console.Write("-");
        }
        Console.Write("\n");
    } 
}

public class Enemy:Creature {
    public void ShowEnemyStats(bool ShowVersus = true) {
        Console.Write($" - {Name} ");
        for (int i = 0; i < 45 - Name.Length ; i++) {
            Console.Write("-");
        }
        Console.WriteLine("\n|                                                |");
        Console.Write("| HP: ");
        Console.ForegroundColor = ConsoleColor.Green;
        for (int i = 0; i < Hp; i++) {
            Console.Write("/");
        }
        Console.ResetColor();
        if (Hp != MaxHp) {
            for (int i = 0; i < MaxHp - Hp; i++) {
                Console.Write("/");
            }
        }
        for (int i = 0; i < 43 - MaxHp; i++) {
            Console.Write(" ");
        }
        Console.Write("|\n|                                                |\n ");
        for (int i = 0; i < 48; i++) {
            Console.Write("-");
        }
        Console.Write("\n");

        if (ShowVersus) {
            Console.WriteLine("                      ==VS==");
        }
    }
}

static class Interface {
    static public void Cabecalho(){
        Console.Clear();
        Divider();
        Console.WriteLine("\t\tRogue Programing Game\n");
        Divider();
    }
    static public void Divider(int tamanho = 50) {
        for (int i = 0; i < tamanho; i++) {
            Console.Write("-"); 
        }
        Console.Write("\n");
    }
    static public void Await(bool pedirConfirmacao = true) {
        while (true) {
            if (pedirConfirmacao) {
                Console.WriteLine("Tecle ENTER para prosseguir.");
            }
            ConsoleKeyInfo keyboardChoice = Console.ReadKey();
            if (keyboardChoice.Key == ConsoleKey.Enter) {
                break;
            }
        }
    }

    static public int Choices(int numberChoiced,string[] choices, string message = "", bool showHeader = true) {
        string mensagemApresentada = "";
        for (int i= 0; i < choices.Length; i++) {
            mensagemApresentada += $"    {i + 1} - {choices[i]}\n";
        }
        while (true) {
            if (showHeader) {
                Cabecalho();
            }
            if (message != "") {
                Console.WriteLine(message);
            }
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
        return numberChoiced;
    }

    static public int BatleChoices(int numberChoiced, Player JogadorAtual, Enemy InimigoAtual, string battleMessage="") {
        string mensagemApresentada = "    1 - Lutar\n    2 - Aguardar\n    3 - Correr\n";
        while (true) {
            Cabecalho();
            if (battleMessage != "") {
                Console.WriteLine(battleMessage);
            }
            InimigoAtual.ShowEnemyStats();
            JogadorAtual.ShowPlayerStats();
            Console.WriteLine(mensagemApresentada.Replace($"    {numberChoiced}", $"--> {numberChoiced}"));
            ConsoleKeyInfo keyboardChoice = Console.ReadKey();
            if (keyboardChoice.Key == ConsoleKey.UpArrow) {
                if (numberChoiced > 1) {
                    numberChoiced--;
                }
            }
            else if (keyboardChoice.Key == ConsoleKey.DownArrow) {
                if (numberChoiced < 3) {
                    numberChoiced++;
                }
            }
            else if (keyboardChoice.Key == ConsoleKey.Enter) {
                break;
            }
        }
        return numberChoiced;
    }
}

public class RogueProgramingGame {
    static void Main() {
        Player Jogador = new Player();
        int menu = 1;
        menu = Interface.Choices(menu, ["Novo Jogo", "Carregar", "Sair"]);

        if (menu == 1) {
            string PlayerNameChecker;
            while (true) {
                Interface.Cabecalho();
                Console.Write("Digite seu nome: ");
                PlayerNameChecker = Console.ReadLine();
                PlayerNameChecker = PlayerNameChecker.Trim();
                PlayerNameChecker = PlayerNameChecker.ToLower();
                if (PlayerNameChecker == "") {
                    Interface.Cabecalho();
                    Console.WriteLine("O nome do jogador é obrigatório.");
                }
                else if (PlayerNameChecker.Length > 20) {
                    Interface.Cabecalho();
                    Console.WriteLine("Por favor, digite um nome menor (limite de 20 caracteres).");
                }
                else {
                    PlayerNameChecker = PlayerNameChecker.ToUpper().Substring(0, 1) + PlayerNameChecker.Substring(1, PlayerNameChecker.Length - 1);
                    Jogador.Name = PlayerNameChecker;
                    break;
                }
            }

            int playerGenderChecker = 1;
            Interface.Choices(1, ["M", "F"], "Qual seu gênero: "); ;
            Jogador.Gender = playerGenderChecker == 1 ? 'M' : 'F';

            int playerClassChecker = 1;
            playerClassChecker = Interface.Choices(playerClassChecker, ["Guerreiro", "Tank", "Ladino"], $"Certo {Jogador.Name} vamos começar nossa aventura, mas antes escolha sua classe:");
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

            Interface.Cabecalho();
            Jogador.ShowPlayerStats();
            Console.WriteLine($"Você jogará como {Jogador.PlayerClass}, excelente escolha! Agora sim podemos dar inicio a sua jornada.");
            Interface.Await();

            //Inimigo 1
            Enemy firstEnemy = new Enemy();
            firstEnemy.Name = "Goblin";
            firstEnemy.MaxHp = 10;
            firstEnemy.Hp = 10;
            int playerChoiceChecker = 1;
            string firstBattleMessage = "Você está em uma floresta, olha ao seu redor e não vê nada, a não ser um inimigo.\nO que você faz?";
            while (true) {
                playerChoiceChecker = Interface.BatleChoices(playerChoiceChecker, Jogador, firstEnemy, battleMessage:firstBattleMessage);
                if (playerChoiceChecker == 1) {
                    Interface.Cabecalho();
                    firstEnemy.Damaged(Jogador.Str);
                    if (firstEnemy.Hp == 0) {
                        Console.WriteLine("Você venceu, o seu inimigo foi derrotado!");
                        Interface.Await();
                        break;
                    }
                }
                else if (playerChoiceChecker == 2) {
                    Interface.Cabecalho();
                    Console.WriteLine("O Goblin te encara, desconfiado.");
                    Interface.Await();
                }
                else if (playerChoiceChecker == 3) {
                    Interface.Cabecalho();
                    Console.WriteLine("Você fugiu da luta");
                    Interface.Await();
                    break;
                }
            }

            //Inimigo 2
            Enemy secondEnemy = new Enemy();
            secondEnemy.Name = "Troll";
            secondEnemy.MaxHp = 10;
            secondEnemy.Hp = 10;
            playerChoiceChecker = 1;
            string secondBattleMessage = "Seguindo adiante você encontra com outro inimigo!";
            while (true) {
                playerChoiceChecker = Interface.BatleChoices(playerChoiceChecker, Jogador, secondEnemy, battleMessage:secondBattleMessage);
                if (playerChoiceChecker == 1) {
                    Interface.Cabecalho();
                    secondEnemy.Damaged(Jogador.Str);
                    if (secondEnemy.Hp == 0) {
                        Console.WriteLine("Você venceu, o seu inimigo foi derrotado!");
                        Interface.Await();
                        break;
                    }
                }
                else if (playerChoiceChecker == 2) {
                    Interface.Cabecalho();
                    Console.WriteLine("O Troll te encara, desconfiado.");
                    Interface.Await();
                }
                else if (playerChoiceChecker == 3) {
                    Interface.Cabecalho();
                    Console.WriteLine("Você fugiu da luta");
                    Interface.Await();
                    break;
                }
            }

            //Inimigo 3
            Enemy thirdEnemy = new Enemy();
            thirdEnemy.Name = "Golem";
            thirdEnemy.MaxHp = 10;
            thirdEnemy.Hp = 10;
            playerChoiceChecker = 1;
                string thirdBattleMessage = "Após derrotar seu segundo inimigo você encontra com seu adversário final!";
            while (true) {
                playerChoiceChecker = Interface.BatleChoices(playerChoiceChecker, Jogador, thirdEnemy, battleMessage:thirdBattleMessage);
                if (playerChoiceChecker == 1) {
                    Interface.Cabecalho();
                    thirdEnemy.Damaged(Jogador.Str);
                    if (thirdEnemy.Hp == 0) {
                        Console.WriteLine("Você venceu, o seu inimigo foi derrotado!");
                        Interface.Await();
                        break;
                    }
                }
                else if (playerChoiceChecker == 2) {
                    Interface.Cabecalho();
                    Console.WriteLine("O golem te encara, desconfiado.");
                    Interface.Await();
                }
                else if (playerChoiceChecker == 3) {
                    Interface.Cabecalho();
                    Console.WriteLine("Você fugiu");
                    Interface.Await();
                    break;
                }
            }

            Interface.Cabecalho();
            Console.WriteLine("Você chegou até o fim da sua jornada.");
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