using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;


public class SubPool{

    //预设
    GameObject m_preafab; 

    //集合
    List<GameObject> m_objects = new List<GameObject>();

    // 名字标识
    public string Name   
    {
        get { return m_preafab.name; }       
    }


    // 构造
    public SubPool(GameObject prefab){  
        this.m_preafab = prefab;
 }



    //取对象
    public GameObject Spawn(){
        GameObject go = null; // 默认是空  然后在池子里调用对象 
        foreach (GameObject obj in m_objects) {
            if(!obj.activeSelf){  // 如果池子里是隐藏的  就说明可用的  调用。
                go = obj;
                break;
            }
        }

        if(go = null ){  //如果是空 ，  就直接自己创建一个对象 进行引用
            go = GameObject.Instantiate<GameObject>(m_preafab);
            m_objects.Add(go);  // 添加到对象池列表

        }
        go.SetActive(true);  // 开启引用
        go.SendMessage("OnSpawn", SendMessageOptions.DontRequireReceiver); //  发消息这个     这个枚举 即使没有也不会报错

        return go;
    }

    //回收对象
    public void Unspawn(GameObject go){
        if(Contains(go)){ //判断有没有在池子里。     如果在就隐藏  回收
            go.SendMessage("OnUnspawn", SendMessageOptions.DontRequireReceiver);
            go.SetActive(false);   
        }


    }



    // 回收池子所有的对象
    public void UnSpawnAll(){
        foreach (GameObject item in m_objects)
        {
            if(item.activeSelf){ //如果对象有这个东西就回收
                Unspawn(item);
            }
        }

    }


    //是否包含对象
    public bool Contains(GameObject go)
    {
        return m_objects.Contains(go);
    }

    // -------------------------------------------------------------------4.24






    




}

