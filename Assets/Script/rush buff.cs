using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rushbuff : MonoBehaviour
{
    public float floatingRange = 1.0f; // �����ķ�Χ
    public float floatingSpeed = 1.0f; // �������ٶ�
    public float duration = 10f;//rush����ʱ��
    public MoveTest move;
    private Vector3 startPosition; // ��ʼλ��
    private Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "body volume")
        {
            Destroy(gameObject);
            if (move != null)
            {
                if (move.animator != null) // ��֤��������Ƿ�Ϊ��
                {
                    move.ModifySpeed(duration); // ��ʼrush״̬
                }
            }
        }
    }

    void Start()
    {
        GameObject body_volume = GameObject.Find("body volume");
        if(body_volume != null)
        {
            move = body_volume.GetComponent<MoveTest>();
            animator = body_volume.GetComponent<Animator>();
        }
        startPosition = transform.position; // ��¼��ʼλ��
    }

    void Update()
    {
        // �������¸�����ƫ������ʹ�����Һ���ʵ�������Եĸ���Ч��
        float yOffset = Mathf.Sin(Time.time * floatingSpeed) * floatingRange;

        // ���½��ҵ�λ��
        transform.position = startPosition + new Vector3(0, yOffset, 0);
    }
}