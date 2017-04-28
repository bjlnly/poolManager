using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

//  视图  将来要挂载到游戏对象上  所以要继承MonoBehaviour 
public abstract class View : MonoBehaviour { 


    //视图标识
    public abstract string Nmae { get; }

    //关系的事件列表
    public List<string> AttctionEvents = new List<string>();  // 把关心的事件存到这里头


    //事件处理函数 
    public abstract void HandleEvent(string eventName, object data);

    // 获取模型
    protected Model GetModel<T>()
      where T:Model
    {
        return MVC.GetModel<T>(); //委托中间者 调用方法

    }

    //发送消息
    protected void SendEvent(string eventName,object data = null)
    {
        MVC.SendEvent(eventName,data);
    }



}
