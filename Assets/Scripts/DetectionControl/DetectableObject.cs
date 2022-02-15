using System.Collections;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.InteractionAbstract
{
    public class DetectableObject : MonoBehaviour, IDetectableObject
    {
        public event ObjectDetection OnObjectDetected;
        public event ObjectDetection OnObjectDetectionReleased;

        public void Detected(GameObject detectionSource)
        {
            OnObjectDetected?.Invoke(detectionSource, this.gameObject);
        }

        public void DetectionReleased(GameObject detectionSource)
        {
            OnObjectDetectionReleased?.Invoke(detectionSource, this.gameObject);
        }

    }
}