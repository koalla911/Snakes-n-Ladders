using SnakesNLadders.Assets.Scripts.Character.CharacterStates;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.UIViews
{
    public class UIStatistic : MonoBehaviour
    {
        [SerializeField] private StateTriggerDownfall _character;
        public Canvas gameOverCanvas;

        /*[SerializeField] private GameObject[] _statsText;
        [SerializeField] private GameObject[] _statsValue;
        
        private TextMeshProUGUI[] _statsTextComponent;
        private TextMeshProUGUI[] _statsValueComponent;

        private Canvas _pauseCanvas;

        private float _waitForSec = 0.5f;
        private WaitForSeconds _waitFor;
*/

        private void OnEnable()
        {
            //_waitFor = new WaitForSeconds(_waitForSec);

            _character.OnCharacterDisable += StatisticWindow;
        }


        private void Awake()
        {
			gameOverCanvas.gameObject.SetActive(false);

            /*_statsTextComponent = new TextMeshProUGUI[_statsText.Length];
            _statsValueComponent = new TextMeshProUGUI[_statsValue.Length];

            for (int i = 0; i < _statsText.Length; i++)
            {
                _statsTextComponent[i] = _statsText[i].GetComponent<TextMeshProUGUI>();
                _statsValueComponent[i] = _statsValue[i].GetComponent<TextMeshProUGUI>();

                _statsTextComponent[i].enabled = false;
                _statsValueComponent[i].enabled = false;
            }*/
        }


        private void StatisticWindow()
        {
			gameOverCanvas.gameObject.SetActive(true);

			//StartCoroutine(StatisticShowsUp());
		}


		/*private IEnumerator StatisticShowsUp()
        {
            for (int i = 0; i < _statsText.Length; i++)
            {
                yield return _waitFor;

                _statsTextComponent[i].enabled = true;

                yield return _waitFor;
            }
        }*/


        /*private IEnumerator StatisticValue()
        {
            while (true)
            {
                _scoreTMP.SetText("{0}", score * Time.deltaTime);

                yield return null;

            }
        }*/


        private void OnDisable()
        {
            _character.OnCharacterDisable -= StatisticWindow;
        }
    }
}