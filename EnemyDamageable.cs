using UnityEngine;

public class EnemyDamageable : MonoBehaviour
{
    public bool canBeDamaged = true; // 是否可以受到伤害

    // 在敌人受到伤害时调用该方法
    public void TakeDamage(int damage)
    {
        if (canBeDamaged)
        {
            // 在这里处理受伤逻辑，比如减少血量等
        }
    }
}

