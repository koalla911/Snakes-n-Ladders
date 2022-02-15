using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.InteractionAbstract
{
    public delegate void ObjectDetection(GameObject source, GameObject detected);

    interface IDetector
    {
        event ObjectDetection OnObjectDetected;
        event ObjectDetection OnObjectDetectionReleased;

        void Detect(IDetectableObject detectableObject);

        void ReleaseDetect(IDetectableObject detectableObject);
    }
}
