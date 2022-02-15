using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.InteractionAbstract
{
    public interface IDetectableObject
    {
        event ObjectDetection OnObjectDetected;
        event ObjectDetection OnObjectDetectionReleased;

        GameObject gameObject { get; }

        void Detected(GameObject detectionSource);
        void DetectionReleased(GameObject detectionSource);
    }
}
