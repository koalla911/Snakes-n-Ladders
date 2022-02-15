using SnakesNLadders.Assets.Scripts.Level;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Ladder
{
    public class LaddersSwitch : MonoBehaviour
    {
        [SerializeField] private GameObject _ladder1;
        [SerializeField] private GameObject _ladder2;

        [SerializeField] private float _animatorSpeed;

        private Animator _animator1;
        private Animator _animator2;

        private readonly float _gap = 15f;

        private readonly string _ladderAnimationName = "Stairs";


        private void OnEnable()
        {
            LevelObserver.OnTransitionNextLevel += TransitionNextLevel;
        }


        private void TransitionNextLevel()
        {
            _animator1 = _ladder1.GetComponent<Animator>();
            _animator2 = _ladder2.GetComponent<Animator>();

            _animator1.Play(_ladderAnimationName, 0, 0);
            _animator1.speed = _animatorSpeed;

            _ladder1.transform.position = new Vector3(_ladder1.transform.position.x, _ladder2.transform.position.y + _gap, _ladder1.transform.position.z);

            _animator2.speed = 0;

            Switch();
        }


        private void Switch()
        {
            GameObject temporary = _ladder1;
            _ladder1 = _ladder2;
            _ladder2 = temporary;
        }


        private void OnDisable()
        {
            LevelObserver.OnTransitionNextLevel -= TransitionNextLevel;
        }
    }
}
