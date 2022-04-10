using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.SnakeStates
{
    public class SnakeBehaviorDrop : ISnakeBehavior
    {
		public void EnterState(Snake snake, Rigidbody2D rigidbody, Transform transform, Animator animator)
		{
			transform.rotation = new Quaternion(Random.Range(-90, 90), Random.Range(-90, 90), 0, 0);

			Drop(rigidbody);
		}


		private void Drop(Rigidbody2D rigidbody)
		{
			ScoreModel.Instance.SetScoreValue(ScoreModel.Instance.snakeValue);
			rigidbody.gravityScale = 10;
			Vector2 direction = new Vector2(Random.Range(-5, 3), Random.Range(4, 7));

			rigidbody.AddForce(direction * 300);

		}

		public void ExitState()
        {
        }
    }
}