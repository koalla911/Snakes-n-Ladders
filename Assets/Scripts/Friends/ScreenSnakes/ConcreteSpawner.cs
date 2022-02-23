using SnakesNLadders.Assets.Scripts.Pooler;
using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Friends.ScreenSnakes
{
    public class ConcreteSpawner : AbstractSpawner
    {
        private PoolMonoArray<MonoBehaviour> _pool;
        private MonoBehaviour[] _prefabArray;
        private int _count;
        private Transform _prefabTransform;
        private bool _autoExpand;

        public override PoolMonoArray<MonoBehaviour> Pool { get { return _pool; } }


        public ConcreteSpawner(MonoBehaviour[] prefabArray, int count, Transform prefabTransform, bool autoExpand)
        {
            _prefabArray = prefabArray;
            _count = count;
            _prefabTransform = prefabTransform;
            _autoExpand = autoExpand;
        }


        protected override void PoolInstance()
        {
            _pool = new PoolMonoArray<MonoBehaviour>(_prefabArray, _count, _prefabTransform, _autoExpand);
        }
    }
}