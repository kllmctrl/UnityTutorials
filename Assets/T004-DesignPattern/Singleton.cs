using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    // 声明为static直接用类调用
    public static Singleton Instance;

    private void Awake()
    {
        Instance = this;
        gameObject.name = "[Singleton]";
        
        //其他场景也可以使用
        DontDestroyOnLoad(gameObject);
    }

    public void Test()
    {
        Debug.Log("Test");
    }
}
