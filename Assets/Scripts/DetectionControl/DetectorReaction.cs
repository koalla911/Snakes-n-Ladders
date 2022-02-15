using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.InteractionAbstract
{
    [RequireComponent(typeof(Detector))]
    public class DetectorReaction : MonoBehaviour
    {
        public delegate bool DetectionRun();
        public event DetectionRun OnDetectionRun;

        public delegate void DetectionOver();
        public event DetectionOver OnDetectionOver;

        private IDetector _detector;

        private void Awake()
        {
            _detector = GetComponent<IDetector>();
        }

        private void OnEnable()
        {
            _detector.OnObjectDetected += Detection;
            _detector.OnObjectDetectionReleased += Releasing;
        }


        private void Detection(GameObject source, GameObject detected)
        {
            OnDetectionRun?.Invoke();
        }


        private void Releasing(GameObject source, GameObject detected)
        {
            OnDetectionOver?.Invoke();
        }

        private void OnDisable()
        {
            _detector.OnObjectDetected -= Detection;
            _detector.OnObjectDetectionReleased -= Releasing;
        }
    }
}