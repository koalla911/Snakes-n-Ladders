using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakesNLadders
{
    public class PoolMono<T> where T : MonoBehaviour
    {
        public T Prefab { get; }
        public bool AutoExpand { get; set; }
        public Transform PrefabPosition { get; }

        private List<T> _pool;


        public PoolMono(T prefab, int count, Transform prefabParentPosition, bool autoExpand)
        {
            (Prefab, PrefabPosition, AutoExpand) = (prefab, prefabParentPosition, autoExpand);

            CreatePool(count);
        }


        private void CreatePool(int count)
        {
            _pool = new List<T>();

            for (int i = 0; i < count; i++)
            {
                CreateObject();
            }
        }


        private T CreateObject(bool isActiveByDefault = false)
        {
            T createdObject = GameObject.Instantiate(Prefab, PrefabPosition);
            createdObject.gameObject.SetActive(isActiveByDefault);
            _pool.Add(createdObject);
            return createdObject;
        }


        public bool HasFreeElement(out T element)
        {
            foreach (var item in _pool)
            {
                if (!item.gameObject.activeInHierarchy)
                {
                    element = item;
                    item.gameObject.SetActive(true);
                    return true;
                }
            }


            element = null;
            return false;
        }


        public T GetFreeElement()
        {
            if (HasFreeElement(out T element))
            {
                return element;
            }

            if (AutoExpand)
            {
                return CreateObject(true);
            }

            throw new Exception($"there is no free elements in pool of type {typeof(T)}");
        }

    }
}
