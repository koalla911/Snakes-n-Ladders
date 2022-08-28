using SnakesNLadders.Assets.Scripts.Level;
using SnakesNLadders.Assets.Scripts.SnakeStates;
using SnakesNLadders.Assets.Scripts.SnakeStates.Coroutine;
using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Pooler
{
	public class PoolActivateCoroutineSnake
	{
		private Transform[] _activatePoints;
		private float _activateSeconds;
		private WaitForSeconds _activateTime;
		private int _poolCount;


		public PoolActivateCoroutineSnake(Transform[] activatePoints, float activateSeconds, int poolCount)
		{
			(_activatePoints, _activateSeconds, _poolCount) = (activatePoints, activateSeconds, poolCount);
			_activateTime = new WaitForSeconds(_activateSeconds);
		}


		internal IEnumerator SetActiveCoroutine(PoolMono<Snake> pool, int[] coefficient, GameObject target)
		{
			for (int j = 0; j < coefficient.Length; j++)
			{
				for (int i = 0; i < coefficient[j]; i++)
				{
					if (!target.activeInHierarchy)
					{
						yield break;

					}
					Snake objectActive = pool.GetFreeElement();
					Rigidbody2D activeRigidBody = objectActive.GetComponent<Rigidbody2D>();
					activeRigidBody.gravityScale = 0;
					objectActive.transform.position = _activatePoints[j].position;

					yield return _activateTime;
				}

				yield return _activateTime;
			}

			yield break;
			
		}

	}
}