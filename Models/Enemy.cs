namespace RogueProgramingGame.Models;

public class Enemy : Entity {
    public void ShowStats(bool ShowVersus = true) {
        View.Interface.TitleBox(Name);
        View.Interface.MenuEmptyLine();
        View.Interface.ShowHP(Hp, MaxHp);
        View.Interface.MenuEmptyLine();
        View.Interface.Divider();
        View.Interface.ShowVersus();
    }

    public Enemy() {
        Str = 1;
    }
}