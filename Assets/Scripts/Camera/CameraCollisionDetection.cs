using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollisionDetection : MonoBehaviour
{
    [SerializeField] private LayerMask _contactLayer;
    [SerializeField] private Transform _detectLine;

    private bool _isNextLevel;

    private Vector3 _lineOffset;
    private bool _isTriggered;

    public delegate void NextLevelSpawn();
    public static event NextLevelSpawn OnNextLevelSpawn;


    private void Awake() 
    {
        _isNextLevel = false;
        _lineOffset = new Vector3(10f, 0f, 0f);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isTriggered)
        {
            _isTriggered = true;
            DetectLine();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_isTriggered)
        {
            _isTriggered = false;
        }
    }


    private void DetectLine()
    {
        _isNextLevel = Physics2D.OverlapArea(_detectLine.position - _lineOffset, _detectLine.position + _lineOffset, _contactLayer);

        if (_isNextLevel != true)
        {
            OnNextLevelSpawn?.Invoke();
        }
    }


    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(_detectLine.position - _lineOffset, _detectLine.position + _lineOffset);
    }*/

}
