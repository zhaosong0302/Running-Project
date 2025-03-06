using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    public static bool isRushing;
    public float speed = 30.0f; // 设置player的速度
    public float jumpspeed = 20.0f;//设置player的跳跃速度
    public static bool isGrounded = true; // 标记player是否在地面上
    public bool shouldMove = true;//控制移动   
    public bool hasjumptwice = false;//控制二段跳
    public Animator animator;

    void Start()
    {
        //获取player1动画组件
        animator = transform.Find("player1").GetComponent<Animator>();

        //开始奔跑
        shouldMove = true;
    }

    void Update()
    {
        GameObject player = this.gameObject;
        if(player.transform.position.y < 0)
        {
            collidertest.gameHasEnded = true;
        }

        // 水平移动
        if (shouldMove)
        {
            // 水平移动
            transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        }
        else
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();
            // 锁定X、Y、Z
            rb.constraints = RigidbodyConstraints.FreezePositionX |
                             RigidbodyConstraints.FreezePositionY |
                             RigidbodyConstraints.FreezePositionZ;
        }

        // 检测是否按下跳跃键并且在地面上
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // 执行跳跃
            Jump();
        }

        //检测是否按下跳跃以及未二段跳在空中
        else if(!isGrounded && !hasjumptwice && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            hasjumptwice = true;
        }

    }

    void Jump()             //跳跃
    {
        // 如果角色在地面上
        if (isGrounded || !hasjumptwice)
        {
            // 给角色施加一个向上的速度，以使其跳跃
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpspeed, 0);

            // 更新地面状态
            isGrounded = false;

            if (animator != null)
            {
                animator.Play("jump_start");
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // 如果player碰到了地面，更新地面状态
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            hasjumptwice = false;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        // 如果player仍然与地面接触，保持地面状态为true
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            hasjumptwice = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void ModifySpeed(float duration)         //速度翻倍
    {
        speed *= 2;
        //设置isRushing为true，开始rush动画
        animator.SetBool("isRushing", true);
        // 使用协程等待持续时间结束
        StartCoroutine(EndRushAfterTime(duration));
    }

    private IEnumerator EndRushAfterTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        // 持续时间结束，设置 isRushing 为 false，结束 rush 动画
        animator.SetBool("isRushing", false);
        speed /= 2;
    }
}
