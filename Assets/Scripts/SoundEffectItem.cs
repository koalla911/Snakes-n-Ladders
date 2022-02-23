using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts
{
    public class SoundEffectItem : MonoBehaviour
    {
        [SerializeField] AudioSource _audio;


        private void OnEnable()
        {
            _audio.Play();
            StartCoroutine(CheckPlaying());
        }


        private IEnumerator CheckPlaying()
        {
            while (true)
            {
                if (!_audio.isPlaying)
                {
                    gameObject.SetActive(false);
                }

                yield return null;
            }
        }
    }
}