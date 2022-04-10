using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts
{
    public class ScoreModel : MonoBehaviour
    {
		public static ScoreModel Instance
		{
			get
			{
				return instance;
			}

		}

		private static ScoreModel instance;


        public delegate void ChangeScore(int score);
        public event ChangeScore OnChangeScore;

		public delegate void ChangeCoin(int score);
		public event ChangeCoin OnChangeCoin;


		public int sourceScore = 0;
		public int sourceCoin = 0;
		public int snakeValue = 1;
		public int coinValue = 1;


		private void Awake()
		{
			instance = gameObject.GetComponent<ScoreModel>();
		}


		public void SetScoreValue(int difference)
        {
            sourceScore += difference;
            OnChangeScore?.Invoke(sourceScore);
        }


		public void SetCoinValue(int difference)
		{
			sourceCoin += difference;
			OnChangeCoin?.Invoke(sourceCoin);
		}
	}
}