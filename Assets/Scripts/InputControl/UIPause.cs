using SnakesNLadders.Assets.Scripts.Character.CharacterStates;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.InputControl
{
    public class UIPause : MonoBehaviour
    {
        [SerializeField] private StateTriggerDownfall _character;
        [SerializeField] private GameObject _pausePanel;

        private Canvas _pauseCanvas;


        private void OnEnable()
        {
            _character.OnCharacterDisable += PauseWindow;
        }


        private void Awake()
        {
            _pauseCanvas = _pausePanel.GetComponent<Canvas>();
            _pauseCanvas.enabled = false;
        }


        private void PauseWindow()
        {
            if (_pausePanel != null)
            {
                _pauseCanvas.enabled = true;
            }
        }


        private void OnDisable()
        {
            _character.OnCharacterDisable -= PauseWindow;
        }
    }
}