using SnakesNLadders.Assets.Scripts.Interactables;
using SnakesNLadders.Assets.Scripts.Level;
using SnakesNLadders.Assets.Scripts.Pooler;
using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Friends.ScreenSnakes
{
    public abstract class AbstractScreenSpawner
    {
        public abstract ConcreteSpawner Spawner { get; }


        public void SpawnerInstanceTemplate()
        {
            ConcreteSpawnerInstance();
        }

        protected abstract void ConcreteSpawnerInstance();
    }
}