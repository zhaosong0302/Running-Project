using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEnter : MonoBehaviour
{
    private int currentLevelIndex;

    void Start()
    {
        // ��ȡ��ǰ����������
        Scene scene = SceneManager.GetActiveScene();
        currentLevelIndex = scene.buildIndex;
    }

    private void OnTriggerEnter(Collider other)
    {
        // ����ʱ�л�����
        SwitchLevel();
    }

    private void SwitchLevel()
    {
        // �жϵ�ǰ������������Ȼ�������һ������
        if (currentLevelIndex == 1)
        {
            SceneManager.LoadScene(2);
        }
        else if (currentLevelIndex == 2)
        {
            SceneManager.LoadScene(1);
        }
    }
}
