using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileViewContrller : MonoBehaviour
{
    public Text PageText;
    public TextAsset TextFile;
    public int Index;
    List<string> TextList = new List<string>();
    // Start is called before the first frame update
    void Awake()
    {
        Index = 0;
        GetTextFromFile(TextFile);
    }
    void Start()
    {
        PageText.text = TextList[Index];
    }
    void GetTextFromFile(TextAsset file)
    {

        var LineData = file.text.Split('#');
        foreach(var line in LineData)
        {
            TextList.Add(line);
        }
    }
    private void OnDisable()
    {
        TextList.Clear();
        Index = 0;
    }
    public void PageChange(bool change)//传入按钮布尔参数，是为下一页，否为上一页
    {
        if(change)
        {
            if (TextList.Count>Index)
            {
                Index++;
                PageText.text = TextList[Index];
            }
            
        }
        else
        {
            if (Index>0)
            {
                Index--;
                PageText.text = TextList[Index];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
