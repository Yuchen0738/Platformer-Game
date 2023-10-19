using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject[] towerPrefabs; // 不同类型的塔预制件
    public int[] towerCosts; // 塔的价格

    private int selectedTowerIndex = 0; // 当前选中的塔类型

    private void Update()
    {
        // 检测点击事件
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // 进行射线投射
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider);

                // 检查点击的物体是否有标签 "BuildArea"
                if (hit.collider.CompareTag("BuildArea"))
                {
                    // 进行建造逻辑
                    if (CanAffordTower())
                    {
                        BuildTower(hit.point);
                    }
                }
            }
        }
    }

    // 判断玩家是否能够购买当前选中的塔
    private bool CanAffordTower()
    {
        Debug.Log("can build?");
        return GameManager.instance.GetCurrentGold() >= towerCosts[selectedTowerIndex];
    }

    // 购买并建造塔
    private void BuildTower(Vector3 position)
    {
        if (selectedTowerIndex < towerPrefabs.Length)
        {
            if (CanAffordTower())
            {
                GameObject newTower = Instantiate(towerPrefabs[selectedTowerIndex], position, Quaternion.identity);
                GameManager.instance.UseGold(towerCosts[selectedTowerIndex]);
            }
        }
    }

    // 切换当前选中的塔类型
    public void SelectTower(int index)
    {
        selectedTowerIndex = index;
    }
}


