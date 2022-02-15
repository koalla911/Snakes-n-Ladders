using System;
using System.Collections.Generic;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.CharacterStates
{
    public class InitialBehaviorMap : MonoBehaviour
    {
        private Dictionary<Type, ICharacterBehavior> _behaviourMap;

        private void Awake()
        {
            InitBehaviours();
        }

        private void InitBehaviours()
        {
            _behaviourMap = new Dictionary<Type, ICharacterBehavior>();

            _behaviourMap[typeof(CharacterBehaviorStart)] = new CharacterBehaviorStart();
            _behaviourMap[typeof(CharacterBehaviorRise)] = new CharacterBehaviorRise();
            _behaviourMap[typeof(CharacterBehaviorDownfall)] = new CharacterBehaviorDownfall();
            _behaviourMap[typeof(CharacterBehaviorJump)] = new CharacterBehaviorJump();
        }


        internal ICharacterBehavior GetBehaviour<T>() where T : ICharacterBehavior
        {
            var type = typeof(T);
            return _behaviourMap[type];
        }

    }
}