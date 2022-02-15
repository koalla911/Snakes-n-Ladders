using SnakesNLadders.Assets.Scripts.CharacterStates;
using SnakesNLadders.Assets.Scripts.InteractionAbstract;
using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.SnakeStates.Coroutine
{
    public class CoroutineMovementSnake : MonoBehaviour
    {
        private GameObject _character;
        private readonly string _characterTag = "Player";

        private Snake _snake;
        private SnakeStateTrigger _snakeSpawn;
        private DetectorReaction _detectorReaction;

        private bool _isDetect;
        private bool _isDropped;

        private Vector3 _positionOffset;
        private float _rotationSpeed = 5f;

        private void OnEnable()
        {
            _snakeSpawn.OnSnakeSpawned += StartMovement;
            _detectorReaction.OnDetectionRun += Detect;

            _isDetect = false;
            _isDropped = false;
        }


        private void Awake()
        {
            _character = GameObject.FindGameObjectWithTag(_characterTag);
            _snake = this.GetComponent<Snake>();
            _snakeSpawn = this.GetComponent<SnakeStateTrigger>();
            _detectorReaction = this.GetComponent<DetectorReaction>();
        }


        public void StartMovement()
        {
            _positionOffset = new Vector3(Random.Range(-1.1f, 1.1f), Random.Range(-1.3f, 1.3f), 0);
            StartCoroutine(Movement());
        }


        private bool Detect()
        {
            return _isDetect = true;
        }
        
        
        public bool Dropped()
        {
            return _isDropped = true;
        }
        

        internal IEnumerator Movement()
        {
            _snake.SetBehaviorCrawl();

            while (_isDetect != true)
            {
                Vector3 sourcePosition = this.transform.position;
                Vector3 targerPosition = _character.transform.position;
                this.transform.position = Vector3.MoveTowards(sourcePosition, Vector3.Lerp(sourcePosition, targerPosition, 2f), Time.deltaTime * 2f);

                Vector3 vectorToTarget = targerPosition - sourcePosition;
                float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * _rotationSpeed);

                yield return null;
            }

            _snake.SetBehaviorDance();

            while (_isDropped != true)
            {
                _snake.transform.position = _character.transform.position + _positionOffset;

                yield return null;
            }

            yield break;
        }


        private void OnDisable()
        {
            _snakeSpawn.OnSnakeSpawned -= StartMovement;
            _detectorReaction.OnDetectionRun -= Detect;
        }
    }
}