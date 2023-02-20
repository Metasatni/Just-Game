using Just_Game_Remaster.Engine;

namespace Just_Game_Remaster.Models;

internal class Player : Shooter
{
    private int _hp;
    private const int MAX_HP = 100;
    private const int MOVING_COOLDOWN_IN_MS = 100;
    private readonly GameTimer _movingCooldownTimer = GameTimer.CreateByMs(MOVING_COOLDOWN_IN_MS);

    public override char Character => 'X';
    public override GameObjectType Type => GameObjectType.Player;
    public int Hp { get => _hp; set => _hp = Math.Min(value, MAX_HP); }
    protected override int _shootingCooldownInMs => 100;

    public Player()
    {
        this.X = 1;
        this.Y = 1;
        this.Hp = 100;
        _movingCooldownTimer.Start();
    }

    public override void Tick() {
        ProcessInputs();
    }

    public override bool TryMove(Direction direction) {

        if (!_movingCooldownTimer.TickReady()) return false;

        return base.TryMove(direction);

    }

    private void ProcessInputs() {
        if (Keyboard.IsKeyDown(ConsoleKey.UpArrow)) TryMove(Direction.Up);
        if (Keyboard.IsKeyDown(ConsoleKey.DownArrow)) TryMove(Direction.Down);
        if (Keyboard.IsKeyDown(ConsoleKey.LeftArrow)) TryMove(Direction.Left);
        if (Keyboard.IsKeyDown(ConsoleKey.RightArrow)) TryMove(Direction.Right);
        if (Keyboard.IsKeyDown(ConsoleKey.W)) TryShoot(Direction.Up);
        if (Keyboard.IsKeyDown(ConsoleKey.S)) TryShoot(Direction.Down);
        if (Keyboard.IsKeyDown(ConsoleKey.A)) TryShoot(Direction.Left);
        if (Keyboard.IsKeyDown(ConsoleKey.D)) TryShoot(Direction.Right);
    }

    private void TryShoot(Direction direction) {
        if (CanShoot()) _spawner.SpawnBullet(this, direction);
    }

    public override void OnShot(Projectile projectile) {
        this.Hp -= projectile.Damage;
    }

    public override void OnItemPickUp(GameItem gameItem) {
        switch (gameItem) {
            case Bandage bandage:
                this.Hp += bandage.HealValue;
                gameItem.IsDead = true;
                _spawner.SpawnBandage();
                break;
            case Mine mine:
                this.Hp -= mine.Damage;
                gameItem.IsDead = true;
                _spawner.SpawnMine();
                break;
        }
    }

}
