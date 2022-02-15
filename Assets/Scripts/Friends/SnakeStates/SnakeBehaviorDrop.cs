using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.SnakeStates
{
    public class SnakeBehaviorDrop : ISnakeBehavior
    {
        private int _snakeValue = 1;


        public void EnterState(Snake snake)
        {
            Rigidbody2D snakeRigidbody = snake.gameObject.GetComponent<Rigidbody2D>();

            Transform snakeTransform = snake.gameObject.GetComponent<Transform>();
            snakeTransform.rotation = new Quaternion(Random.Range(-90, 90), Random.Range(-90, 90), 0, 0);

            Drop(snakeRigidbody);

            SingletoneData.SingletoneDataInstance.SetScoreValue(_snakeValue);

        }


        private void Drop(Rigidbody2D rigidbody)
        {
            rigidbody.gravityScale = 10;
            Vector2 direction = new Vector2(Random.Range(-5, 3), Random.Range(4, 7));

            rigidbody.AddForce(direction * 300);

        }

        public void ExitState()
        {
        }
    }
}