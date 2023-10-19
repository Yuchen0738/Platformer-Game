using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BaseHealth : MonoBehaviour
{
    public int maxHealth = 100;  // ��Ӫ���������ֵ
    private int currentHealth;   // ��ǰ����ֵ

    public TMP_Text healthText;      // ������ʾ����ֵ�� UI Text
    public string gameOverSceneName = "GameOver";  // GameOver ����������

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthText();
    }

    // �����Ӫ�ܵ��˺����߼�
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // ����Ƿ�����ֵС�ڵ���0������ǣ����Ӫ���ݻ�
        if (currentHealth <= 0)
        {
            DestroyBase();
        }

        UpdateHealthText();
    }

    // ���� UI Text ��ʾ������ֵ
    private void UpdateHealthText()
    {
        if (healthText != null)
        {
            healthText.text = "Base Health: " + currentHealth.ToString();
        }
    }

    // ����Ӫ���ݻ�ʱ�Ĵ���
    private void DestroyBase()
    {
        // ���� GameOver ����
        SceneManager.LoadScene(gameOverSceneName, LoadSceneMode.Single);
    }
}
