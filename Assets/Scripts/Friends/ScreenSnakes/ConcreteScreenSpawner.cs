using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Friends.ScreenSnakes
{
    public class ConcreteScreenSpawner : AbstractScreenSpawner
    {
        private ConcreteSpawner _spawner;
        private MonoBehaviour[] _interactablePrefabs;
        private int _poolCount;
        private Transform _parent;
        private bool _autoExpand;
        public int Count { get { return _poolCount; } }

        public override ConcreteSpawner Spawner { get { return _spawner; } }


        public ConcreteScreenSpawner(MonoBehaviour[] interactablePrefabs, int poolCount, Transform parent, bool autoExpand)
        {
            _interactablePrefabs = interactablePrefabs;
            _poolCount = poolCount;
            _parent = parent;
            _autoExpand = autoExpand;
        }


        protected override void ConcreteSpawnerInstance()
        {
            _spawner = new ConcreteSpawner(_interactablePrefabs, _poolCount, _parent, _autoExpand);
            _spawner.PoolInstanceTemplate();
        }


        public MonoBehaviour ConcreteSpawnerActivate(Vector3 offsetPosition, Quaternion angle, bool flipHor, bool flipVer)
        {
            MonoBehaviour activeObject = _spawner.PoolActivateTemplate(_parent.position + offsetPosition, angle, flipHor, flipVer);
            return activeObject;
        }
    }
}