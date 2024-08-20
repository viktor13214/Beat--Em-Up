using System;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Pool : MonoBehaviour
{
     [SerializeField] private List<PoolObject> _prefab;


       [SerializeField] private int _minCapacity;
       [SerializeField] private int _maxCapacity;

       [SerializeField] private bool _isExpand;

       private List<PoolObject> _pool;
       
       public void Init()
       {
          CreatePool();
       }
       private void OnValidate() {
          if(_isExpand)
          {
               _maxCapacity = Int32.MaxValue;
          }
       }
       private void CreatePool()
       {
          _pool = new List<PoolObject>(_minCapacity);
          for(int i = 0;i< _minCapacity;i++)
          {
               CreateElement();
          }
       }

       private PoolObject CreateElement(bool isActive = false)
       {
          foreach(var c in _prefab)
          {
          var createObject = Instantiate(c);
          createObject.gameObject.SetActive(isActive);
          _pool.Add(createObject);
               
          }
          return _pool[0];
       }
       public PoolObject GetFreeElement(PoolObject type,Vector3 position)
       {
          var element = GetFreeElement(type);
          element.transform.position = position;
          return element;
       }
       public PoolObject GetFreeElement(PoolObject type,Vector3 position,Quaternion rotation)
       {
          var element = GetFreeElement(type);
          element.transform.position = position;
          element.transform.rotation = rotation;
          return element;
       }
       public PoolObject GetFreeElement(PoolObject type,Vector3 position,Quaternion rotation,Transform parent)
       {
          var element = GetFreeElement(type);
          
          element.transform.parent = parent;
          element.transform.position = position;
          element.transform.rotation = rotation;
          
          return element;
       }
       public bool TryGetElement(out PoolObject element,PoolObject type)
       {
          foreach(var item in _pool)
          {
               if(!item.gameObject.activeInHierarchy)
               {
                    if(item.gameObject.name  == type.gameObject.name + "(Clone)")
                    {
                    element = item;
                    item.gameObject.SetActive(true);
                    return true;
                    }
               }
          }
          element = null;
          return false;
       }
       public PoolObject GetFreeElement(PoolObject type)
       {
          if(TryGetElement(out var element,type))
          {
               return element;
          }
          if(_isExpand)
          {
               return CreateElement(true);
          }
          if(_pool.Count < _maxCapacity)
          {
               return CreateElement(true);
          }
          throw new Exception("pool");
       }

}
