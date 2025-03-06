using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickToStart : MonoBehaviour
{
    public bool flag;
    GameObject canvas;
    void Start()
    {
        canvas = this.gameObject;
        canvas.SetActive(false);
        Invoke("GameStart", 10f);
    }

    void Update()
    {
        if (flag && Input.GetMouseButtonDown(0)) // 如果左键被按下
        {
            SceneManager.LoadScene("Level 0");
            Score.ClearScore();
        }
    }

    void GameStart()
    {
        flag = true;
        canvas.SetActive(true);
    }
}