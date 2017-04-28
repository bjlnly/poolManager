using System;
using System.Collections.Generic;
using UnityEngine;

  public abstract  class Singleton<T>:MonoBehaviour
       where T : MonoBehaviour   // 约束 这个单例模版必须继承MonoBehaviour
{

      private static T m_instance = null; //单例引用  一开始为空
      public static T Instance
      {
          get { return m_instance; }

      }

      //  直接用Awake  应为私有的变量不会被继承下去  所以改成
      protected virtual void Awake() { 
     // 访问级别  protected  Awake 子类也要用 变成 virtual（子类可以重写）  目的是为了让子类也可以引用

          m_instance = this as T; //赋值

      }





  }

