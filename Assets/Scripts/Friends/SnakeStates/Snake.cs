using SnakesNLadders.Assets.Scripts.SnakeStates.Coroutine;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.SnakeStates
{
    [RequireComponent(typeof(InitialBehaviorMapSnake))]
    [RequireComponent(typeof(CoroutineMovementSnake))]

    public class Snake : MonoBehaviour
    {
        private InitialBehaviorMapSnake _behaviorMap;

        private ISnakeBehavior _currentBehavior;

        private Rigidbody2D _snakeRigidbody;
        private Transform _snakeTransform;
        private Animator _snakeAnimator;


        private void Awake()
        {
            _behaviorMap = gameObject.GetComponent<InitialBehaviorMapSnake>();
            _snakeRigidbody = gameObject.GetComponent<Rigidbody2D>();
            _snakeTransform = gameObject.GetComponent<Transform>();
            _snakeAnimator = gameObject.GetComponent<Animator>();
        }


        private void SwitchBehavior(ISnakeBehavior newBehaviour)
        {
            if (_currentBehavior != null)
            {
                _currentBehavior.ExitState();
            }

            _currentBehavior = newBehaviour;
            _currentBehavior.EnterState(this, _snakeRigidbody, _snakeTransform, _snakeAnimator);
        }


        internal void SetBehaviorCrawl()
        {
            ISnakeBehavior behavior = _behaviorMap.GetBehaviour<SnakeBehaviorCrawl>();
            SwitchBehavior(behavior);
        }

        internal void SetBehaviorDance()
        {
            ISnakeBehavior behavior = _behaviorMap.GetBehaviour<SnakeBehaviorDance>();
            SwitchBehavior(behavior);
        }
        
        internal void SetBehaviorDrop()
        {
            ISnakeBehavior behavior = _behaviorMap.GetBehaviour<SnakeBehaviorDrop>();
            SwitchBehavior(behavior);
        }
    }
}