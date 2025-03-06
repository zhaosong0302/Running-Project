using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailControl : MonoBehaviour
{
    private static TrailRenderer TR;

    void Start()
    {
        TR = GetComponent<TrailRenderer>();
    }
    void Update()
    {
        // 检测是否按下了空格键
        // 如果角色正在跳跃，则开始计时
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Invoke("disabledtrail", 1);
        }
    }
    void disabledtrail()
    {
        if(TR != null)
        {
            TR.enabled = false;
        }
    }
    public static void onabledtrail()
    {
        if(TR != null)
        {
            TR.enabled = true;
        }
    }
}
