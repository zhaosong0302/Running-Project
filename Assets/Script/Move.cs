using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour
{
    public static bool isRushing;
    public float speed = 30.0f; // ����player���ٶ�
    public float jumpspeed = 20.0f;//����player����Ծ�ٶ�
    public static bool isGrounded = true; // ���player�Ƿ��ڵ�����
    public bool shouldMove = true;//�����ƶ�   
    public bool hasjumptwice = false;//���ƶ�����
    public Animator animator;

    void Start()
    {
        //��ȡplayer1�������
        animator = transform.Find("player1").GetComponent<Animator>();

        //��ʼ����
        shouldMove = true;
    }

    void Update()
    {
        GameObject player = this.gameObject;
        if(player.transform.position.y < 0)
        {
            collidertest.gameHasEnded = true;
        }

        // ˮƽ�ƶ�
        if (shouldMove)
        {
            // ˮƽ�ƶ�
            transform.position += new Vector3(0, 0, speed * Time.deltaTime);
        }
        else
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();
            // ����X��Y��Z
            rb.constraints = RigidbodyConstraints.FreezePositionX |
                             RigidbodyConstraints.FreezePositionY |
                             RigidbodyConstraints.FreezePositionZ;
        }

        // ����Ƿ�����Ծ�������ڵ�����
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // ִ����Ծ
            Jump();
        }

        //����Ƿ�����Ծ�Լ�δ�������ڿ���
        else if(!isGrounded && !hasjumptwice && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
            hasjumptwice = true;
        }

    }

    void Jump()             //��Ծ
    {
        // �����ɫ�ڵ�����
        if (isGrounded || !hasjumptwice)
        {
            // ����ɫʩ��һ�����ϵ��ٶȣ���ʹ����Ծ
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpspeed, 0);

            // ���µ���״̬
            isGrounded = false;

            if (animator != null)
            {
                animator.Play("jump_start");
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        // ���player�����˵��棬���µ���״̬
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            hasjumptwice = false;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        // ���player��Ȼ�����Ӵ������ֵ���״̬Ϊtrue
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

    public void ModifySpeed(float duration)         //�ٶȷ���
    {
        speed *= 2;
        //����isRushingΪtrue����ʼrush����
        animator.SetBool("isRushing", true);
        // ʹ��Э�̵ȴ�����ʱ�����
        StartCoroutine(EndRushAfterTime(duration));
    }

    private IEnumerator EndRushAfterTime(float duration)
    {
        yield return new WaitForSeconds(duration);
        // ����ʱ����������� isRushing Ϊ false������ rush ����
        animator.SetBool("isRushing", false);
        speed /= 2;
    }
}
