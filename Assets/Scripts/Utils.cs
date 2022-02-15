using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts
{
    public class Utils
    {
        public static IEnumerator DisableAfterSeconds(float seconds, GameObject obj)
        {
            yield return new WaitForSeconds(seconds);
            obj.SetActive(false);
        }
    }
}