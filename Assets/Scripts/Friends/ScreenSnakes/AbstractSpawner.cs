using SnakesNLadders.Assets.Scripts.Interactables;
using SnakesNLadders.Assets.Scripts.Pooler;
using System;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Friends.ScreenSnakes
{
    public abstract class AbstractSpawner
    {
        public abstract PoolMonoArray<MonoBehaviour> Pool
        {
            get;
        }

        private Vector3 _position;
        private Quaternion _rotation;
        private bool _flipHor;
        private bool _flipVer;


        public void PoolInstanceTemplate()
        {
            PoolInstance();
        }


        public MonoBehaviour PoolActivateTemplate(Vector3 position, Quaternion angle, bool flipHor, bool flipVer)
        {
            _position = position;
            _rotation = angle;
            _flipHor = flipHor;
            _flipVer = flipVer;

            MonoBehaviour activeObject = PoolActivate();
            //Debug.Log(activeObject.gameObject.name);
            //PoolActivate();
            SetConfiguration(activeObject);
            return activeObject;
        }
        
        
        public MonoBehaviour PoolActivateTemplate(Vector3 position)
        {
            _position = position;

            MonoBehaviour activeObject = PoolActivate();
            activeObject.gameObject.transform.position = _position;

            return activeObject;
        }


        protected MonoBehaviour PoolActivate()
        {
            MonoBehaviour interactObject = Pool.GetFreeElement();
            //SetConfiguration(interactObject);
            return interactObject;
        }


        protected void SetConfiguration(MonoBehaviour interactable)
        {
            interactable.gameObject.transform.position = _position;
            interactable.gameObject.transform.rotation = _rotation;
            SpriteRenderer sprite = interactable.gameObject.GetComponent<SpriteRenderer>();
            sprite.flipX = _flipHor;
            sprite.flipY = _flipVer;
        }


        protected abstract void PoolInstance();

    }
}