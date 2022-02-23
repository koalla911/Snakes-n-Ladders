using SnakesNLadders.Assets.Scripts.Character;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.InteractionAbstract
{
    [RequireComponent(typeof(DetectableObject))]
    public class DetectableObjectReaction : MonoBehaviour
    {
        [SerializeField] private int _maxWeight = 7;

        public int MaxWeight { get { return _maxWeight; }}

        public delegate void CharacterDownfall(GameObject detected);
        public event CharacterDownfall OnCharacterDownfall;

        public delegate void WeightChange(int currentWeight);
        public event WeightChange OnWeightChange;

        private IDetectableObject _detectableObject;

        private CharacterStamina _characterData;

        private int _snakeCount;


        private void Awake()
        {
            _detectableObject = GetComponent<IDetectableObject>();
            _characterData = new CharacterStamina();
        }


        private void OnEnable()
        {
            _detectableObject.OnObjectDetected += Detected;
            _detectableObject.OnObjectDetectionReleased += Released;
        }


        private void Detected(GameObject source, GameObject detected)
        {
            _snakeCount += 1;
            OnWeightChange?.Invoke(_snakeCount);

            if (_snakeCount >= _maxWeight)
            {
                OnCharacterDownfall?.Invoke(this.gameObject);
            }
        }


        private void Released(GameObject source, GameObject detected)
        {
            _snakeCount -= 1;
            OnWeightChange?.Invoke(_snakeCount);
        }


        private void OnDisable()
        {
            _detectableObject.OnObjectDetected -= Detected;
            _detectableObject.OnObjectDetectionReleased -= Released;
        }
    }
}