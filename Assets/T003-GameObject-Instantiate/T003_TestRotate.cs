using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T003_TestRotate : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.eulerAngles += new Vector3(0, 0.2f, 0);
    }
}
