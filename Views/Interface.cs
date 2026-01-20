namespace RogueProgramingGame.View;

static class Interface {

    static public void Divider(int tamanho = 50) {
        for (int i = 0; i < tamanho; i++) {
            Console.Write("-");
        }
        Console.Write("\n");
    }

    static public void Header() {
        Console.Clear();
        Divider();
        Console.WriteLine("\t\tRogue Programing Game\n");
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
    
    public static void ShowChoices(string[] options, string currentOption) {
        Header();
        foreach (string option in options) {
            if (option == currentOption) {
                Console.WriteLine($"--> {option.Replace('_', ' ')}");
            }
            else {
                Console.WriteLine($"    {option.Replace('_', ' ')}");
            }
        }
    }
    public static void ShowChoices(string[] options, string currentOption, bool showHeader) {
        if (showHeader) {
            Header();
        }
        foreach (string option in options) {
            if (option == currentOption) {
                Console.WriteLine($"--> {option.Replace('_', ' ')}");
            }
            else {
                Console.WriteLine($"    {option.Replace('_', ' ')}");
            }
        }
    }
}