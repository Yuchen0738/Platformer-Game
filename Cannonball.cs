using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannonball : MonoBehaviour
{
    public float lifetime = 5.0f; // �ڵ�������ʱ�䣨�룩
    public int damage = 10; // �ڵ���ɵ��˺�ֵ
    private bool hasHitEnemy = false; // �Ƿ��Ѿ����е���

    private void Start()
    {
        // ����Э������һ��ʱ��������ڵ�
        StartCoroutine(DestroyAfterLifetime());
    }

    private IEnumerator DestroyAfterLifetime()
    {
        // �ȴ�ָ��������ʱ��
        yield return new WaitForSeconds(lifetime);

        // ������ʱ������������ڵ�
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // ���ڵ�������������ײ��ʱ������Ƿ��ǵ���
        if (!hasHitEnemy && other.CompareTag("Enemy"))
        {
            // ��ȡ���˵��������
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();

            if (enemyHealth != null)
            {
                // �Ե�������˺�
                enemyHealth.TakeDamage(damage);
            }

            // ���Ϊ�Ѿ����е��ˣ������ظ��˺�������
            hasHitEnemy = true;

            // �����ڵ�
            Destroy(gameObject);
        }
    }
}
