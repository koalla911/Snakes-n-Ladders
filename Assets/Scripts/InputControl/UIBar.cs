using SnakesNLadders.Assets.Scripts.InteractionAbstract;
using UnityEngine;
using UnityEngine.UI;

namespace SnakesNLadders.Assets.Scripts.InputControl
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
        }


        private void Stamina(int currentWeight)
        {
            _staminaImage.fillAmount = _staminaValue - (currentWeight / 100f);
        }


        private void OnDisable()
        {
            _character.OnWeightChange -= Stamina;

        }
    }
}