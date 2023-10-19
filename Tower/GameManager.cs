using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // GameManager��ʵ��

    public int startingGold = 500; // ��ҳ�ʼ�������
    private int currentGold; // ��ǰ��ҽ������

    public TMP_Text goldText; // ������ʾ��ҽ������UI Text���

    private void Awake()
    {
        // ȷ��GameManagerֻ��һ��ʵ��
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

    // ��ȡ��ǰ��ҽ������
    public int GetCurrentGold()
    {
        return currentGold;
    }

    // �ж�����Ƿ����㹻�Ľ��
    public bool HasEnoughGold(int amount)
    {
        return currentGold >= amount;
    }

    // ʹ�ý��
    public void UseGold(int amount)
    {
        if (currentGold >= amount)
        {
            currentGold -= amount;
            UpdateGoldText();
        }
        else
        {
            Debug.Log("��Ҳ��㣬�޷��۳� " + amount + " ���");
        }
    }

    // ���ӽ��
    public void AddGold(int amount)
    {
        currentGold += amount;
        UpdateGoldText();
    }

    // ������ʾ��ҽ������UI Text
    private void UpdateGoldText()
    {
        if (goldText != null)
        {
            goldText.text = "Gold: " + currentGold;
        }
    }

    // ���ӽ�ҵķ��������������ű��е���
    public void AddGoldOnEnemyDeath(int amount)
    {
        AddGold(amount);
    }
}


