using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject cannonballPrefab; // 炮弹预制件
    public Transform cannonEnd; // 炮管的末端（炮弹发射位置）
    public float cannonballSpeed = 10f; // 炮弹速度
    public float fireRate = 2.0f; // 设置发射速率，每秒发射一次
    public float enemyDetectionInterval = 0.1f; // 敌人检测时间间隔
    private float nextFireTime = 0.0f;
    private float nextDetectionTime = 0.0f;
    private GameObject closestEnemy = null;

    void Update()
    {
        // 获取当前时间
        float currentTime = Time.time;

        // 如果当前时间大于下一次发射时间，触发发射
        if (currentTime > nextFireTime)
        {
            // 查找所有带有 "Enemy" 标签的敌人对象
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            // 如果没有找到敌人，直接返回
            if (enemies.Length == 0)
            {
                return;
            }

            // 找到最近的敌人
            closestEnemy = GetClosestEnemy(enemies);

            // 如果找到了最近的敌人
            if (closestEnemy != null)
            {
                // 触发发射炮弹的方法
                FireCannon();

                // 更新下一次发射时间
                nextFireTime = currentTime + 1.0f / fireRate; // 计算下一次发射时间
            }
        }

        // 如果当前时间大于下一次敌人检测时间，触发敌人检测
        if (currentTime > nextDetectionTime)
        {
            // 触发敌人检测的方法
            DetectEnemy();

            // 更新下一次敌人检测时间
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
            return; // 没有找到目标，不发射
        }

        // 计算炮弹的速度方向，朝向最近的敌人
        Vector2 direction = (closestEnemy.transform.position - cannonEnd.position).normalized;

        // 创建炮弹实例，并设置其初始位置
        GameObject cannonball = Instantiate(cannonballPrefab, cannonEnd.position, Quaternion.identity);

        // 获取炮弹的Rigidbody2D组件
        Rigidbody2D rb = cannonball.GetComponent<Rigidbody2D>();

        // 设置炮弹的速度
        rb.velocity = direction * cannonballSpeed;
    }

    // 添加敌人检测的方法
    void DetectEnemy()
    {
        // 在这里编写敌人检测逻辑
        // 你可以根据需要在这里处理敌人检测的相关逻辑
        // 如果发现敌人，可以更新 closestEnemy 变量
    }
}

