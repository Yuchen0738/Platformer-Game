using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffMap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �����ײ�Ķ����Ƿ����ڵ�
        if (collision.CompareTag("Cannonball"))
        {
            // �����ڵ�
            Destroy(collision.gameObject);
        }
    }
}
