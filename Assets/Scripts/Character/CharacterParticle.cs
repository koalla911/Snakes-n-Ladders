using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Character.CharacterStates
{
    public class CharacterParticle : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _build;

        private void BuildParticleStart()
        {
            _build.Play();
        }
        
    }
}