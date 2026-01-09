namespace RogueProgramingGame {

    static class Interface {

        static public void Divider(int tamanho = 50) {
            for (int i = 0; i < tamanho; i++) {
                Console.Write("-");
            }
            Console.Write("\n");
        }

        static public void Cabecalho() {
            Console.Clear();
            Divider();
            Console.WriteLine("\t\tRogue Programing Game\n");
            Divider();
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

        static public int Choices(ref int numberChoiced, string[] choices, string message = "", bool showHeader = true) {
            string mensagemApresentada = "";
            for (int i = 0; i < choices.Length; i++) {
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

        static public int MenuChoices(MenuOptions escolha) {
            if (escolha == MenuOptions.NovoJogo) {

            }

            return 1;
        }

        static public int BatleChoices(int numberChoiced, Player JogadorAtual, Enemy InimigoAtual, string battleMessage = "") {
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
}
