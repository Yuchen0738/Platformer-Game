using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public float lifetime = 5.0f; // 炮弹的生存时间（秒）
    public int damage = 10; // 炮弹造成的伤害值
    private bool hasHitEnemy = false; // 是否已经击中敌人

    private void Start()
    {
        // 启动协程以在一定时间后销毁炮弹
        StartCoroutine(DestroyAfterLifetime());
    }

    private IEnumerator DestroyAfterLifetime()
    {
        // 等待指定的生存时间
        yield return new WaitForSeconds(lifetime);

        // 在生存时间结束后销毁炮弹
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 当炮弹触发了其他碰撞器时，检查是否是敌人
        if (!hasHitEnemy && other.CompareTag("Enemy"))
        {
            // 获取敌人的生命组件
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                // 对敌人造成伤害
                enemyHealth.TakeDamage(damage);
            }

            // 标记为已经击中敌人，避免重复伤害和销毁
            hasHitEnemy = true;

            // 销毁炮弹
            Destroy(gameObject);
        }
    }
}
