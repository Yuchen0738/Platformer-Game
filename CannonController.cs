using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject cannonballPrefab; // �ڵ�Ԥ�Ƽ�
    public Transform cannonEnd; // �ڹܵ�ĩ�ˣ��ڵ�����λ�ã�
    public float cannonballSpeed = 10f; // �ڵ��ٶ�
    public float fireRate = 2.0f; // ���÷������ʣ�ÿ�뷢��һ��
    public float enemyDetectionInterval = 0.1f; // ���˼��ʱ����
    private float nextFireTime = 0.0f;
    private float nextDetectionTime = 0.0f;
    private GameObject closestEnemy = null;

    void Update()
    {
        // ��ȡ��ǰʱ��
        float currentTime = Time.time;

        // �����ǰʱ�������һ�η���ʱ�䣬��������
        if (currentTime > nextFireTime)
        {
            // �������д��� "Enemy" ��ǩ�ĵ��˶���
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            // ���û���ҵ����ˣ�ֱ�ӷ���
            if (enemies.Length == 0)
            {
                return;
            }

            // �ҵ�����ĵ���
            closestEnemy = GetClosestEnemy(enemies);

            // ����ҵ�������ĵ���
            if (closestEnemy != null)
            {
                // ���������ڵ��ķ���
                FireCannon();

                // ������һ�η���ʱ��
                nextFireTime = currentTime + 1.0f / fireRate; // ������һ�η���ʱ��
            }
        }

        // �����ǰʱ�������һ�ε��˼��ʱ�䣬�������˼��
        if (currentTime > nextDetectionTime)
        {
            // �������˼��ķ���
            DetectEnemy();

            // ������һ�ε��˼��ʱ��
            nextDetectionTime = currentTime + enemyDetectionInterval;
        }
    }

    GameObject GetClosestEnemy(GameObject[] enemies)
    {
        GameObject closest = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance)
            {
                closest = enemy;
                closestDistance = distance;
            }
        }

        return closest;
    }

    void FireCannon()
    {
        if (closestEnemy == null)
        {
            return; // û���ҵ�Ŀ�꣬������
        }

        // �����ڵ����ٶȷ��򣬳�������ĵ���
        Vector2 direction = (closestEnemy.transform.position - cannonEnd.position).normalized;

        // �����ڵ�ʵ�������������ʼλ��
        GameObject cannonball = Instantiate(cannonballPrefab, cannonEnd.position, Quaternion.identity);

        // ��ȡ�ڵ���Rigidbody2D���
        Rigidbody2D rb = cannonball.GetComponent<Rigidbody2D>();

        // �����ڵ����ٶ�
        rb.velocity = direction * cannonballSpeed;
    }

    // ��ӵ��˼��ķ���
    void DetectEnemy()
    {
        // �������д���˼���߼�
        // ����Ը�����Ҫ�����ﴦ����˼�������߼�
        // ������ֵ��ˣ����Ը��� closestEnemy ����
    }
}

