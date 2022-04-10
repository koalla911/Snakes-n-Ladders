using SnakesNLadders.Assets.Scripts.InteractionAbstract;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace SnakesNLadders.Assets.Scripts
{
	public class UIBar : MonoBehaviour
	{
		[SerializeField] private DetectableObjectReaction _character;
		[SerializeField] private Image _staminaImage;

		private float _staminaValue;


		private void OnEnable()
		{
			_character.OnWeightChange += Stamina;
		}


		private void Awake()
		{
			_staminaValue = _character.MaxWeight / 100f;
			_staminaImage.fillAmount = _staminaValue;
			StartCoroutine(PermanentValueChange());
		}


		private void Stamina(int currentWeight)
		{
			_staminaImage.fillAmount = _staminaValue - (currentWeight / 100f);
		}

		private IEnumerator PermanentValueChange()
		{
			while (true)
			{
				_staminaImage.fillAmount += 0.1f * Time.deltaTime;

				yield return null;

			}
		}


		private void OnDisable()
		{
			_character.OnWeightChange -= Stamina;

		}
	}
}