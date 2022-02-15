using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.CharacterStates
{
    public class CharacterBehaviorDownfall : ICharacterBehavior
    {
        private readonly string _animTransitionBool = "_isFalling";

        public void EnterState(CharacterMain character)
        {
            SpriteRenderer spriteRenderer = character.GetComponent<SpriteRenderer>();
            Rigidbody2D characterRigidbody = character.GetComponent<Rigidbody2D>();
            BoxCollider2D characterCollider = character.GetComponent<BoxCollider2D>();
            Animator animator = character.GetComponent<Animator>();
            animator.SetBool(_animTransitionBool, true);
            characterCollider.enabled = false;
            spriteRenderer.color = new Color(1, 1, 1);
        }

        public void ExitState()
        {
        }
    }
}