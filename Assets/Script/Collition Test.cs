using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collidertest : MonoBehaviour
{

    private bool isOrange = true;           //��ɫ���ģ��
    private bool isPaused = false;
    public static bool gameHasEnded = false;
    public float restartDelay = 2f;
    private Rigidbody rb;
    MoveTest movetest;
    Transform player1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        movetest = GetComponent<MoveTest>();
        player1 = transform.Find("player1");
        gameHasEnded = false;
    }
    void Update()
    {
        //ֹͣ��ɫ
        if (gameHasEnded)
        {
            movetest.shouldMove = false;
            Score.ClearScore();
        }

        //Q�л���ɫ״̬
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isOrange = !isOrange;
        }

        //
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            // �л���Ϸ����ͣ״̬
            if (isPaused)
            {
                // ��ͣ��Ϸ
                Time.timeScale = 0;
            }
            else
            {
                // �ָ���Ϸ
                Time.timeScale = 1;
            }
        }
    }

    void RestartGame()                  //��������
    {
        // ���¼��ص�ǰ����
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        movetest.shouldMove = true;
    }

    //��ײ����ֱ�ӽ�����Ϸ
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Mirror")
        {
            if (player1 != null) // ��Ӵ�����
            {
                Destroy(player1.gameObject);
                gameHasEnded = true;
                Invoke("RestartGame", restartDelay);
            }
        }
    }
    
    void OnCollisionStay(Collision collision)       //��ײ��ɫ��⼰����
    {
        Renderer renderer = collision.gameObject.GetComponent<Renderer>();

        if (renderer != null) // ��Ӵ�����
        {
            Material material = renderer.material;

            // ��ȡ���ʵ���ɫ����
            Color materialColor = material.color;

            // ����һ����ɫ��ɫ
            Color orange = new Color(1f, 0.5f, 0f);

            if (materialColor == orange && !isOrange)
            {
                if (player1 != null) // ��Ӵ�����
                {
                    Destroy(player1.gameObject);
                    gameHasEnded = true;
                    Invoke("RestartGame", restartDelay);
                }
            }

            if (materialColor != orange && isOrange)
            {
                Transform player1 = transform.Find("player1"); 
                if (player1 != null) // ��Ӵ�����
                {
                    Destroy(player1.gameObject);
                    gameHasEnded = true;
                    Invoke("RestartGame", restartDelay);
                }
            }
        }
    }
}