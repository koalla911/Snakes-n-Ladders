using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Friends.ScreenSnakes
{
    public class ScreenSnakeMovementCoroutine
    {
        internal static IEnumerator ScreenAppearance(GameObject snake, Vector3 targetAppearance, float speed, float animationDuration)
        {
            float t = 0;

            while (t < 1)
            {
                Vector3 sourcePosition = snake.transform.position;
                Vector3 targerPosition = snake.transform.position + targetAppearance;
                snake.transform.position = Vector3.MoveTowards(sourcePosition, Vector3.Lerp(sourcePosition, targerPosition, speed), Time.deltaTime * speed);
                t += Time.deltaTime / animationDuration;

                yield return null;
            }
        }
    }
}