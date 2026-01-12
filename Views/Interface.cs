namespace RogueProgramingGame;

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
    
    private static void ShowChoices(string[] options, string currentOption) {
        Cabecalho();
        foreach (string option in options) {
            if (option == currentOption) {
                Console.WriteLine($"--> {option.Replace('_', ' ')}");
            }
            else {
                Console.WriteLine($"    {option.Replace('_', ' ')}");
            }
        }
    }
    private static void ShowChoices(string[] options, string currentOption, bool showHeader) {
        if (showHeader) {
            Cabecalho();
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

    //Choices

    static public MenuOptions MenuChoices() {
        string[] listOptions = Enum.GetNames(typeof(MenuOptions));
        MenuOptions optionSelected = MenuOptions.Novo_Jogo;
        int optionToPrint;

        while (true) {
            optionToPrint = (int)optionSelected;
            ShowChoices(listOptions, listOptions[optionToPrint]);

            ConsoleKeyInfo keyboardChoice = Console.ReadKey();
            if (keyboardChoice.Key == ConsoleKey.UpArrow) {
                if (optionSelected > MenuOptions.Novo_Jogo) {
                    optionSelected--;
                }
            }
            else if (keyboardChoice.Key == ConsoleKey.DownArrow) {
                if (optionSelected < MenuOptions.Sair) {
                    optionSelected++;
                }
            }
            else if (keyboardChoice.Key == ConsoleKey.Enter) {
                break;
            }
        }
        return optionSelected;
    }
    
    static public GenderOptions GenderChoices() {
        string[] listOptions = Enum.GetNames(typeof(GenderOptions));
        GenderOptions optionSelected = GenderOptions.Masculino;
        int optionToPrint;

        while (true) {
            optionToPrint = (int)optionSelected;
            ShowChoices(listOptions, listOptions[optionToPrint]);

            ConsoleKeyInfo keyboardChoice = Console.ReadKey();
            if (keyboardChoice.Key == ConsoleKey.UpArrow) {
                if (optionSelected > GenderOptions.Masculino) {
                    optionSelected--;
                }
            }
            else if (keyboardChoice.Key == ConsoleKey.DownArrow) {
                if (optionSelected < GenderOptions.Feminino) {
                    optionSelected++;
                }
            }
            else if (keyboardChoice.Key == ConsoleKey.Enter) {
                break;
            }
        }
        return optionSelected;
    }
    
    static public PlayerClassOptions ClassChoices() {
        string[] listOptions = Enum.GetNames(typeof(PlayerClassOptions));
        PlayerClassOptions optionSelected = PlayerClassOptions.Guerreiro;
        int optionToPrint;

        while (true) {
            optionToPrint = (int)optionSelected;
            ShowChoices(listOptions, listOptions[optionToPrint]);

            ConsoleKeyInfo keyboardChoice = Console.ReadKey();
            if (keyboardChoice.Key == ConsoleKey.UpArrow) {
                if (optionSelected > PlayerClassOptions.Guerreiro) {
                    optionSelected--;
                }
            }
            else if (keyboardChoice.Key == ConsoleKey.DownArrow) {
                if (optionSelected < PlayerClassOptions.Ladino) {
                    optionSelected++;
                }
            }
            else if (keyboardChoice.Key == ConsoleKey.Enter) {
                break;
            }
        }
        return optionSelected;
    }

    static public BattleOptions BattleChoices(Player JogadorAtual, Enemy InimigoAtual) {
        string[] listOptions = Enum.GetNames(typeof(BattleOptions));
        BattleOptions optionSelected = BattleOptions.Lutar;
        int optionToPrint;

        while (true) {
            optionToPrint = (int)optionSelected;
            Cabecalho();
            InimigoAtual.ShowEnemyStats();
            JogadorAtual.ShowPlayerStats();
            ShowChoices(listOptions, listOptions[optionToPrint], false);

            ConsoleKeyInfo keyboardChoice = Console.ReadKey();
            if (keyboardChoice.Key == ConsoleKey.UpArrow) {
                if (optionSelected > BattleOptions.Lutar) {
                    optionSelected--;
                }
            }
            else if (keyboardChoice.Key == ConsoleKey.DownArrow) {
                if (optionSelected < BattleOptions.Inventario) {
                    optionSelected++;
                }
            }
            else if (keyboardChoice.Key == ConsoleKey.Enter) {
                break;
            }
        }
        return optionSelected;
    }
}