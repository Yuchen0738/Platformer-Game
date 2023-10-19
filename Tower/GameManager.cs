using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // GameManager的实例

    public int startingGold = 500; // 玩家初始金币数量
    private int currentGold; // 当前玩家金币数量

    public TMP_Text goldText; // 用于显示玩家金币数的UI Text组件

    private void Awake()
    {
        // 确保GameManager只有一个实例
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentGold = startingGold;
        UpdateGoldText();
    }

    // 获取当前玩家金币数量
    public int GetCurrentGold()
    {
        return currentGold;
    }

    // 判断玩家是否有足够的金币
    public bool HasEnoughGold(int amount)
    {
        return currentGold >= amount;
    }

    // 使用金币
    public void UseGold(int amount)
    {
        if (currentGold >= amount)
        {
            currentGold -= amount;
            UpdateGoldText();
        }
        else
        {
            Debug.Log("金币不足，无法扣除 " + amount + " 金币");
        }
    }

    // 增加金币
    public void AddGold(int amount)
    {
        currentGold += amount;
        UpdateGoldText();
    }

    // 更新显示玩家金币数的UI Text
    private void UpdateGoldText()
    {
        if (goldText != null)
        {
            goldText.text = "Gold: " + currentGold;
        }
    }

    // 增加金币的方法，可在其他脚本中调用
    public void AddGoldOnEnemyDeath(int amount)
    {
        AddGold(amount);
    }
}


