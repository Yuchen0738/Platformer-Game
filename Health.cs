using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public class Health : MonoBehaviour
{
    public int maxHealth = 100;         // 敌人的最大生命值
    private int currentHealth;          // 当前生命值

    private void Start()
    {
        currentHealth = maxHealth;
    }

    // 受到伤害
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // 检查是否死亡
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // 死亡处理
    private void Die()
    {
        // 在此处添加敌人死亡后的处理逻辑，例如销毁敌人、玩家获得金币等
        Destroy(gameObject);
    }
}
