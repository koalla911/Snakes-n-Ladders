using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts
{
    public class ScoreModel
    {
        /*public static ScoreModel SingletoneDataInstance
        {
            get
            {
                return _singletoneDataInstance;
            }

        }*/

        //private static ScoreModel _singletoneDataInstance;


        public delegate void ChangeScore(int score);
        public event ChangeScore OnChangeScore;
        
        /*public delegate void ChangeCoin(int score);
        public event ChangeCoin OnChangeCoin;*/

        public int CurrentScore { get { return _sourceScore; } }
        //public int CurrentCoin { get { return _sourceCoin; } }

        private int _sourceScore = 0;
        //private int _sourceCoin = 0;


        /*private void Awake()
        {
            _singletoneDataInstance = gameObject.GetComponent<ScoreModel>();
        }*/


        public void SetScoreValue(int difference)
        {
            _sourceScore += difference;
            OnChangeScore?.Invoke(_sourceScore);
        }


        /*public void SetCoinValue(int difference)
        {
            _sourceCoin += difference;
            OnChangeCoin?.Invoke(_sourceCoin);
        }*/
    }
}