using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.CharacterStates
{
    public class CharacterBehaviorRise : ICharacterBehavior
    {
        private readonly string _animJumpingBool = "_isOnGround";
        private readonly string _animBuildingBool = "_isBuilding";

        public void EnterState(CharacterMain character)
        {
            Animator animator = character.GetComponent<Animator>();
            animator.SetBool(_animJumpingBool, true);
            animator.SetBool(_animBuildingBool, true);
        }


        public void ExitState()
        {
        }
    }
}