using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Enemy;      // ���˵�Ԥ�Ƽ�
    public float spawnInterval = 2f;    // ���ɵ��˵ļ��ʱ��

    public Transform[] waypoints;      // �������ߵ�·����

    private float nextSpawnTime;        // �´����ɵ��˵�ʱ��

    private void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
    }

    private void Update()
    {
        // ����Ƿ񵽴����ɵ��˵�ʱ��
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    private void SpawnEnemy()
    {
        // ���ɵ��������λ��
        GameObject newEnemy = Instantiate(Enemy, waypoints[0].position, Quaternion.identity);
    


        // ���õ��˵�·��
        EnemyMovement enemyMovement = newEnemy.GetComponent<EnemyMovement>();

        if (enemyMovement != null)
        {
            enemyMovement.SetWaypoints(waypoints);
        }
    }
}
