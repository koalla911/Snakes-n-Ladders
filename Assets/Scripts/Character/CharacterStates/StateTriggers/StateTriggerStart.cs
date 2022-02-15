using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.CharacterStates.StateTriggers
{
    public class StateTriggerStart : MonoBehaviour
    {
        [SerializeField] private CharacterMain _character;

        private void Start()
        {
            _character.SetBehaviorRise();

        }
    }
}