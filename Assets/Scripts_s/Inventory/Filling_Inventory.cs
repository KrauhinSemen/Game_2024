using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filling_Inventory : MonoBehaviour
{
    public Sprite DefaultSprite;
    public Sprite ToiletKey;
    public Sprite Icon;
    public Sprite PassWorker;
    public Sprite Records;
    private SpriteRenderer SpriteRenderer;
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();

        var items = PlayerPrefs.GetString("items_list").Split("\n");

        for (var i=1; i < 9; i++)
        {
            if (gameObject.name == "Slot " + i && items.Length >= i)
            {
                SpriteRenderer.sprite = ChooseSprite(items[i - 1]);
            }
        }
    }

    private Sprite ChooseSprite(string name)
    {
        if (name == "���� �� �������") return ToiletKey;
        if (name == "����� �� ������") return Icon;
        if (name == "������� ��������") return PassWorker;
        if (name == "������") return Records;
        return DefaultSprite;
    }
}
