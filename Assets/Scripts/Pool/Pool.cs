using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T:Component
{
        private Queue<T> _objects;
        private T _prefab;
        private int _maxSize;
        private Transform _parent;
        private int currentActiveAmount;

        public Pool(T prfeab, Transform parent, int maxSize)
        {
                _objects = new Queue<T>();
                _prefab = prfeab;
                _maxSize = 2*maxSize;
                for (int i = 0; i < _maxSize; i++)
                {
                        AddObjectToPool();
                }
        }

        private void AddObjectToPool()
        {
                var obj = Object.Instantiate(_prefab,_parent);
                _parent.GetChild(_parent.childCount - 1).SetSiblingIndex(0);
                if (!obj.gameObject.activeSelf) return;
                obj.gameObject.SetActive(false);
                _objects.Enqueue(obj);
        }

        public T GetObjectFromPool()
        {
                T obj;
                if (_objects.Count > 0)
                {
                       obj = _objects.Dequeue();
                }else if (currentActiveAmount < _maxSize)
                {
                        obj = Object.Instantiate(_prefab, _parent);
                        Debug.LogWarning($"Pool for {typeof(T).Name} Creating New Object, Active Amount: {currentActiveAmount}/{_maxSize}");
                }
                else
                {
                        Debug.LogError($"Pool for {typeof(T).Name} Has Reached Its Maximum Size {_maxSize}");
                        return null;
                }

                currentActiveAmount++;
                ResetObject(obj);
                obj.gameObject.SetActive(true);
                return obj;
        }

        public void ReturnToPool(T obj)
        {
                if(obj==null) return;
                
                obj.gameObject.SetActive(false);
                _objects.Enqueue(obj);
                currentActiveAmount--;
        }
        private void ResetObject(T obj)
        {
                obj.transform.SetParent(_parent);
                obj.transform.position = Vector2.zero;
                obj.transform.rotation = Quaternion.identity;
        }
}