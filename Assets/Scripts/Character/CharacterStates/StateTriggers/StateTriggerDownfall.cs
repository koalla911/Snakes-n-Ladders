using SnakesNLadders.Assets.Scripts.CharacterStates;
using SnakesNLadders.Assets.Scripts.InteractionAbstract;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Character.CharacterStates
{
    public class StateTriggerDownfall : MonoBehaviour
    {
        public delegate void CharacterDisable();
        public event CharacterDisable OnCharacterDisable;

        private CharacterMain _character;
        private DetectableObjectReaction _detectableObject;


        private void OnEnable()
        {
            _detectableObject.OnCharacterDownfall += Downfall;
        }


        private void Awake()
        {
            _character = GetComponent<CharacterMain>();
            _detectableObject = GetComponent<DetectableObjectReaction>();
        }


        private void Downfall(GameObject detected)
        {
            _character.SetBehaviorDownfall();
		}


		private void OnBecameInvisible()
        {
			OnCharacterDisable?.Invoke();
			gameObject.SetActive(false);
        }


        private void OnDisable()
        {
            _detectableObject.OnCharacterDownfall -= Downfall;
        }
    }
}