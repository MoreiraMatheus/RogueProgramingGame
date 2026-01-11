namespace RogueProgramingGame;
public class Program {

    static void Main() {
        MenuOptions EscolhaMenu =  Interface.MenuChoices();

        if (EscolhaMenu == MenuOptions.Novo_Jogo) {
            NewGame.Start();
        }
        else if (EscolhaMenu == MenuOptions.Carregar) {
            LoadGame.Load();
        }
        else if (EscolhaMenu == MenuOptions.Sair) {
            ExitGame.SayGoodbye();
        }

        Interface.Await("\nFim do programa");
    }
}