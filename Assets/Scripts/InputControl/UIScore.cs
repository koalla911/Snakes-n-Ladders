using System.Collections;
using UnityEngine;
using TMPro;

namespace SnakesNLadders.Assets.Scripts.InputControl
{
    public class UIScore : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreTMP;
        [SerializeField] private TextMeshProUGUI _coinTMP;
        public int SourceScore { get { return _sourceScore; } }

        private int _sourceScore = 0;
        private int _startScore = 0;
        private int _startCoin = 0;

        private void OnEnable()
        {
            SingletoneData.SingletoneDataInstance.OnChangeScore += SetScoreText;
            SingletoneData.SingletoneDataInstance.OnChangeCoin += SetCoinText;
        }


        private void Awake()
        {
            _scoreTMP.SetText("{0}", _startScore);
            _coinTMP.SetText("{0}", _startCoin);
        }


        private void SetScoreText(int score)
        {
            _scoreTMP.SetText("{0}", score);
        }
        

        private void SetCoinText(int coin)
        {
            _coinTMP.SetText("{0}", coin);
        }


        private void OnDisable()
        {
            SingletoneData.SingletoneDataInstance.OnChangeScore -= SetScoreText;
            SingletoneData.SingletoneDataInstance.OnChangeCoin -= SetCoinText;
        }
    }
}