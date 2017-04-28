using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   //音效类  管理背景音乐 和 音效
public class Sound : Singleton<Sound> {

    protected override void Awake() // 继承父类的调用
    {
        base.Awake(); //获取引用

        m_bgSound = this.gameObject.AddComponent<AudioSource>(); // 给这个物体添加个背景
        m_bgSound.playOnAwake = false; // 不希望直接播放
        m_bgSound.loop = true;   // 必须循环

        m_effectSound = this.gameObject.AddComponent<AudioSource>(); // 添加一个播放音效的
    }


    public string ResourceDir = "";  // 相对路径  默认为空

    AudioSource m_bgSound;  // 背景音乐
    AudioSource m_effectSound; // 音效


    //声音大小
    public float BgVolume
    {
        get { return m_bgSound.volume; }
        set { m_bgSound.volume = value; }
    }
    //音效大小
    public float EffectVolume    
    {
        get { return m_effectSound.volume; }
        set { m_effectSound.volume = value; }    
    }
    // 播放音乐
    public void PlayBg(string audioName)
    {
        // 当前正在播放的音乐
        string oldName;
        if (m_bgSound.clip == null)
            oldName = "";
        else
            oldName = m_bgSound.clip.name;

        if (oldName != audioName){
            // 音乐文件路径
            string path;
            if (string.IsNullOrEmpty(ResourceDir)) // 这个路径不为空
                path = "";
            else
                path = ResourceDir + "/" + audioName;

            // 加载音乐 
            AudioClip clip = Resources.Load<AudioClip>(path);

            if(clip!=null){
                m_bgSound.clip = clip;
                m_bgSound.Play();
            }
        }   
    }

    // 停止音乐
    public void StopBg(){
        m_bgSound.Stop();
        m_bgSound.clip = null;
    
    }

    // 播放音乐
    public void PlayEffect(string audioName){
        //路径
        string path;
        if (string.IsNullOrEmpty(ResourceDir)) // 这个路径不为空
            path = "";
        else
            path = ResourceDir + "/" + audioName;
        // 音频
        AudioClip clip = Resources.Load<AudioClip>(path);
        //播放
        m_effectSound.PlayOneShot(clip);

    }


}
