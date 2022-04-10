using SnakesNLadders.Assets.Scripts.Friends.ScreenSnakes;
using System;
using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Interactables
{
    public class InteractableScreenSnake : MonoBehaviour, IInteractable
    {
        [SerializeField] private ParticleSystem _parcticle;
        public int NumberOfActiveInteract { get; set; }

        private int _hit = 0;
        private Vector3 _offset;
        private Transform _target;
        private float _speed;
        private readonly float _speedIn = 2f;
        private readonly float _speedOut = 10f;
        private float _animationDuration;

        private Vector3 _targetAppearance;
        private bool _isOutOfScreen;


        private void Awake()
        {
            ComponentReference();
        }


        public void ComponentReference()
        {
            _target = GetComponentInParent<Transform>();
        }


        public void Interact()
        {
            _parcticle.Play();
            _hit += 1;

            if (_hit >= 3)
            {
                StartCoroutine(OutOfScreen(_targetAppearance, _speed, _animationDuration));
            }
        }


        private IEnumerator OutOfScreen(Vector3 targetAppearance, float speed, float animationDuration)
        {
            yield return StartCoroutine(ScreenSnakeMovementCoroutine.ScreenAppearance(gameObject, -targetAppearance, speed * _speedOut, animationDuration - 3.0f));

            gameObject.SetActive(false);
        }


        public void PopulationActivate(Vector3 targetAppearance, float speed, float animationDuration)
        {
            _targetAppearance = targetAppearance;
            _speed = speed;
            _animationDuration = animationDuration;

            StartCoroutine(ScreenSnakeMovementCoroutine.ScreenAppearance(gameObject, _targetAppearance, _speed, _animationDuration));
        }

    }
}