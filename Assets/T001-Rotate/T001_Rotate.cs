using UnityEngine;

public class T001_Rotate : MonoBehaviour
{
    private float xx = 0f;
    private float yy = 0f;
    private float zz = 0f;
    
    void Update()
    {
        // 欧拉旋转 （会导致万向锁）
        // transform.eulerAngles += new Vector3(1, 1, 1);
        
        // 四元数旋转
        xx += 1.0f;
        yy += 1.0f;
        zz += 1.0f;
        transform.rotation = Quaternion.Euler(new Vector3(xx, yy, zz));;
    }
}
