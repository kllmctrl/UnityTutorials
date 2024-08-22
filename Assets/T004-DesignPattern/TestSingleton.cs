using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSingleton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 直接用类调用
        Singleton.Instance.Test();
    }
}
