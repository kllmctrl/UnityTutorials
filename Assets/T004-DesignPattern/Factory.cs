using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    // 定义几个Button
    class Button{}

    class WinButton : Button
    {
        public WinButton()
        {
            Debug.LogWarning("win button create");
        }
    }

    class MacButton : Button
    {
        public MacButton()
        {
            Debug.LogWarning("Mac button create");
        }
    }
    
    //他们自己的工厂类
    interface IButtonFactory
    {
        abstract Button createButton();
    }

    class WinButtonFactory : IButtonFactory
    {
        public Button createButton()
        {
            return new WinButton();
        }
    }

    class MacButtonFactory : IButtonFactory
    {
        public Button createButton()
        {
            return new MacButton();
        }
    }

    void Start()
    {
        //测试创建button
        // WinButtonFactory factory = new WinButtonFactory();
        // factory.createButton();

        MacButtonFactory factory = new MacButtonFactory();
        factory.createButton();
    }
}
