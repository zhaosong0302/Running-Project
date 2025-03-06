using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
    private Animator animator;
    private bool shouldPlayRunAnimation = false;

    private void OnCollisionEnter(Collision collision)
    {
        shouldPlayRunAnimation = true;
    }

    void Start()
    {
        //��ȡ���������
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (shouldPlayRunAnimation)
        {
            animator.Play("run");
            shouldPlayRunAnimation = false;
        }

        //Q���ı���ɫ����
        if (Input.GetKeyDown(KeyCode.Q))
        {
            animator.Play("change_color");
        }

    }

}
