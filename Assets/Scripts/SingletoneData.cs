using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts
{
    public class SingletoneData : MonoBehaviour
    {
        public static SingletoneData SingletoneDataInstance
        {
            get
            {
                return _singletoneDataInstance;
            }

        }

        private static SingletoneData _singletoneDataInstance;


        public delegate void ChangeScore(int score);
        public event ChangeScore OnChangeScore;
        
        public delegate void ChangeCoin(int score);
        public event ChangeCoin OnChangeCoin;

        public int CurrentScore { get { return _sourceScore; } }
        public int CurrentCoin { get { return _sourceCoin; } }
        //public int CharacterStamina = 100;

        private int _sourceScore = 0;
        private int _sourceCoin = 0;


        private void Awake()
        {
            _singletoneDataInstance = gameObject.GetComponent<SingletoneData>();
        }


        public void SetScoreValue(int difference)
        {
            _sourceScore += difference;
            OnChangeScore?.Invoke(_sourceScore);
        }


        public void SetCoinValue(int difference)
        {
            _sourceCoin += difference;
            OnChangeCoin?.Invoke(_sourceCoin);
        }
    }
}