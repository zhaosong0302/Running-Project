using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rushbuff : MonoBehaviour
{
    public float floatingRange = 1.0f; // 浮动的范围
    public float floatingSpeed = 1.0f; // 浮动的速度
    public float duration = 10f;//rush持续时间
    public MoveTest move;
    private Vector3 startPosition; // 初始位置
    private Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "body volume")
        {
            Destroy(gameObject);
            if (move != null)
            {
                if (move.animator != null) // 验证动画组件是否为空
                {
                    move.ModifySpeed(duration); // 开始rush状态
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
        startPosition = transform.position; // 记录初始位置
    }

    void Update()
    {
        // 计算上下浮动的偏移量，使用正弦函数实现周期性的浮动效果
        float yOffset = Mathf.Sin(Time.time * floatingSpeed) * floatingRange;

        // 更新胶囊的位置
        transform.position = startPosition + new Vector3(0, yOffset, 0);
    }
}