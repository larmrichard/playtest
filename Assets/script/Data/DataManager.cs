using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New DataManager", menuName = "DataManager/New DataManager")]
public class DataManager : ScriptableObject
{
   public int BagSize;
   public int PlayerHP;
   public Item Incense;
   public Vector3 Position;
    [Header("装备页面")]
    public Item Slot1;
    public Item Slot2;
    public Item Slot3;
    public Item Slot4;


    public List<bool> LockList=new List<bool>();
   public List<bool> FunctionList = new List<bool>();
    public List<int> FunctionListInt = new List<int>();
    public List<float>EnemyHPList = new List<float>();
   public List<bool> FileLock = new List<bool>();
    public List<bool> ItemOnWorld = new List<bool>();
    public List<Vector3> PositionList = new List<Vector3>();
}
