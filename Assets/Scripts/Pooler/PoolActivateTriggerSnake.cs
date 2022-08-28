using SnakesNLadders.Assets.Scripts.Level;
using SnakesNLadders.Assets.Scripts.SnakeStates;
using SnakesNLadders.Assets.Scripts.Character.CharacterStates;
using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Pooler
{
	public class PoolActivateTriggerSnake : MonoBehaviour
	{
		[SerializeField] private ActivateCollision _activatingCollision;
		[SerializeField] private Snake _snake;

		[SerializeField] private bool _autoExpand = false;
		[SerializeField] private Transform[] _activatePoints;
		[SerializeField] private float _activateTime = 1f;
		[SerializeField] private int _poolCount = 3;

		public int PoolCount { get { return _poolCount; } }
		public bool IsTriggered { get { return _isTriggered; } }
		public ActivateCollision ActivateCollision { get { return _activatingCollision; } }

		private bool _isTriggered = false;

		private PoolMono<Snake> _pool;
		private PoolActivateCoroutineSnake _poolInstance;
		private PoolerAlgorithm _poolAlgorithm;
		private int[] _listOfA;

		public SnakePool _poolParent;


		private void OnEnable()
		{
			_activatingCollision.OnActivateCollisionTrigger += OnTriggerActivate;
		}


		private void Awake()
		{
			_poolParent = GameObject.FindGameObjectWithTag("SnakePool").GetComponent<SnakePool>();
			_poolInstance = new PoolActivateCoroutineSnake(_activatePoints, _activateTime, _poolCount);
			_pool = new PoolMono<Snake>(_snake, _poolCount, _poolParent.gameObject.transform, _autoExpand);
			_poolAlgorithm = new PoolerAlgorithm(_activatePoints.Length, _poolCount);
			_listOfA = new int[_activatePoints.Length];
		}


		private void OnTriggerActivate()
		{
			ActivateSnake();
			_activatingCollision.gameObject.SetActive(false);
		}


		public void ActivateSnake()
		{
			_poolAlgorithm.GetListOfACoefficient(_listOfA);

			StartCoroutine(_poolInstance.SetActiveCoroutine(_pool, _listOfA, _poolParent.character.gameObject));
		}


		public void Triggered()
		{
			_isTriggered = false;
		}


		public void ActivatedCollision()
		{
			_activatingCollision.gameObject.SetActive(true);
		}


		private void OnDisable()
		{
			_activatingCollision.OnActivateCollisionTrigger -= OnTriggerActivate;
		}
	}
}