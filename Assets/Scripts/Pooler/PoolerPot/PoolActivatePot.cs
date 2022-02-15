using SnakesNLadders.Assets.Scripts.Interactables;
using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Pooler.PoolerPot
{
    public class PoolActivatePot : MonoBehaviour
    {
        [SerializeField] private InteractableVase[] _prefab;
        [SerializeField] private Transform[] _activatePoints;
        [SerializeField] private int _poolCountPot;
        [SerializeField] private bool _autoExpand;
        [SerializeField] private int _activatePercent = 50;

        private PoolMonoArray<InteractableVase> _poolPot;
        private int[] _randomPointArray;


        private void Awake()
        {
            _poolPot = new PoolMonoArray<InteractableVase>(_prefab, _poolCountPot, transform, _autoExpand);
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
            }

        }


        private void GetFreePot()
        {
            RandomPointArray(); 

            for (int i = 0; i < _activatePoints.Length; i++)
            {
                if (_randomPointArray[i] < _activatePercent)
                {
                    InteractableVase potActive = _poolPot.GetFreeElement();
                    potActive.transform.position = _activatePoints[i].position;
                }
            }
        }
    }
}