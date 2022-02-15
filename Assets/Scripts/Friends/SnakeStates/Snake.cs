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

        private void Awake()
        {
            _behaviorMap = gameObject.GetComponent<InitialBehaviorMapSnake>();
        }

        private void SwitchBehavior(ISnakeBehavior newBehaviour)
        {
            if (_currentBehavior != null)
            {
                _currentBehavior.ExitState();
            }

            _currentBehavior = newBehaviour;
            _currentBehavior.EnterState(this);
        }


        internal void SetBehaviorSpawn()
        {
            ISnakeBehavior behavior = _behaviorMap.GetBehaviour<SnakeBehaviorSpawn>();
            SwitchBehavior(behavior);
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