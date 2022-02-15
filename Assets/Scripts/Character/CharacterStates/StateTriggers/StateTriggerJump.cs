using SnakesNLadders.Assets.Scripts.Ladder;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.CharacterStates.StateTriggers
{
    public class StateTriggerJump : MonoBehaviour
    {
        [SerializeField] private bool _isRise;
        [SerializeField] private CharacterMain _character;
        [SerializeField] private Ladder.Ladder _ladder1;
        [SerializeField] private Ladder.Ladder _ladder2;

        private readonly string _animTransitionBool = "_isBuilding";

        private Animator _characterAnimator;

        private void OnEnable()
        {
            _ladder1.OnPartIsBuilded += JumpBehavior;
            _ladder2.OnPartIsBuilded += JumpBehavior;
        }


        private void Awake()
        {
            _characterAnimator = _character.GetComponent<Animator>();
        }


        private void JumpBehavior(bool isFinishStair)
        {

            if (_isRise)
            {
                _character.SetBehaviorJump();

                if (isFinishStair)
                {
                    _characterAnimator.SetBool(_animTransitionBool, false);
                }
                if (!isFinishStair)
                {
                    _characterAnimator.SetBool(_animTransitionBool, true);
                }
            }
        }   


        private void OnDisable()
        {
            _ladder1.OnPartIsBuilded -= JumpBehavior;
            _ladder2.OnPartIsBuilded -= JumpBehavior;

        }
    }
}