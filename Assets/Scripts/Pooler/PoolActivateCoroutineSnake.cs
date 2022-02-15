using SnakesNLadders.Assets.Scripts.Level;
using SnakesNLadders.Assets.Scripts.SnakeStates;
using SnakesNLadders.Assets.Scripts.SnakeStates.Coroutine;
using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Pooler
{
    public class PoolActivateCoroutineSnake
    {
        public Transform[] ActivatePoints { get; set; }
        public float ActivateTime { get; set; }

        public int PoolCount { get; set; }


        public PoolActivateCoroutineSnake(Transform[] activatePoints, float activateTime, int poolCount)
        {
            (ActivatePoints, ActivateTime, PoolCount) = (activatePoints, activateTime, poolCount);
        }


        internal IEnumerator SetActiveCoroutine(PoolMono<Snake> pool, int[] coefficient)
        {
            for (int j = 0; j < coefficient.Length; j++)
            {
                for (int i = 0; i < coefficient[j]; i++)
                {
                    Snake snakeActive = pool.GetFreeElement();
                    Rigidbody2D snakeActiveRigidBody = snakeActive.GetComponent<Rigidbody2D>();
                    //CoroutineMovementSnake snakeMovement = snakeActive.GetComponent<CoroutineMovementSnake>();
                    snakeActiveRigidBody.gravityScale = 0;
                    snakeActive.transform.position = ActivatePoints[j].position;

                    yield return new WaitForSeconds(ActivateTime);
                }

                yield return new WaitForSeconds(ActivateTime);

            }

            yield break;
        }

    }
}