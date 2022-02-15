using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SnakesNLadders.Assets.Scripts.Pooler
{
    public class PoolMonoArray<T> where T : MonoBehaviour
    {
        public T[] PrefabArray { get; }
        public bool AutoExpand { get; set; }
        public Transform PrefabPosition { get; }

        private List<T> _pool;



        public PoolMonoArray(T[] prefabArray, int count, Transform prefabPosition, bool autoExpand)
        {
            (PrefabArray, PrefabPosition, AutoExpand) = (prefabArray, prefabPosition, autoExpand);

            CreatePool(count);
        }


        private void CreatePool(int count)
        {
            _pool = new List<T>();

            for (int i = 0; i < count; i++)
            {
                CreateRandomObject();
            }
        }


        private T CreateRandomObject(bool isActiveByDefault = false)
        {
            int randomObject = UnityEngine.Random.Range(0, PrefabArray.Length);
            T createdObject = GameObject.Instantiate(PrefabArray[randomObject], PrefabPosition);
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
                return CreateRandomObject(true);
            }

            throw new Exception($"there is no free elements in pool of type {typeof(T)}");
        }

    }
}