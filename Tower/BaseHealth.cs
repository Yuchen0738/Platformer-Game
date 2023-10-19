using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BaseHealth : MonoBehaviour
{
    public int maxHealth = 100;  // 大本营的最大生命值
    private int currentHealth;   // 当前生命值

    public TMP_Text healthText;      // 用于显示生命值的 UI Text
    public string gameOverSceneName = "GameOver";  // GameOver 场景的名称

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    // 处理大本营受到伤害的逻辑
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // 检查是否生命值小于等于0，如果是，则大本营被摧毁
        if (currentHealth <= 0)
        {
            DestroyBase();
        }

        UpdateHealthText();
    }

    // 更新 UI Text 显示的生命值
    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Base Health: " + currentHealth.ToString();
        }
    }

    // 当大本营被摧毁时的处理
    private void DestroyBase()
    {
        // 加载 GameOver 场景
        SceneManager.LoadScene(gameOverSceneName, LoadSceneMode.Single);
    }
}
