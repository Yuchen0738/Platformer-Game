using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // 敌人的最大生命值
    private int currentHealth; // 当前生命值

    private void Start()
    {
        currentHealth = maxHealth;
    }

    // 敌人受到伤害时调用该方法
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // 敌人死亡时调用该方法
    private void Die()
    {
        // 在敌人死亡时执行相关的逻辑，比如播放死亡动画、销毁敌人等
        Destroy(gameObject);
        int rewardGold = 10; // 此处设置奖励金币的数量
        GameManager.instance.AddGoldOnEnemyDeath(rewardGold);

        // 销毁敌人对象
        Destroy(gameObject);
    }
}
 