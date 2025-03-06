using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEnter : MonoBehaviour
{
    private int currentLevelIndex;

    void Start()
    {
        // 获取当前场景的索引
        Scene scene = SceneManager.GetActiveScene();
        currentLevelIndex = scene.buildIndex;
    }

    private void OnTriggerEnter(Collider other)
    {
        // 触发时切换场景
        SwitchLevel();
    }

    private void SwitchLevel()
    {
        // 判断当前场景的索引，然后加载另一个场景
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
