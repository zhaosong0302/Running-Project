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
        // ����Ƿ����˿ո��
        // �����ɫ������Ծ����ʼ��ʱ
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
