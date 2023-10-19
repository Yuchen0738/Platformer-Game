using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBoundary : MonoBehaviour
{
    // 当炮弹进入触发器时调用
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 如果进入触发器的物体是炮弹，销毁炮弹
        if (other.CompareTag("New Prefab"))
        {
            Destroy(other.gameObject);
        }
    }
}
