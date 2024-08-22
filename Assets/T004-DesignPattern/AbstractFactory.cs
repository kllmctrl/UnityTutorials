using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractFactory : MonoBehaviour
{
    // 定义几个Button
    class Button{}

    class Border {}

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
    
    class WinBorder : Border
    {
        public WinBorder()
        {
            Debug.LogWarning("win border create");
        }
    }

    class MacBorder : Border
    {
        public MacBorder()
        {
            Debug.LogWarning("Mac border create");
        }
    }
    
    
    //他们自己的工厂类
    interface IFactory
    {
        abstract Button createButton();
        abstract Border createBorder();
    }

    class WinFactory : IFactory
    {
        public Button createButton()
        {
            return new WinButton();
        }
        
        public Border createBorder()
        {
            return new WinBorder();
        }
    }

    class MacFactory : IFactory
    {
        public Button createButton()
        {
            return new MacButton();
        }
        
        public Border createBorder()
        {
            return new MacBorder();
        }
    }

    void Start()
    {
        IFactory fac;
        var style = 2;
        switch (style)
        {
            case 1:
                fac = new WinFactory();
                break;
            case 2:
                fac = new MacFactory();
                break;
            default:
                fac = new WinFactory();
                break;
        }

        fac.createButton();
        fac.createBorder();
    }
}
