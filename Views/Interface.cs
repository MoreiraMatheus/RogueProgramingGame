using System.Reflection;

namespace RogueProgramingGame.View;

static class Interface {

    static public void Divider(int tamanho = 48) {
        Console.Write(" ");
        for (int i = 0; i < tamanho; i++) {
            Console.Write("-");
        }
        Console.Write("\n");
    }

    static public void Header() {
        Console.Clear();
        Divider();
        Console.WriteLine("\n\t\tRogue Programing Game\n");
        Divider();
    }

    static public void Await() {
        while (true) {
            ConsoleKeyInfo keyboardChoice = Console.ReadKey();
            if (keyboardChoice.Key == ConsoleKey.Enter) {
                break;
            }
        }
    }
    static public void Await(string mensagem) {
        Console.WriteLine(mensagem);
         while (true) {
            ConsoleKeyInfo keyboardChoice = Console.ReadKey();
            if (keyboardChoice.Key == ConsoleKey.Enter) {
                break;
            }
        }
    }
    
    static public void MenuEmptyLine() {
        Console.Write("|");
        for (int i = 0; i < 48; i++) {
            Console.Write(" ");
        }
        Console.Write("|\n");
    }

    static public void AddInMenuBox(string content) {
        int tamanhoTexto = content.Length;
        int limiteCaracteres = 46;

        if (tamanhoTexto > limiteCaracteres) {
            content = content.Substring(0, limiteCaracteres - 3);
            content += "...";
        }
        else if (tamanhoTexto < limiteCaracteres) {
            for (int i = 0; i < (limiteCaracteres - tamanhoTexto); i++) {
                content += " ";
            }
        }
        Console.WriteLine($"| {content} |");
    }

    static public void TitleBox(string title) {
        title = title.Trim();
        int tamanhoTexto = title.Length;
        int limiteCaracteres = 43;

        if (tamanhoTexto > limiteCaracteres) {
            title = title.Substring(0, limiteCaracteres - 3);
            title += "...";
        }
        Console.Write($" - {title} --");
        for (int i = 0; i < (limiteCaracteres - tamanhoTexto); i++) {
            Console.Write("-");
        }
        Console.WriteLine();
    }
    static public void TitleBox(Models.Player player) {
        int caracteresLivres = 42;
        caracteresLivres -= (player.Name.Length + player.PlayerClass.Length);
        Console.Write(" - ");
        if (player.Gender == 'F') {
            Console.ForegroundColor = ConsoleColor.Magenta;
        }
        else {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        Console.Write(player.Name);
        Console.ResetColor();
        Console.Write($" - {player.PlayerClass} ");
        for (int i = 0; i < caracteresLivres; i++) {
            Console.Write("-");
        }
        Console.WriteLine();
    }

    static public void ShowVersus() {
        Console.WriteLine("                      ==VS==");
    }

    public static void ShowChoices(string[] options, string currentOption) {
        Header();
        foreach (string option in options) {
            if (option == currentOption) {
                AddInMenuBox($"--> {option.Replace('_', ' ')}");
            }
            else {
                AddInMenuBox($"    {option.Replace('_', ' ')}");
            }
        }
        Divider();
    }
    public static void ShowChoices(string[] options, string currentOption, bool showHeader) {
        if (showHeader) {
            Header();
        }
        foreach (string option in options) {
            if (option == currentOption) {
                AddInMenuBox($"--> {option.Replace('_', ' ')}");
            }
            else {
                AddInMenuBox($"    {option.Replace('_', ' ')}");
            }
        }
        Divider();
    }
}