using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LinkWall : MonoBehaviour
{
    public bool First;
    public bool Last;
    //public GameObject LinkBox;
    public GameObject Line1;
    public GameObject Line2;
    public GameObject Line3;
    SpriteRenderer Image1;
    SpriteRenderer Image2;
    SpriteRenderer Image3;
    public Sprite on;
    public Sprite off;
    public GameObject NextWall;
    public DataManager dataManager;
    public int Index1;
    public int Index2;
    public int Index3;
    LinkBoxContrller linkBoxcontrller;
    LinkWall linkwall;
    float Position;
    float LastPosition;
    bool InPoint;
    // Start is called before the first frame update
    void Start()
    {
        Image1 = Line1.GetComponent<SpriteRenderer>();
        Image2 = Line2.GetComponent<SpriteRenderer>();
        Image3 = Line3.GetComponent<SpriteRenderer>();
        if (First)
        {
            Position = 2;
        }
        if(!Last)
        {
            linkwall = NextWall.GetComponent<LinkWall>();
            Image1.sprite = off;
            Image2.sprite = off;
            Image3.sprite = off;
        }
        else
        {
            if (!dataManager.LockList[Index1])
            {
                Image1.sprite = on;

            }
            if (!dataManager.LockList[Index2])
            {

                Image2.sprite = on;
            }
            if (!dataManager.LockList[Index3])
            {
                Image3.sprite = on;
            }
        }





    }
    private void OnTriggerEnter2D(Collider2D other)

    {
        //Debug.Log("已碰到东西");
        if (other.gameObject.CompareTag("LinkBox"))
        {

            InPoint = true;
            //LinkBox = other.gameObject;
            linkBoxcontrller = other.gameObject.GetComponent<LinkBoxContrller>();
            

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("LinkBox"))
        {

            InPoint = false;
            linkBoxcontrller = null;
            if(!Last)
            {
                Image1.sprite = off;
                Image2.sprite = off;
                Image3.sprite = off;
            }

        }
    }
    // Update is called once per frame
    void Update()
    {
        if(InPoint&&(Position!=0))
        {
            switch (Position)
            {
                case 1:
                    if(Last)
                    {
                        LastPosition = linkBoxcontrller.Link.x + Position;
                    }
                    else
                    {
                        linkwall.Position = linkBoxcontrller.Link.x + Position;
                    }

                    break;
                case 2:
                    if (Last)
                    {
                        LastPosition = linkBoxcontrller.Link.y + Position;
                    }
                    else
                    {
                        linkwall.Position = linkBoxcontrller.Link.y + Position;
                    }

                    break;
                case 3:
                    if (Last)
                    {
                        LastPosition = linkBoxcontrller.Link.z + Position;
                    }
                    else
                    {
                        linkwall.Position = linkBoxcontrller.Link.z + Position;
                    }

                    break;
                default:

                    break;

            }
            //Debug.Log(LastPosition);
            if(!Last)
            {

                switch (linkwall.Position)
                {
                    case 1:
                        Image1.sprite = on;
                        Image2.sprite = off;
                        Image3.sprite = off;
                        break;
                    case 2:
                        Image1.sprite = off;
                        Image2.sprite = on;
                        Image3.sprite = off;
                        break;
                    case 3:
                        Image1.sprite = off;
                        Image2.sprite = off;
                        Image3.sprite = on;
                        break;
                    default:
                        Image1.sprite = off;
                        Image2.sprite = off;
                        Image3.sprite = off;
                        break;



                }
            }

        }
        if(Last)
        {
            switch (LastPosition)
            {
                case 1:
                    dataManager.LockList[Index1] = false;
                    Image1.sprite = on;
                    break;
                case 2:
                    dataManager.LockList[Index2] = false;
                    Image2.sprite = on;
                    break;
                case 3:
                    dataManager.LockList[Index3] = false;
                    Image3.sprite = on;
                    break;
                default:
                    break;
            }
        }
    }
}
