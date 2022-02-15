using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Pooler.PoolerPot
{
    public class PoolActivateCoin : MonoBehaviour
    {
        [SerializeField] private ActiveCoin _prefab;
        [SerializeField] private int _poolCountCoin = 10;
        [SerializeField] private int _poolCountCoinActive = 10;
        [SerializeField] private bool _autoExpand = false;

        private readonly string _playerTag = "Player";
        private GameObject _playerCollectible;

        private PoolMono<ActiveCoin> _poolCoin;
        private WaitForSeconds _activateTime;
        private Vector2 _coinTarget;


        private void Awake()
        {
            _poolCoin = new PoolMono<ActiveCoin>(_prefab, _poolCountCoin, transform, _autoExpand);
            _playerCollectible = GameObject.FindGameObjectWithTag(_playerTag);
            _activateTime = new WaitForSeconds(0.03f);
        }


        public IEnumerator SetActiveCoroutineCoin()
        {
            for (int i = 0; i < _poolCountCoinActive; i++)
            {
                ActiveCoin coin = _poolCoin.GetFreeElement();
                coin.CollectibleMovement(_playerCollectible.transform);

                yield return _activateTime;
            }

            yield break;
        }
    }
}