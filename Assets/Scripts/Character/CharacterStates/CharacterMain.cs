using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.CharacterStates
{
    [RequireComponent(typeof(InitialBehaviorMap))]
    public class CharacterMain : MonoBehaviour
    {
        private InitialBehaviorMap _behaviorMap;

        private ICharacterBehavior _currentBehavior;

        public delegate void BehaviorRise();
        public event BehaviorRise OnBehaviorRise;
        
        public delegate void BehaviorJump();
        public event BehaviorJump OnBehaviorJump;
        
        public delegate void BehaviorDownfall();
        public event BehaviorDownfall OnBehaviorDownfall;


        private void Awake()
        {
            _behaviorMap = GetComponent<InitialBehaviorMap>();
        }


        private void SwitchBehavior(ICharacterBehavior newBehaviour)
        {
            if (_currentBehavior != null)
            {
                _currentBehavior.ExitState();
            }

            _currentBehavior = newBehaviour;
            _currentBehavior.EnterState(this);
        }


        internal void SetBehaviorStart()
        {
            ICharacterBehavior behavior = _behaviorMap.GetBehaviour<CharacterBehaviorStart>();
            SwitchBehavior(behavior);
        }

        internal void SetBehaviorRise()
        {
            var behavior = _behaviorMap.GetBehaviour<CharacterBehaviorRise>();
            SwitchBehavior(behavior);
            OnBehaviorRise?.Invoke();
        }
        
        internal void SetBehaviorJump()
        {
            var behavior = _behaviorMap.GetBehaviour<CharacterBehaviorJump>();
            SwitchBehavior(behavior);
            OnBehaviorJump?.Invoke();
        }
        
        internal void SetBehaviorDownfall()
        {
            var behavior = _behaviorMap.GetBehaviour<CharacterBehaviorDownfall>();
            SwitchBehavior(behavior);
            OnBehaviorDownfall?.Invoke();
        }
    }
}