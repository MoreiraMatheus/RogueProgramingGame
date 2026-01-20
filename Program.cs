namespace RogueProgramingGame;
public class Program {

    static void Main() {
        //Controllers.Game.Start();

        Models.Player Jogador = new Models.Player();

        View.Interface.Divider();
        View.Interface.TitleBox(Jogador);
        View.Interface.MenuEmptyLine();

        View.Interface.Await("\nFim do programa");
    }
}