using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakesNLadders
{
    public class LimitFrameRate : MonoBehaviour
    {
        [SerializeField] private int _frameRate = 60;

        private void Start()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = _frameRate;
        }
    }
}
