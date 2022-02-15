using SnakesNLadders.Assets.Scripts.InteractionAbstract;
using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Camera
{
    public class CameraPause : MonoBehaviour
    {
        [SerializeField] private DetectableObjectReaction _character;

        private Animator _animator;
        private bool _startCamera = true;
        private bool _pauseCamera;

        private void OnEnable()
        {
            _character.OnCharacterDownfall += SetActiveCamera;
        }


        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }


        private void SetActiveCamera(GameObject detected)
        {
            if (_startCamera)
            {
                gameObject.transform.position = detected.transform.position;
                _animator.Play("PauseCamera");
            }
            else
            {
                _animator.Play("StartCamera");
            }

            _startCamera = !_startCamera;
        }


        private void OnDisable()
        {
            _character.OnCharacterDownfall -= SetActiveCamera;
        }
    }
}