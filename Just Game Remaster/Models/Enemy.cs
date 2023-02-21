using Just_Game_Remaster.Engine;

namespace Just_Game_Remaster.Models;

internal class Enemy : Shooter
{
    private Random _random = new Random();
    protected override int _shootingCooldownInMs => 1000;

    public override char Character => 'O';
    public override GameObjectType Type => GameObjectType.Enemy;

    public Enemy(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public override void Tick() {
        Shoot();
        TryMoveTowardsObject(_gameObjects.Player);
    }

    private void Shoot()
    {
        var direction = PathFinder.FindClosestDirection(this, _gameObjects.Player);

        if (CanShoot()) _spawner.SpawnBullet(this, direction);
    }

    private void TryMoveTowardsObject(GameObject gameObject)
    {
        var direction = PathFinder.FindClosestDirection(this, gameObject);

        if (CanMove(direction)) Move(direction);
    }

    protected bool CanMove(Direction direction)
    {
        if (this.WillBeOnObject(_gameObjects.Get(), direction, out var hitResult)) {
            if (hitResult is Player) return false;
        }
        return _random.Next(1, 25) == 3;
    }

    public override void OnShot(Projectile projectile) {
        if(projectile.Shooter == GameObjectType.Enemy) return;
        this.IsDead = true;
        _spawner.SpawnEnemy();
    }

    public override void OnItemPickUp(GameItem gameItem) {
        switch (gameItem) {
            case Mine mine:
                gameItem.IsDead = true;
                _spawner.SpawnMine();
                this.IsDead = true;
                _spawner.SpawnEnemy();
                break;
        }
    }
 } 