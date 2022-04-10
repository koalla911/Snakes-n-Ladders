using System;
using System.Collections.Generic;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.SnakeStates
{
    public class InitialBehaviorMapSnake : MonoBehaviour
    {
        private Dictionary<Type, ISnakeBehavior> _behaviourMap;

        private void Awake()
        {
            InitBehaviours();
        }

        private void InitBehaviours()
        {
            _behaviourMap = new Dictionary<Type, ISnakeBehavior>();

            //_behaviourMap[typeof(SnakeBehaviorSpawn)] = new SnakeBehaviorSpawn();
            _behaviourMap[typeof(SnakeBehaviorCrawl)] = new SnakeBehaviorCrawl();
            _behaviourMap[typeof(SnakeBehaviorDance)] = new SnakeBehaviorDance();
            _behaviourMap[typeof(SnakeBehaviorDrop)] = new SnakeBehaviorDrop();
        }


        internal ISnakeBehavior GetBehaviour<T>() where T : ISnakeBehavior
        {
            var type = typeof(T);
            return _behaviourMap[type];
        }
    }
}