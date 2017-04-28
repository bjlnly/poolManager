using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

//程序入口类（应为是基类 不能 直接使用 所以用《T》模板化）  单例模版Singleton
  public abstract   class ApplicationBase<T>:Singleton<T>
          where T : MonoBehaviour
    {

        //注册控制器
      protected void RegisterController(string eventName, Type controllerType)
      {
          MVC.RegisterController(eventName, controllerType);
      }

      protected void SendEvent(string eventName)
      {
          MVC.SendEvent(eventName);
      }





    }

