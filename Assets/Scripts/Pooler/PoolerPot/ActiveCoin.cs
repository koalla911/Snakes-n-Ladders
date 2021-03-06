using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Pooler.PoolerPot
{
	public class ActiveCoin : MonoBehaviour
	{
		[SerializeField] AnimationCurve _animationCurveY;
		[SerializeField] ParticleSystem _particle;
		[SerializeField] AudioSource _audioCoin;
		[SerializeField] AudioSource _audioActive;

		private SpriteRenderer _sprite;

		private int _coinValue = 3;

		private float _spawnTime = 0.6f;
		private float _speed = .3f;
		private float _flyTime = 0.22f;
		private PoolActivatePot _itemActiveSound;


		private void Awake()
		{
			_itemActiveSound = gameObject.GetComponentInParent<PoolActivatePot>();

		}


		public void CollectibleMovement(Transform target)
		{
			StartCoroutine(MovementToTarget(target));
		}


		private IEnumerator MovementToTarget(Transform targetTransform)
		{
			yield return StartCoroutine(SpawnToTarget());

			yield return StartCoroutine(FlyToTarget(targetTransform));

			ScoreModel.Instance.SetCoinValue(_coinValue);

			gameObject.SetActive(false);
		}


		private IEnumerator SpawnToTarget()
		{
			transform.rotation = new Quaternion(Random.Range(-25, 0), Random.Range(-25, 0), 0, 0);

			float posX = transform.position.x + Random.Range(-1.5f, 1f);
			float posY = transform.position.y + Random.Range(-1.5f, 1f);
			Vector3 randPos = new Vector3(posX, posY, 0);

			float time = 0;

			_audioActive.Play();

			while (time < _spawnTime)
			{
				Vector2 curve = new Vector2(posX, posY + _animationCurveY.Evaluate(time / _speed));

				transform.position = Vector2.Lerp(transform.position, curve, time / _spawnTime);
				time += Time.deltaTime;


				yield return null;
			}
		}


		private IEnumerator FlyToTarget(Transform targetTransform)
		{
			transform.rotation = Quaternion.identity;
			float timeOffset = Random.Range(-0.02f, 0.02f);

			float time = 0;

			while (transform.position != targetTransform.position)
			{
				transform.position = Vector3.MoveTowards(transform.position, Vector3.Lerp(transform.position, targetTransform.position, time / (_flyTime + timeOffset)), time / (_flyTime + timeOffset));
				time += Time.deltaTime;

				yield return null;
			}

			_itemActiveSound.ItemActivateSound();
		}

	}
}