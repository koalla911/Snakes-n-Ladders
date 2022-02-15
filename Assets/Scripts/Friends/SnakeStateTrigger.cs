
using SnakesNLadders.Assets.Scripts.SnakeStates;
using SnakesNLadders.Assets.Scripts.SnakeStates.Coroutine;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts
{
    public class SnakeStateTrigger : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;

        public delegate void SnakeSpawned();
        public event SnakeSpawned OnSnakeSpawned;

        private void Awake()
        {
            _rigidbody = gameObject.GetComponent<Rigidbody2D>();
        }

        private void SpawnEvent()
        {
            OnSnakeSpawned?.Invoke();
        }

        private void OnBecameInvisible()
        {
            if (_rigidbody.gravityScale > 0)
            {
                gameObject.SetActive(false);

            }
        }
    }
}