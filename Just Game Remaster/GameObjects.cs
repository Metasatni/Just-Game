using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Just_Game_Remaster.Models;

namespace Just_Game_Remaster;

internal class GameObjects
{

    private readonly List<GameObject> _gameObjects;

    public Player Player => (Player)_gameObjects.Single(x => x is Player);

    public GameObjects()
    {

        _gameObjects = new List<GameObject>();

    }

    public void Remove(GameObject gameObject)
    {
        _gameObjects.Remove(gameObject);
    }

    public void Add(GameObject gameObject)
    {
        _gameObjects.Add(gameObject);
    }

    public IReadOnlyList<T> Get<T>() where T : GameObject
    {

        return _gameObjects.OfType<T>().Cast<T>().ToList();

    }

    public IReadOnlyList<GameObject> Get()
    {

        return _gameObjects;

    }

}
