using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SnakesNLadders.Assets.Scripts
{
    public class SessionStates : MonoBehaviour
    {
        private string _currentScene;


        private void Awake()
        {
            _currentScene = SceneManager.GetActiveScene().name;
        }


        public void Restart()
        {
            Debug.Log("restart");
            //SceneManager.LoadScene(_currentScene);
        }

        public void Exit()
        {
            Debug.Log("quit");

            //Application.Quit();
        }
    }
}