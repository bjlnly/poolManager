using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class ObjectPool : Singleton<ObjectPool>  // 这样就引用了单例模版 变成单例类了 
{ 

    public string ResourceDir = "";  // 预设路径  默认 = “”

    Dictionary<string, SubPool> m_pools = new Dictionary<string, SubPool>();    // 对应名字的 池子 字典


    // 取对象
    public GameObject Spawn(string name){
        if(!m_pools.ContainsKey(name))//是否包含这个键
            RegisterNew(name);  // 创建对象的方法
        SubPool pool = m_pools[name];
        return pool.Spawn();
    }

    //回收对象
    public void Unspawn( GameObject go){
        SubPool pool = null; // 一开始是空
        foreach (SubPool p in m_pools.Values) // 是否有这个池子对象
        {
            if(p.Contains(go)){
                pool = p;
                break;
            }
        }
        pool.Unspawn(go);  // 如果没有就创建一个丢进对象池
    }


    // 回收所有对象
    public void UnspawnAll()
    {
        foreach (SubPool p in m_pools.Values) 
        {
            p.UnSpawnAll(); //调用对象池的回收方法
        }

    }




    void RegisterNew(string name){
        //预设路径
        string path = "";
        if (string.IsNullOrEmpty(ResourceDir)) // 判断是否= null
            path = name;
        else
            path = ResourceDir + "/" + name;

        //加载预设
        GameObject prefab = Resources.Load<GameObject>(path);

        //创建子对象池
        SubPool pool = new SubPool(prefab);
        m_pools.Add(pool.Name, pool);
               
    }








}
