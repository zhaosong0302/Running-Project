using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TMPro.TextMeshProUGUI Text; // ������ʾ���ֵ� Text ����
    public static int score = 0; // ����ֵ
    public float ScoreIncreaseRate = 1f; // ������������
    void Start()
    {
        if( !collidertest.gameHasEnded)
        {
            InvokeRepeating("IncreaseScore", 1f, ScoreIncreaseRate); // ÿ��һ����� IncreaseScore ����
                                                                     // ���ر���Ļ���ֵ�����û�б�����Ĭ��Ϊ0
            score = PlayerPrefs.GetInt("Score", 0);
        }
    }

    // ���ӻ��ַ���
    void IncreaseScore()
    {
        score++; // ÿ������ 1 ���������Լ�����
        UpdateScoreText();
        SaveScore();
    }

    // ���� UI �ı���ʾ
    private void UpdateScoreText()
    {
        Text.text = "Score: " + score.ToString(); // ���� Text ������ı�����
    }

    // �������ֵ�� PlayerPrefs
    private void SaveScore()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save(); // ȷ�����ݱ���������
    }

    //��շ���
    public static void ClearScore() 
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.Save();
    }
}
