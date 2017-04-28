using System;
using System.Collections.Generic;
using UnityEngine; 

public abstract class ReusbleObject:MonoBehaviour,IResuable{

    //abstract 保证子类继承我的时候一定要实例这两个方法



    public void OnSpawn()
    {
        throw new NotImplementedException();
    }

    public void OnUnspawn()
    {
        throw new NotImplementedException();
    }



}



