using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Item",menuName="Inventory/New Item")]
public class Item : ScriptableObject
{
public string ItemName;

[Header("弹药蓄力时间")]
public float ChargeTime;

public Sprite ItemImage;
public Sprite ItemImage1;
public Sprite ItemImage2;
public Sprite SelectedImage;
[TextArea]
public string ItemDescription;
public bool Important;
public int ItemMaxHeld=3;
public List<Item> CombinList = new List<Item>();
public List<Item> CombinResult = new List<Item>();
}
