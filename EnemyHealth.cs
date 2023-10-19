using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // ���˵��������ֵ
    private int currentHealth; // ��ǰ����ֵ

    private void Start()
    {
        currentHealth = maxHealth;
    }

    // �����ܵ��˺�ʱ���ø÷���
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ��������ʱ���ø÷���
    private void Die()
    {
        // �ڵ�������ʱִ����ص��߼������粥���������������ٵ��˵�
        Destroy(gameObject);
        int rewardGold = 10; // �˴����ý�����ҵ�����
        GameManager.instance.AddGoldOnEnemyDeath(rewardGold);

        // ���ٵ��˶���
        Destroy(gameObject);
    }
}
 