using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.InteractionAbstract
{
    public class Detector : MonoBehaviour, IDetector
    {
        public event ObjectDetection OnObjectDetected;
        public event ObjectDetection OnObjectDetectionReleased;

        public GameObject[] DetectedObjects => _detectedObjects.ToArray();
        private List<GameObject> _detectedObjects = new List<GameObject>();


        public void Detect(IDetectableObject detectableObject)
        {
            if (!_detectedObjects.Contains(detectableObject.gameObject))
            {
                detectableObject.Detected(this.gameObject);
                _detectedObjects.Add(detectableObject.gameObject);

                OnObjectDetected?.Invoke(this.gameObject, detectableObject.gameObject);
            }
        }


        public void ReleaseDetect(IDetectableObject detectableObject)
        {
            if (_detectedObjects.Contains(detectableObject.gameObject))
            {
                detectableObject.DetectionReleased(this.gameObject);
                _detectedObjects.Remove(detectableObject.gameObject);

                OnObjectDetectionReleased?.Invoke(this.gameObject, detectableObject.gameObject);
            }
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (IsColliderDetectableObject(collision, out IDetectableObject detectedObject))
            {
                Detect(detectedObject);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (IsColliderDetectableObject(collision, out IDetectableObject detectedObject))
            {
                ReleaseDetect(detectedObject);
            }
        }


        private bool IsColliderDetectableObject(Collider2D collider, out IDetectableObject detectedObject)
        {
            detectedObject = collider.GetComponent<IDetectableObject>();

            return detectedObject != null;
        }
    }
}