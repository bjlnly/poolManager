using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
public static class MVC {  // 中间者

     //存储MVC   
    public static Dictionary<string, Model> Models = new Dictionary<string, Model>();  //名字 --  模型 
    public static Dictionary<string, View> Views = new Dictionary<string, View>();   // 名字  -- 视图
    // 存储的并不是控制器实例， 控制器是无状态的    每次动态产生 所以是个类型
    public static Dictionary<string, Type> CommandMap = new Dictionary<string, Type>();  // 事件名字 -- 控制器类型


    // 注册

    public static void RegisterModel(Model model)
    {
        Models[model.Nmae] = model;
    }

    public static void RegisterView(View view)
    {
        Views[view.name] = view;

    }

    public static void RegisterController(string eventName, Type controllerType)
    {
        CommandMap[eventName] = controllerType;
    }


    //获取

    public static Model GetModel<T>()
       where T:Model 
    {
        foreach (Model m in Models.Values)
        {
            if (m is T)
                return m;
        }
        return null;
    }

    public static View GetView<T>()
        where T : View
    {
        foreach (View v in Views.Values)
        {
            if (v is T)
                return v;
        }
        return null;
    }


    // 发送事件     优先控制器 接收，  处理完逻辑层后  给视图
    public static void SendEvent(string eventName, object data = null) //C# 语法   如果不传这个参数就是为空， 传了就是data数据。 
    {

        // 控制器响应事件
        if(CommandMap.ContainsKey(eventName)){

            Type t = CommandMap[eventName];  // 如果控制器数组里有这个事件 就找类型
            Controller c = Activator.CreateInstance(t) as Controller;   // 一一对应   所以就可以不用传eventName
            // 控制器执行
            c.Execute(data);

        }

        //视图响应事件
        foreach (View v in Views.Values)
        {
            if (v.AttctionEvents.Contains(eventName))
            {
                // 视图响应事件
                v.HandleEvent(eventName, data);
            }   
        }


    }      


}
