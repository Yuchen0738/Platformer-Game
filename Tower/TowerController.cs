using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    public GameObject artillery; // ������Ԥ�Ƽ�
    public float attackRange = 10f; // �����Ĺ�����Χ
    public int damage = 10; // �����Ĺ�����

    private GameObject enemy; // ���˶���
    private GameManager gameManager; // GameManager ������

    public int costOfArtillery = 10; // �����Ľ�ҳɱ�

    private void Start()
    {
        // �� Start �����г�ʼ�� enemy ����������������Ϸ�߼���ȡ���˶��������
        enemy = GameObject.FindWithTag("Enemy"); // ���������һ����ǩΪ "Enemy"

        // ��ȡ GameManager ������
        gameManager = GameManager.instance;
    }

    private void Update()
    {
        // ��������
        if (Input.GetMouseButtonDown(0))
        {
            // ��ʵ����֮ǰ��� artillery �����Ƿ���ȷ����
            if (artillery != null && gameManager != null)
            {
                // �������Ƿ����㹻�Ľ������������
                if (gameManager.HasEnoughGold(costOfArtillery))
                {
                    Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    pos.z = 0f; // ���������Ϸ��2D�ģ�ͨ��ֻ���� z �����Ͻ�������Ϊ0
                    Instantiate(artillery, pos, Quaternion.identity);

                    // ���� GameManager �� UseGold �����۳����
                    gameManager.UseGold(costOfArtillery);
                }
                else
                {
                    Debug.Log("��Ҳ��㣬�޷���������");
                }
            }
            else
            {
                // ���� artillery δ��������
            }
        }

        // ����Ƿ��е��ˣ������ڹ�����Χ��
        if (enemy != null)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);
            if (distance <= attackRange)
            {
                // ���й����߼�
            }
        }
        else
        {
            // ���û���ҵ����ˣ�������������ִ�������߼������һ��������Ϣ
            Debug.Log("û���ҵ�����");
        }
    }
}




