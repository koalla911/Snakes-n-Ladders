using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Character.CharacterStates
{
    public class CharacterEffects : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _buildParticle;
        [SerializeField] private AudioSource _buildSound;
        [SerializeField] private AudioSource _jumpSound;

        private void BuildEffectStart()
        {
            _buildParticle.Play();
            _buildSound.Play();
        }
        

        private void JumpEffectStart()
        {
            _jumpSound.Play();
        }
    }
}