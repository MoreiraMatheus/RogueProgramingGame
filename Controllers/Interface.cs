namespace RogueProgramingGame.Controllers;
static class Interface{
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
            InimigoAtual.ShowEnemyStats();
            JogadorAtual.ShowPlayerStats();
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