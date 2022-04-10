using SnakesNLadders.Assets.Scripts.SnakeStates.Coroutine;
using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Interactables
{
    public class InteractableSnake : MonoBehaviour, IInteractable
    {
        [SerializeField] private ParticleSystem _parcticle;
        [SerializeField] private GameObject _snakeParent;

        private SnakeStates.Snake _snake;
        private CoroutineMovementSnake _movement;


        private void Awake()
        {
            ComponentReference();
        }


        public void ComponentReference()
        {
            _movement = _snakeParent.GetComponent<CoroutineMovementSnake>();
            _snake = _snakeParent.GetComponent<SnakeStates.Snake>();
        }


        public void Interact()
        {
            _snake.SetBehaviorDrop();
            _movement.Dropped();
            _parcticle.Play();
        }

    }
}