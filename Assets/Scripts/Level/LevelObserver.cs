using SnakesNLadders.Assets.Scripts.CharacterStates;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Level
{
    public class LevelObserver : MonoBehaviour
    {
        [SerializeField] CharacterStates.CharacterMain _character;

        public delegate void TransitionNextLevel();
        public static event TransitionNextLevel OnTransitionNextLevel;
        /*
        public delegate void ExitPreviousLevel();
        public static event ExitPreviousLevel OnExitPreviousLevel;*/

        private readonly string _characterTag = "Player";
        private readonly Vector3 _leap = new Vector3(0, 15, 0);


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == _characterTag)
            {
                transform.position += _leap;
                OnTransitionNextLevel?.Invoke();
            }
        }


        /*private void OnTriggerExit2D(Collider2D collision)
        {
            OnExitPreviousLevel?.Invoke();
            Debug.Log(collision.gameObject.name);
        }*/
    }
}