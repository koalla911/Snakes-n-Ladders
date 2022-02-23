using SnakesNLadders.Assets.Scripts.Pooler;
using SnakesNLadders.Assets.Scripts.Pooler.PoolerPot;
using System;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Level
{
    public class LevelActivatorTrigger : MonoBehaviour
    {
        [SerializeField] private PoolActivateTriggerSnake[] _activators;
        [SerializeField] private PoolActivatePot _activatePot;
        public PoolActivateTriggerSnake[] Activators { get { return _activators; } }


        private void OnEnable()
        {
            LevelObserver.OnTransitionNextLevel += SetTrigger;
        }


        public void ActivatePot()
        {
            _activatePot.Activate();
        }
        

        public void DisactivatePot()
        {
            _activatePot.Disactivate();
        }

        //TODO what is these activators mehtods?
        private void SetTrigger()
        {
            for (int i = 0; i < _activators.Length; i++)
            {
                _activators[i].Triggered();
                _activators[i].ActivateCollision.Triggered();
            }
        }



        private void OnDisable()
        {
            LevelObserver.OnTransitionNextLevel -= SetTrigger;
        }
    }
}