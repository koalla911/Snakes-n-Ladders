using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float _parallaxEffect;

    private Camera _mainCamera;

    private float _startPositionY;
    private readonly float _boundLengthY = 1920f;
    private readonly float _pixelPerUnit = 100f;
    private readonly float _perspectiveCoefficient = 10f;


    private void Awake()
    {
        _startPositionY = transform.position.y;
        _mainCamera = Camera.main;
    }


    private void Start()
    {
        StartCoroutine(ParallaxMovement());
    }

    private IEnumerator ParallaxMovement()
    {
        while (true)
        {
            float temporary = _mainCamera.transform.position.y * (1 - _parallaxEffect) + _perspectiveCoefficient;
            float distance = _mainCamera.transform.position.y * _parallaxEffect;

            transform.position = new Vector3(transform.position.x, _startPositionY + distance, transform.position.z);

            if (temporary > _startPositionY + _boundLengthY / _pixelPerUnit)
            {
                _startPositionY += _boundLengthY / _pixelPerUnit;
            }
            else if (temporary < _startPositionY - _boundLengthY / _pixelPerUnit)
            {
                _startPositionY -= _boundLengthY / _pixelPerUnit;

            }

            yield return null;
        }
    }
}
