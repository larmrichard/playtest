using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class LoadManager : MonoBehaviour
{
    public Inventory myBag;
    public DataManager dataManager;
    Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("player").transform;
    }
    public void LoadGame()
    {
        BinaryFormatter loadformatter = new BinaryFormatter();
        if (File.Exists(Application.persistentDataPath + "Game_SaveData/MyBag.txt"))
        {
            FileStream bagfile = File.Open(Application.persistentDataPath + "Game_SaveData/MyBag.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)loadformatter.Deserialize(bagfile), myBag);
            bagfile.Close();
        }
        if (File.Exists(Application.persistentDataPath + "Game_SaveData/Data.txt"))
        {
            FileStream datafile = File.Open(Application.persistentDataPath + "Game_SaveData/Data.txt", FileMode.Open);
            JsonUtility.FromJsonOverwrite((string)loadformatter.Deserialize(datafile), dataManager);
            datafile.Close();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        

        Debug.Log("∂¡»°≥…π¶");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
