using SnakesNLadders.Assets.Scripts.Friends.ScreenSnakes;
using SnakesNLadders.Assets.Scripts.Interactables;
using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts
{
    public class Utils
    {
        public static int ActiveElements { get; set; }

        public static IEnumerator DisableAfterSeconds(float seconds, GameObject obj)
        {
            yield return new WaitForSeconds(seconds);
            obj.SetActive(false);
        }

        public static IEnumerator SmoothTargetMovement(int value, int maxValue, Vector3 source, Vector3 target, float speed, float startLimit)
        {
            while (value < maxValue)
            {
                Vector3 desiredPosition = target;
                Vector3 smoothedPosition = Vector3.Lerp(target, desiredPosition, speed);
                float verticalLimit = Mathf.Clamp(smoothedPosition.y, smoothedPosition.y, smoothedPosition.y);
                source = new Vector3(source.x, verticalLimit, source.z);

                yield return null;
            }

            yield break;
        }


        
    }
}