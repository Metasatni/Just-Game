namespace Just_Game_Remaster.Models;

internal class Mine : GameItem
{
    public override char Character => '@';
    public override GameObjectType Type => GameObjectType.Mine;
    public int Damage => 20;

    public Mine(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

}