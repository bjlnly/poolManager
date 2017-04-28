using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IResuable {

	/// <summary>
	/// 当取出时调用
	/// </summary>
	void OnSpawn ();
	 
    /// <summary>
    /// 当回收时调用
    /// </summary>
	void OnUnspawn();
 




}
