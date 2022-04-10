using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Level 
{
    public class LevelSpawn : MonoBehaviour
    {
        [SerializeField] private LevelActivatorTrigger[] _levels;
        [SerializeField] private int _active;

        private LevelActivatorTrigger[] _levelsActive;

        private PoolMono<LevelActivatorTrigger> _pool;
        private bool _autoExpand = false;
        private int _poolCount = 1;

        private readonly float _gap = 15f;
        private readonly int _meters = 5;
        private int _metersCount = 0;
        private Vector3 _startPosition;

        private LevelActivatorTrigger _startLevel;
        private LevelActivatorTrigger _finishLevel;

        private PoolMono<LevelActivatorTrigger>[] _poolArray;
        private int _levelCount = 0;


        private void OnEnable()
        {
            CameraCollisionDetection.OnNextLevelSpawn += LevelReplace;
        }


        private void Awake()
        {
            _poolArray = new PoolMono<LevelActivatorTrigger>[_levels.Length];

            _startPosition = new Vector3(0, _gap, 0);
            _levelsActive = new LevelActivatorTrigger[_active];

            InstancePooler();

            for (int i = 0; i < _active; i++)
            {
                LevelActivatorTrigger levelActive = _poolArray[i].GetFreeElement();
                levelActive.transform.position = _startPosition;
                _levelsActive[i] = levelActive;

                _startPosition.y += _gap;
                _metersCount += _meters;
                levelActive.SetMeterCount(_metersCount);
            }

            _startLevel = _levelsActive[0];
            _finishLevel = _levelsActive[_levelsActive.Length - 1];
        }


        private void InstancePooler()
        {
            for (int i = 0; i < _levels.Length; i++)
            {
                _pool = new PoolMono<LevelActivatorTrigger>(_levels[i], _poolCount, transform, _autoExpand);
                _poolArray[i] = _pool;
            }
        }


        private void LevelReplace()
        {
            Vector3 startLevelPosition = _startLevel.transform.position;
            Vector3 finishLevelPosition = _finishLevel.transform.position;

            LevelActivatorTrigger startLevelPotActivator = _startLevel.GetComponent<LevelActivatorTrigger>();
            startLevelPotActivator.DisactivatePot();

            startLevelPosition.y = finishLevelPosition.y + _gap;
            _startLevel.transform.position = startLevelPosition;

            _finishLevel = _startLevel;
            LevelActivatorTrigger finishLevelPotActivator = _finishLevel.GetComponent<LevelActivatorTrigger>();
            finishLevelPotActivator.ActivatePot();
            finishLevelPotActivator.SetMeterCount(_meters * _active);


            _levelCount++;

            _startLevel = _levelsActive[_levelCount];


            for (int i = 0; i < _finishLevel.Activators.Length; i++)
            {
                _finishLevel.Activators[i].ActivatedCollision();
            }

            if (_levelCount >= _active - 1)
            {
                _levelCount = -1;
            }
        }


        private void OnDisable()
        {
            CameraCollisionDetection.OnNextLevelSpawn -= LevelReplace;
        }
    }
}
