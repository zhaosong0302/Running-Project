using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collidertest : MonoBehaviour
{

    private bool isOrange = true;           //颜色检测模块
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
        //停止角色
        if (gameHasEnded)
        {
            movetest.shouldMove = false;
            Score.ClearScore();
        }

        //Q切换颜色状态
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isOrange = !isOrange;
        }

        //
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPaused = !isPaused;
            // 切换游戏的暂停状态
            if (isPaused)
            {
                // 暂停游戏
                Time.timeScale = 0;
            }
            else
            {
                // 恢复游戏
                Time.timeScale = 1;
            }
        }
    }

    void RestartGame()                  //重启函数
    {
        // 重新加载当前场景
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        movetest.shouldMove = true;
    }

    //碰撞镜面直接结束游戏
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Mirror")
        {
            if (player1 != null) // 添加错误检查
            {
                Destroy(player1.gameObject);
                gameHasEnded = true;
                Invoke("RestartGame", restartDelay);
            }
        }
    }
    
    void OnCollisionStay(Collision collision)       //碰撞颜色检测及重启
    {
        Renderer renderer = collision.gameObject.GetComponent<Renderer>();

        if (renderer != null) // 添加错误检查
        {
            Material material = renderer.material;

            // 获取材质的颜色属性
            Color materialColor = material.color;

            // 创建一个橙色颜色
            Color orange = new Color(1f, 0.5f, 0f);

            if (materialColor == orange && !isOrange)
            {
                if (player1 != null) // 添加错误检查
                {
                    Destroy(player1.gameObject);
                    gameHasEnded = true;
                    Invoke("RestartGame", restartDelay);
                }
            }

            if (materialColor != orange && isOrange)
            {
                Transform player1 = transform.Find("player1"); 
                if (player1 != null) // 添加错误检查
                {
                    Destroy(player1.gameObject);
                    gameHasEnded = true;
                    Invoke("RestartGame", restartDelay);
                }
            }
        }
    }
}