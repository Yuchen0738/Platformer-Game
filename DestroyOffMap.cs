using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffMap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 检测碰撞的对象是否是炮弹
        if (collision.CompareTag("Cannonball"))
        {
            // 销毁炮弹
            Destroy(collision.gameObject);
        }
    }
}
