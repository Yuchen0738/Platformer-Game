using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;      // 敌人的预制件
    public float spawnInterval = 2f;    // 生成敌人的间隔时间

    public Transform[] waypoints;      // 敌人行走的路径点

    private float nextSpawnTime;        // 下次生成敌人的时间

    private void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    private void Update()
    {
        // 检查是否到达生成敌人的时间
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void SpawnEnemy()
    {
        // 生成敌人在入口位置
        GameObject newEnemy = Instantiate(Enemy, waypoints[0].position, Quaternion.identity);
    


        // 设置敌人的路径
        EnemyMovement enemyMovement = newEnemy.GetComponent<EnemyMovement>();

        if (enemyMovement != null)
        {
            enemyMovement.SetWaypoints(waypoints);
        }
    }
}
