using System.Collections;
using UnityEngine;
using Cinemachine;

namespace SnakesNLadders.Assets.Scripts.Camera
{
    public class CameraResolution : MonoBehaviour
    {
        [SerializeField] private CinemachineVirtualCamera _camera; 

        private float horizontalFoV = 68.0f;

        private void Awake()
        {
            ScaleResolution();
        }

        private void ScaleResolution()
        {
            float halfWidth = Mathf.Tan(0.5f * horizontalFoV * Mathf.Deg2Rad);

            float halfHeight = halfWidth * Screen.height / Screen.width;

            float verticalFoV = 2.0f * Mathf.Atan(halfHeight) * Mathf.Rad2Deg;

            _camera.m_Lens.FieldOfView = verticalFoV;
        }
    }
}