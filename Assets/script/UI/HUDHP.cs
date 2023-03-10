using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDHP : MonoBehaviour
{
    public Image HpImage;
    public DataManager dataManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HpImage.fillAmount = dataManager.PlayerHP / 10f;
    }
}
