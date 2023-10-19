using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject[] towerPrefabs; // ��ͬ���͵���Ԥ�Ƽ�
    public int[] towerCosts; // ���ļ۸�

    private int selectedTowerIndex = 0; // ��ǰѡ�е�������

    private void Update()
    {
        // ������¼�
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // ��������Ͷ��
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider);

                // ������������Ƿ��б�ǩ "BuildArea"
                if (hit.collider.CompareTag("BuildArea"))
                {
                    // ���н����߼�
                    if (CanAffordTower())
                    {
                        BuildTower(hit.point);
                    }
                }
            }
        }
    }

    // �ж�����Ƿ��ܹ�����ǰѡ�е���
    private bool CanAffordTower()
    {
        Debug.Log("can build?");
        return GameManager.instance.GetCurrentGold() >= towerCosts[selectedTowerIndex];
    }

    // ���򲢽�����
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

    // �л���ǰѡ�е�������
    public void SelectTower(int index)
    {
        selectedTowerIndex = index;
    }
}


