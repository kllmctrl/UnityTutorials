using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfilerRenderingTestRotate : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0, 1, 0);
    }
}
