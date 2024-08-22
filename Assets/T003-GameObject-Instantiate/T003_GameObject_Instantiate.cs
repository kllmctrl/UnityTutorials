using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

public class T003_GameObject_Instantiate : MonoBehaviour
{
    void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine("Test");
            // Test();
        }
        // if (Input.GetKeyDown(KeyCode.C))
        // {
        //     StopTest();
        // }
    }

    IEnumerator Test()
    {
        Profiler.BeginSample("Test-GameObject-Instantiate");
        GameObject objPrefab = Resources.Load<GameObject>("PrefabCube");
        for (int i = 0; i < 1000; i++)
        {
            GameObject.Instantiate(objPrefab);
        }
        // GameObject obj = GameObject.Instantiate(objPrefab, null, false);
        Profiler.EndSample();

        for (int i = 0; i < 100; i++)
        {
            yield return new WaitForEndOfFrame();
        }
        StopTest();
    }
    
    private void StopTest()
    {
        Debug.LogError("Test Finish");
    }
}
