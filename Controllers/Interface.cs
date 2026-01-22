namespace RogueProgramingGame.Controllers;
static class Interface{
    // TODO Passar pra cá tudo que tiver a ver com a controler, mas só após refatorar tudo lá na view
    static public EnumType Choices<EnumType>() {
        string[] listOptions = Enum.GetNames(typeof(EnumType));
        EnumType optionSelected = (EnumType)Enum.GetValues(typeof(EnumType)).GetValue(0);
        int optionToPrint;

        while (true) {
            optionToPrint = Convert.ToInt32(optionSelected);
            View.Interface.ShowChoices(listOptions, listOptions[optionToPrint]);

            ConsoleKeyInfo keyboardChoice = Console.ReadKey();
            if (keyboardChoice.Key == ConsoleKey.UpArrow) {
                if (optionToPrint > 0) {
                    optionSelected = (EnumType)Enum.ToObject(typeof(EnumType), optionToPrint - 1);
                }
            }
            else if (keyboardChoice.Key == ConsoleKey.DownArrow) {
                if (optionToPrint < listOptions.Length - 1) {
                    optionSelected = (EnumType)Enum.ToObject(typeof(EnumType), optionToPrint + 1);
                }
            }
            else if (keyboardChoice.Key == ConsoleKey.Enter) {
                break;
            }
        }
        return optionSelected;
    }

    static public Models.Enums.BattleOptions BattleChoices(Models.Player JogadorAtual, Models.Enemy InimigoAtual) {
        string[] listOptions = Enum.GetNames(typeof(Models.Enums.BattleOptions));
        Models.Enums.BattleOptions optionSelected = Models.Enums.BattleOptions.Lutar;
        int optionToPrint;

        while (true) {
            optionToPrint = (int)optionSelected;
            View.Interface.Header();
            InimigoAtual.ShowStats();
            JogadorAtual.ShowStats();
            View.Interface.ShowChoices(listOptions, listOptions[optionToPrint], false);

            ConsoleKeyInfo keyboardChoice = Console.ReadKey();
            if (keyboardChoice.Key == ConsoleKey.UpArrow) {
                if (optionSelected > Models.Enums.BattleOptions.Lutar) {
                    optionSelected--;
                }
            }
            else if (keyboardChoice.Key == ConsoleKey.DownArrow) {
                if (optionSelected < Models.Enums.BattleOptions.Inventario) {
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