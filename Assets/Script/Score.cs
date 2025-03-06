using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Text; // 用于显示积分的 Text 对象
    public static int score = 0; // 积分值
    public float ScoreIncreaseRate = 1f; // 积分增长速率
    void Start()
    {
        if( !collidertest.gameHasEnded)
        {
            InvokeRepeating("IncreaseScore", 1f, ScoreIncreaseRate); // 每隔一秒调用 IncreaseScore 方法
                                                                     // 加载保存的积分值，如果没有保存则默认为0
            score = PlayerPrefs.GetInt("Score", 0);
        }
    }

    // 增加积分方法
    void IncreaseScore()
    {
        score++; // 每次增加 1 分随后更新以及保存
        UpdateScoreText();
        SaveScore();
    }

    // 更新 UI 文本显示
    private void UpdateScoreText()
    {
        Text.text = "Score: " + score.ToString(); // 更新 Text 对象的文本内容
    }

    // 保存积分值到 PlayerPrefs
    private void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save(); // 确保数据被立即保存
    }

    //清空方法
    public static void ClearScore() 
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.Save();
    }
}
