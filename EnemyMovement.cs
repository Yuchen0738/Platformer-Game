using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public int damageToBase = 10;  // 敌人造成的伤害
    private Transform[] waypoints;  // 敌人行走的路径点
    private int currentWaypointIndex;  // 当前目标路径点的索引
    private BaseHealth baseHealth; // 大本营的生命值脚本

    public float moveSpeed = 2f;  // 敌人移动速度

    private void Start()
    {
        currentWaypointIndex = 0;
        baseHealth = GameObject.Find("Base").GetComponent<BaseHealth>(); // 请确保你的大本营对象的名称为 "Base"，如果不是，请将其替换为正确的名称
    }

    private void Update()
    {
        MoveToWaypoint();
    }

    public void SetWaypoints(Transform[] waypoints)
    {
        this.waypoints = waypoints;
        currentWaypointIndex = 0; // 设置当前目标路径点为数组的第一个路径点
    }

    private void MoveToWaypoint()
    {
        if (waypoints == null || waypoints.Length == 0)
            return;

        // 移动到当前目标路径点
        Vector3 targetPosition = waypoints[currentWaypointIndex].position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        // 检查是否到达当前路径点
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f) // 这里使用小于 0.1f 的阈值
        {
            // 更新下一个目标路径点的索引
            currentWaypointIndex++;
            // 如果到达了终点，则销毁敌人
            if (currentWaypointIndex >= waypoints.Length)
            {
                if (baseHealth != null)
                {
                    baseHealth.TakeDamage(damageToBase); // 减少大本营生命值
                }
                Destroy(gameObject);
            }
        }
    }
}
