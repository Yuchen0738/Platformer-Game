using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject artillery; // 塔防的预制件
    public float attackRange = 10f; // 塔防的攻击范围
    public int damage = 10; // 塔防的攻击力

    private GameObject enemy; // 敌人对象
    private GameManager gameManager; // GameManager 的引用

    public int costOfArtillery = 10; // 塔防的金币成本

    private void Start()
    {
        // 在 Start 方法中初始化 enemy 变量，根据您的游戏逻辑获取敌人对象的引用
        enemy = GameObject.FindWithTag("Enemy"); // 假设敌人有一个标签为 "Enemy"

        // 获取 GameManager 的引用
        gameManager = GameManager.instance;
    }

    private void Update()
    {
        // 检测鼠标点击
        if (Input.GetMouseButtonDown(0))
        {
            // 在实例化之前检查 artillery 变量是否被正确分配
            if (artillery != null && gameManager != null)
            {
                // 检查玩家是否有足够的金币来放置塔防
                if (gameManager.HasEnoughGold(costOfArtillery))
                {
                    Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    pos.z = 0f; // 如果您的游戏是2D的，通常只需在 z 坐标上将其设置为0
                    Instantiate(artillery, pos, Quaternion.identity);

                    // 调用 GameManager 的 UseGold 方法扣除金币
                    gameManager.UseGold(costOfArtillery);
                }
                else
                {
                    Debug.Log("金币不足，无法放置塔防");
                }
            }
            else
            {
                // 处理 artillery 未分配的情况
            }
        }

        // 检查是否有敌人，并且在攻击范围内
        if (enemy != null)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance <= attackRange)
            {
                // 进行攻击逻辑
            }
        }
        else
        {
            // 如果没有找到敌人，您可以在这里执行其他逻辑或输出一条调试消息
            Debug.Log("没有找到敌人");
        }
    }
}




