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
    public int maxHealth = 100;         // ���˵��������ֵ
    private int currentHealth;          // ��ǰ����ֵ

    private void Start()
    {
        currentHealth = maxHealth;
    }

    // �ܵ��˺�
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // ����Ƿ�����
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // ��������
    private void Die()
    {
        // �ڴ˴���ӵ���������Ĵ����߼����������ٵ��ˡ���һ�ý�ҵ�
        Destroy(gameObject);
    }
}
