using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBoundary : MonoBehaviour
{
    // ���ڵ����봥����ʱ����
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ������봥�������������ڵ��������ڵ�
        if (other.CompareTag("New Prefab"))
        {
            Destroy(other.gameObject);
        }
    }
}
