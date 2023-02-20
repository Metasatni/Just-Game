namespace Just_Game_Remaster.Models;

internal class Bandage : GameItem
{
    public override char Character => '%';
    public override GameObjectType Type => GameObjectType.Bandage;
    public int HealValue => 20;

    public Bandage(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

}
