using SnakesNLadders.Assets.Scripts.InteractionAbstract;
using System;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Character
{
    public class CharacterGroundCollider : MonoBehaviour
    {
        [SerializeField] private DetectableObjectReaction _detectableObject;
        [SerializeField] private BoxCollider2D _collider;

        private void OnEnable()
        {
            _detectableObject.OnCharacterDownfall += Downfall;
        }


        private void Downfall(GameObject detected)
        {
            _collider.enabled = false;
        }


        private void OnDisable()
        {
            _detectableObject.OnCharacterDownfall -= Downfall;
        }
    }
}