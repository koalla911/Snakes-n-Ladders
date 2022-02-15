using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Pooler
{
    public class ActivateCollision : MonoBehaviour
    {
        private bool _isTriggered;

        public delegate void ActivateCollisionTrigger();
        public event ActivateCollisionTrigger OnActivateCollisionTrigger;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!_isTriggered)
            {
                if (collision.gameObject.GetComponent<CharacterStates.CharacterMain>())
                {
                    _isTriggered = true;
                    OnActivateCollisionTrigger?.Invoke();
                }

            }
        }

        public void Triggered()
        {
            _isTriggered = false;
        }
    }
}