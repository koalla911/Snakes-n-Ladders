using SnakesNLadders.Assets.Scripts.Friends.ScreenSnakes;
using SnakesNLadders.Assets.Scripts.Interactables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Pooler.PoolerPot
{
    public class PoolActivatePot : MonoBehaviour
    {
        [SerializeField] private InteractableVase[] _vasePrefab;
        [SerializeField] private ActiveCoin[] _itemPrefab;
        [SerializeField] private Transform[] _activatePoints;
        [SerializeField] private bool _autoExpand;
        [SerializeField] private int _activatePercent = 50;

        [SerializeField] private SoundEffectItem[] _potSoundPrefab;
        [SerializeField] private SoundEffectItem[] _itemSoundPrefab;
        private ConcreteSpawner _poolSoundPot;
        private ConcreteSpawner _poolSoundItem;

        private ConcreteSpawner _poolPot;
        private ConcreteSpawner _poolItem;
        private int[] _randomPointArray;
        private int _poolCountPot;
        private int _poolCountItem = 30;

        private WaitForSeconds _activateTime;
        private GameObject _playerCollectible;
        private int _numberOfActiveItems;
        private readonly string _playerTag = "Player";



        private void Awake()
        {
            _activateTime = new WaitForSeconds(0.03f);
            _playerCollectible = GameObject.FindGameObjectWithTag(_playerTag);

            _poolCountPot = _activatePoints.Length;
            _numberOfActiveItems = _poolCountItem / _activatePoints.Length;

            _poolPot = new ConcreteSpawner(_vasePrefab, _poolCountPot, transform, false);
            _poolItem = new ConcreteSpawner(_itemPrefab, _poolCountItem, transform, false);
            _poolPot.PoolInstanceTemplate();
            _poolItem.PoolInstanceTemplate();

            _poolSoundPot = new ConcreteSpawner(_potSoundPrefab, _poolCountPot, transform, false);
            _poolSoundItem = new ConcreteSpawner(_itemSoundPrefab, _poolCountItem, transform, false);
            _poolSoundPot.PoolInstanceTemplate();
            _poolSoundItem.PoolInstanceTemplate();

            _randomPointArray = new int[_activatePoints.Length];

            Activate();
        }


        public void Activate()
        {
            GetFreePot();
        }


        public void Disactivate()
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.activeInHierarchy)
                {
                    child.gameObject.SetActive(false);
                }
            }
        }


        private void RandomPointArray()
        {
            for (int i = 0; i < _activatePoints.Length; i++)
            {
                int random = Random.Range(0, 100);
                _randomPointArray[i] = random;

                //Debug.Log(_randomPointArray[i]);
            }
        }



        private void GetFreePot()
        {
            RandomPointArray(); 

            for (int i = 0; i < _activatePoints.Length; i++)
            {
                if (_randomPointArray[i] < _activatePercent)
                {
                    MonoBehaviour potActive = _poolPot.PoolActivateTemplate(_activatePoints[i].position);
                }
            }
        }


        public void ItemActivate(Transform potTransform)
        {
            StartCoroutine(SetActiveCoroutineCoin(potTransform, _playerCollectible.transform));
        }
        
        
        public void ItemActivateSound()
        {
            _poolSoundItem.PoolActivateTemplate(transform.position);
        }


        public IEnumerator SetActiveCoroutineCoin(Transform parentPosition, Transform targetPosition)
        {
            for (int i = 0; i < _numberOfActiveItems; i++)
            {
                MonoBehaviour itemActive = _poolItem.PoolActivateTemplate(parentPosition.position, Quaternion.identity, false, false);
                ActiveCoin coin = itemActive.gameObject.GetComponent<ActiveCoin>();

                yield return _activateTime;

                coin.CollectibleMovement(targetPosition);

                yield return _activateTime;
            }

            yield break;
        }
    }
}