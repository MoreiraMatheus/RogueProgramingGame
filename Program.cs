namespace RogueProgramingGame;
public class Program {

    static void Main() {
        Controllers.Game.Start();

        View.Interface.Await("\nFim do programa");
    }
}