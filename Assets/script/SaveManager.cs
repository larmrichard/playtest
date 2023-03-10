using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    public Inventory myBag;
    public DataManager dataManager;
    public Transform SpawnPoint;
    public Vector3 Postion;
    // Start is called before the first frame update
    void Start()
    {
        Postion=SpawnPoint.position;
    }
    private void OnEnable()
    {
        Time.timeScale = 0f;
    }
    private void OnDisable()
    {
        Time.timeScale = 1f;
    }
    public void SaveGame()
    {
        dataManager.Position = Postion;
        Debug.Log(Application.persistentDataPath);
        if(!Directory.Exists(Application.persistentDataPath+"Game_SaveData"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "Game_SaveData");
        }
        BinaryFormatter saveformatter=new BinaryFormatter();
        FileStream bagfile = File.Create(Application.persistentDataPath + "Game_SaveData/MyBag.txt");
        var bagjson = JsonUtility.ToJson(myBag);
        saveformatter.Serialize(bagfile, bagjson);
        bagfile.Close();
        FileStream datafile = File.Create(Application.persistentDataPath + "Game_SaveData/Data.txt");
        var datajson = JsonUtility.ToJson(dataManager);
        saveformatter.Serialize(datafile, datajson);
        datafile.Close();
        Debug.Log("±£´æ³É¹¦");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
