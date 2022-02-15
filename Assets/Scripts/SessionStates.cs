using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SnakesNLadders.Assets.Scripts
{
    public class SessionStates : MonoBehaviour
    {

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void Exit()
        {
            Application.Quit();
        }
    }
}