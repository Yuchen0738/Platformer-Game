using UnityEngine;

public class EnemyDamageable : MonoBehaviour
{
    public bool canBeDamaged = true; // �Ƿ�����ܵ��˺�

    // �ڵ����ܵ��˺�ʱ���ø÷���
    public void TakeDamage(int damage)
    {
        if (canBeDamaged)
        {
            // �����ﴦ�������߼����������Ѫ����
        }
    }
}

