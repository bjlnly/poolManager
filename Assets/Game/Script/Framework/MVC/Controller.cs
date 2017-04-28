using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
                         // 控制器  主要协调 Mode  和View 两个类
public abstract class Controller  {   //只需要类型



    //获取模型
    protected Model GetModel<T>()
      where T:Model
    {
        return MVC.GetModel<T>();
    }

    //获取视图
    protected View GetView<T>()
         where T : View
    {
        return MVC.GetView<T>();

    }


    //处理系统消息
    protected void RegisterModel(Model model) // 注册模型
    {
        MVC.RegisterModel(model);
    }

    protected void RegisterView(View view)  //注册视图
    {
        MVC.RegisterView(view);
    }

    protected void RegisterController(string eventName, Type controllerType) // 注册控制器
    {
        MVC.RegisterController(eventName, controllerType);   
    }



    public abstract void Execute(object data);



}
