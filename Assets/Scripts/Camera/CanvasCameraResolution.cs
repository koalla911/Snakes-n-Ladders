using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Camera
{
    public class CanvasCameraResolution : MonoBehaviour
    {
        [SerializeField] private UnityEngine.Camera _camera;


        private void Awake()
        {
            RectTransform rectTransform = GetComponent<RectTransform>();
            float canvasHeight = rectTransform.rect.height;
            float desiredCanvasWidth = (canvasHeight * _camera.aspect);
            rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, desiredCanvasWidth);
        }
    }
}