using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.CharacterStates
{
    public class CharacterBehaviorJump : ICharacterBehavior
    {
        private readonly string _animTransitionBool = "_isOnGround";

        private readonly float _jumpHeight = 3.1f;

        public void EnterState(CharacterMain character)
        {
            Rigidbody2D characterRigidbody = character.GetComponent<Rigidbody2D>();
            Animator animator = character.GetComponent<Animator>();

            Jump(characterRigidbody);

            animator.SetBool(_animTransitionBool, false);
        }


        private void Jump(Rigidbody2D rigidbody)
        {
            float jumpForce = Mathf.Sqrt(_jumpHeight * -2 * (Physics2D.gravity.y * rigidbody.gravityScale));
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        }


        public void ExitState()
        {

        }

    }
}