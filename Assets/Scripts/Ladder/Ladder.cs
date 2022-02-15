using SnakesNLadders.Assets.Scripts.InteractionAbstract;
using System;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Ladder
{
    public class Ladder : MonoBehaviour
    {
        [SerializeField] private DetectableObjectReaction _character;

        [SerializeField] private bool _isStairsActive;
        [SerializeField] private GameObject[] _stairs;
        [SerializeField] private ParticleSystem _buildParticle;

        public delegate void PartIsBuilded(bool stair);
        public event PartIsBuilded OnPartIsBuilded;

        private Animator _animator;
        private int _stairCount;
        private bool _isFinishStair;

        private void OnEnable()
        {
            _character.OnCharacterDownfall += Pause;
        }


        private void Awake()
        {
            _animator = GetComponent<Animator>();
            DisactiveStairs();
            _stairCount = 0;
        }


        private void Pause(GameObject detected)
        {
            _animator.speed = 0;
        }


        private void ParticleStart()
        {
            _buildParticle.Play();
        }


        private void PartBuilded()
        {
            if (_isStairsActive)
            {
                _stairs[_stairCount].SetActive(true);
                _stairCount++;
            }
            

            _isFinishStair = false;

            if (_stairCount == _stairs.Length)
            {
                _isFinishStair = true;
            }

            OnPartIsBuilded?.Invoke(_isFinishStair);
        }


        private void BuildFinished()
        {
            _animator.speed = 0;
            _stairCount = 0;

            DisactiveStairs();
            _isFinishStair = false;

            OnPartIsBuilded?.Invoke(_isFinishStair);
        }


        private void DisactiveStairs()
        {
            for (int i = 0; i < _stairs.Length; i++)
            {
                _stairs[i].SetActive(false);
            }
        }

        private void OnDisable()
        {
            _character.OnCharacterDownfall -= Pause;
        }
    }
}