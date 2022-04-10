using SnakesNLadders.Assets.Scripts.Character.CharacterStates;
using SnakesNLadders.Assets.Scripts.Interactables;
using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Friends.ScreenSnakes
{
    public class ScreenSpawnerRight : MonoBehaviour
    {
        [SerializeField] private InteractableScreenSnake[] _interactablePrefabs;
        [SerializeField] private StateTriggerDownfall _character;

        [SerializeField] private float _waitForSec = 15f;

        private ConcreteScreenSpawner _spawner;
        private int _poolCount = 5;
        private WaitForSeconds _waitFor;
        private Transform _parent;
        private bool _autoExpand = false;

        private Quaternion _rotation;
        private bool _flipHor = false;
        private bool _flipVer = false;
        private Vector3 _offsetPosition;

        private bool _isSnakeActivate = true;

        private Vector3 _targetAppearance;
        private float _snakeActiveSpeed = 2f;
        private float _snakeAnimationDuration = 3.5f;



        private void OnEnable()
        {
            _character.OnCharacterDisable += PauseSnakes;

        }


        private void Awake()
        {
            _targetAppearance = new Vector3(-15f, 0, 0f);

            _waitFor = new WaitForSeconds(_waitForSec);

            _parent = transform;

            _spawner = new ConcreteScreenSpawner(_interactablePrefabs, _poolCount, _parent, _autoExpand);
            _spawner.SpawnerInstanceTemplate();
        }


        private void Start()
        {
            StartCoroutine(SnakeActivate());
        }


        private void PauseSnakes()
        {
            _isSnakeActivate = false;
        }


        private IEnumerator SnakeActivate()
        {
            for (int i = 0; i < _poolCount; i++)
            {
                if (_isSnakeActivate)
                {
                    yield return _waitFor;

                    float offsetY = Random.Range(-7, 10);
                    float offsetZ = Random.Range(-1, 1);
                    _offsetPosition = new Vector3(0f, offsetY, offsetZ);

                    StartCoroutine(SetActiveCoroutine(_offsetPosition, _rotation, _flipHor, _flipVer));

                    yield return _waitFor;
                }
            }
        }


        public IEnumerator SetActiveCoroutine(Vector3 offsetPosition, Quaternion rotation, bool flipHor, bool flipVer)
        {
            var activeObject = _spawner.ConcreteSpawnerActivate(offsetPosition, rotation, flipHor, flipVer);
            var interactable = activeObject.gameObject.GetComponent<InteractableScreenSnake>();
            interactable.PopulationActivate(_targetAppearance, _snakeActiveSpeed, _snakeAnimationDuration);


            yield return null;

        }


        private void OnDisable()
        {
            _character.OnCharacterDisable -= PauseSnakes;

        }
    }
}