using System.Collections;
using System.Collections.Generic;
using UnityEngine;
                          //模型
public abstract  class Model{  // 所有数据层的基类，不需要实例化


    public abstract string Nmae { get; } // 模型需要存储到将来的某个地方 一定要有一个名字 

    protected void SendEvent(string eventNmae, object data = null)
    {
        // 刁Model 发消息  我就委托MVC 这个中间这 发送 
        MVC.SendEvent(eventNmae,data);

    }

}
