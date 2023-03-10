using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;//加载编辑器

public class playercontrller : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("人物参数")]
    private float speed;
    public float CrouchSpeed = 0.7f;//下蹲时的速度
    public float StandSpeed = 1.5f;//站立时的速度
    public float PullSpeed = 0.7f;//推箱子时的速度
    public float PullRange = 2f;//能推拉到箱子的距离
    public LayerMask BoxLayer;
    public LayerMask BoxCanCilmbLayer;
    public float WaitTime = 0.5f;//用于重置判定的等待时间
    public float StiffTime = 0.8f;//硬直时间
    private float PullRayOffset;//射线起点偏移量
    float move;
    Rigidbody2D rbody;//获取刚体组件
    public Animator anim;//动画组件
    int IsCrouchId= Animator.StringToHash("IsCrouch");
    public Rigidbody2D item;
    public Transform itemspawn;//定义攻击特效创建位置
    public int itemnum;//道具数量
    string TargetSpawn;//定义字符串“TargetSpawn”
    public PosController poscontroller;//定义PosController脚本
    public DataManager dataManager;
    public Inventory MyBag;

    public GameObject FlamePrefab;
    public GameObject Flame;
    public GameObject IncenseYPrefab;
    public GameObject Box;
    public GameObject AnimIdle;
    public GameObject AnimRun;
    public GameObject AnimCharge;
    public GameObject AnimATK;

    private CapsuleCollider2D CC2D;//定义下蹲参数
    Vector2 CC2DSSize;//角色站立盒子尺寸
    Vector2 CC2DCSize;//角色蹲下盒子尺寸
    Vector2 CC2DSOffset;//角色站立盒子位置
    Vector2 CC2DCOffset;//角色蹲下盒子位置

    public static Item Incense1;//定义弹药
    public static Item Incense2;
    public static Item Incense3;
    public static Item Incense4;

    [Header("人物状态")]
    public bool OnStair;
    public bool Jump;//按下上楼键
    public bool Get;
    public bool Idle;
    public bool Hide;
    public bool Crouch;
    public bool Chased;//是否被追逐，被追逐时无法进行其他操作
    public bool BagOpen;
    public bool Charging;
    public bool Firing;
    public bool Pulling;
    public bool InBox;//是否和箱子重叠
    public bool Wait;//用于重置判定的等待状态
    public bool Stiff;//角色行动硬直
    public bool Hurting;//受创无敌状态
    public bool Attack;//切换攻击动画
    public GameManagerContrller gamemanager;

    //[Header("弹药蓄力时间")]//新增弹药需要维护此处
    //public float IncenseDTime;
    //public float IncenseGTime;
    //public float IncenseZTime;
    //public float IncenseCTime;
    //public float IncenseYTime;

    public float ChargingTime;
    public float FiringTime;//攻击硬直时间
    public float HurtingTime=1f;//受创无敌时间

    float ChargingTimer;//蓄力计时器
    float FiringTimer;//攻击硬直计时器





    void Start()
    {
        Pulling = false;
        rbody = GetComponent<Rigidbody2D>();//赋值刚体组件
        speed = StandSpeed;
        CC2D = GetComponent<CapsuleCollider2D>();//赋值角色碰撞盒子各参数
        CC2DSSize = CC2D.size;
        CC2DSOffset = CC2D.offset;
        CC2DCSize = new Vector2(CC2D.size.x, CC2D.size .y / 2f);
        CC2DCOffset = new Vector2(CC2D.offset.x, CC2D.offset.y / 2f);
        gamemanager=GameObject.Find("GameManager").GetComponent<GameManagerContrller>();//从列表中找到GameManager实例
        itemnum = 1;
        Idle = true;
        Stiff = false;
        PullRayOffset = CC2D.size.x / 2f;//射线偏移量为碰撞盒二分之一
        if (PosController.Instance.TargetPos != null)
        {
            TargetSpawn = PosController.Instance.TargetPos;//将PosController脚本里的出生点信息给TargetSpawn字符变量
            transform.position = GameObject.Find(TargetSpawn).transform.position;//将当前位置变成TargetSpawn的位置
        }
        Incense1 = dataManager.Slot1;//初始化弹药状态
        Incense2 = dataManager.Slot2;
        Incense3 = dataManager.Slot3;
        Incense4 = dataManager.Slot4;

        //switch (dataManager.Incense.ItemName)
        //{
        //    case "IncenseD":
        //        ChargingTime = IncenseDTime;
        //        break;
        //    case "IncenseG":
        //        ChargingTime = IncenseGTime;
        //        break;
        //    case "IncenseZ":
        //        ChargingTime = IncenseZTime;
        //        break;
        //    case "IncenseC":
        //        ChargingTime = IncenseCTime;
        //        break;
        //    default:
        //        break;
        //}

        if(dataManager.Incense!=null)
        {
            ChargingTime = dataManager.Incense.ChargeTime;
        }
        //transform.position = dataManager.Position;//读取时让人物位置变到存档点处

    }

    void StiffFalse()//Invok调用取消硬直
    {
        Stiff = false;
    }
    void AttackFalse()//Invok调用取消攻击状态
    {
        Attack = false;
    }
    void HurtingFalse()
    {
        Hurting = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy")&&!Hurting)//触碰敌人扣血
        {
            Hurting = true;
            Invoke("HurtingFalse", HurtingTime);
            dataManager.PlayerHP = dataManager.PlayerHP - 20;
        }
    }
private void OnTriggerStay2D(Collider2D other)

    {
        if (other.gameObject.CompareTag("Cover")&&Crouch)
        {
            
            
            Hide=true;

        }
        if (other.gameObject.CompareTag("Box"))
        {


            InBox = true;

        }


    }

     void OnTriggerExit2D(Collider2D other)
    {
      Hide=false;
      InBox = false;
    }
   

    void OnCollisionStay2D(Collision2D other)//接触地面时重力为0，人物坡道不滑动，加入其他tag时需要维护此处
    {

        switch(other.gameObject.tag)
        {
            case "Ground":
                rbody.gravityScale = 0;
                OnStair = false;
                break;
            case "Stair":
                rbody.gravityScale = 0;
                OnStair = true;
                break;
            case "Stair_Up":
                rbody.gravityScale = 0;
                break;
            case "Stair_Down":
                rbody.gravityScale = 0;
                break;
            default:
                break;
        }
       
    }


    void OnCollisionExit2D(Collision2D other)
    {
       
        rbody.gravityScale = 2.5f;
    }
    void CrouchCheck()//蹲下功能
    {
        if(Crouch)
        {
            CC2D.size = CC2DCSize;
            CC2D.offset = CC2DCOffset;
            speed = CrouchSpeed;
            
        }
        else
        {
            CC2D.size = CC2DSSize;
            CC2D.offset = CC2DSOffset;
            if (!Charging)
            {
                speed = StandSpeed;
            }   
        }
        
        
    }

    void FiringFunction()//开火功能
    {
        if(MyBag.ItemList.Contains(dataManager.Incense))
        { 
        Charging = (Input.GetButton("Fire2"));
        if(Charging)
        {
            Idle = false;
            ChargingTimer += Time.deltaTime;
            speed = CrouchSpeed;
        }
        else
        {
            Idle = true;
            if(!Crouch)
            {
                speed = StandSpeed;
            }
            
            if ((ChargingTimer>= ChargingTime)&&!Charging&&(dataManager.Incense!=null))
            {
                    if(dataManager.Incense.ItemName == "IncenseY")
                    {
                        Debug.Log("攻击特效");
                        Flame = Instantiate(IncenseYPrefab, itemspawn.position, itemspawn.rotation);
                        YFlameContrller yFlameContrller = Flame.GetComponent<YFlameContrller>();
                        float direction = transform.localScale.x;
                        Vector2 lookdirection = new Vector2(direction, 0f);
                        if (yFlameContrller!=null)
                        {
                            yFlameContrller.Move(lookdirection);
                        }
                        Stiff = true;
                        Invoke("StiffFalse", StiffTime);
                    }
                    else
                    {
                        Flame = Instantiate(FlamePrefab, itemspawn.position, itemspawn.rotation);//在角色前方创建攻击特效
                        Stiff = true;
                        Attack = true;
                        Invoke("StiffFalse", StiffTime);
                        Invoke("AttackFalse", StiffTime);
                    }

                }
            ChargingTimer = 0;
        }
        if (Idle)
        {
            if((Input.GetKey("1")))//切换弹药
            {
                ChargingTime= Incense1.ChargeTime;
                dataManager.Incense = Incense1;
                GameManagerContrller.Incense = Incense1;
                }
            if ((Input.GetKey("2")))
            {
                ChargingTime = Incense2.ChargeTime;
                    dataManager.Incense = Incense2;
                GameManagerContrller.Incense = Incense2;
                }
            if ((Input.GetKey("3")))
            {
                ChargingTime = Incense3.ChargeTime;
                    dataManager.Incense = Incense3;
                GameManagerContrller.Incense = Incense3;
                }
            if ((Input.GetKey("4")))
            {
                ChargingTime = Incense4.ChargeTime;
                    dataManager.Incense = Incense4;
                GameManagerContrller.Incense = Incense4;
                }
        }
        }
        else
        {
            if (Input.GetButton("Fire2"))
            {
                Debug.Log("未持有焚香");
            }
        }
    }

    void FaceDirction()//朝向功能
    {
        if(!Pulling && !Charging)
        {
            if (move > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            if (move < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

    }

    RaycastHit2D Raycast(Vector2 offset, Vector2 rayDiraction, float length, LayerMask layer)//融合射线检测与画线功能于Raycast函数,返回值为布尔，如不需要显示射线则注释掉debug
    {
        Vector2 pos = transform.position;
        RaycastHit2D hit = Physics2D.Raycast(pos + offset, rayDiraction, length, layer);
        Color color = hit ? Color.red : Color.green;
        Debug.DrawRay(pos + offset, rayDiraction * length, color);
        return hit;
    }

    void PullFunction()//推拉箱子功能
    {
        float direction = transform.localScale.x;
        Vector2 lookdirection = new Vector2(direction, 0f);
        RaycastHit2D BoxCheck = Raycast(new Vector2(PullRayOffset * direction, 0f), lookdirection, PullRange, BoxLayer);


        if (BoxCheck&&Pulling && Get)
        {
            Box.GetComponent<FixedJoint2D>().enabled = false;
            Pulling = false;
            Wait = true;
            Box.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation|RigidbodyConstraints2D.FreezePositionX;
        }

        if (BoxCheck&&Get&&!Pulling&&!InBox&&!Wait)
        {
            Vector3 pos = transform.position;
            pos.x += BoxCheck.distance * direction;
            transform.position = pos;
            Pulling = true;
            speed = PullSpeed;
            Box = BoxCheck.collider.gameObject;
            Box.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            Box.GetComponent<FixedJoint2D>().enabled = true;
            Box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }

    }
    void ClimbFunction()//推拉攀爬箱子功能
    {
        float direction = transform.localScale.x;
        Vector2 lookdirection = new Vector2(direction, 0f);
        RaycastHit2D BoxCheck = Raycast(new Vector2(PullRayOffset * direction, 0f), lookdirection, PullRange, BoxCanCilmbLayer);


        if (BoxCheck && Pulling && Get)
        {
            Box.GetComponent<FixedJoint2D>().enabled = false;
            Pulling = false;
            Wait = true;
            Box.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
        }

        if (BoxCheck && Get && !Pulling && !InBox && !Wait)
        {
            Vector3 pos = transform.position;
            pos.x += BoxCheck.distance * direction;
            transform.position = pos;
            Pulling = true;
            speed = PullSpeed;
            Box = BoxCheck.collider.gameObject;
            Box.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            Box.GetComponent<FixedJoint2D>().enabled = true;
            Box.GetComponent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
        if (BoxCheck && Jump && !Pulling && !InBox && !Wait)
        {
            Vector3 pos = transform.position;
            pos.x += (BoxCheck.distance + CC2DSSize.x) * direction;//攀爬的位置角色碰撞盒的X，Y的一半，需要调整攀爬位置时维护此处
            pos.y += CC2DSSize.y/2;
            transform.position = pos;
        }

    }
    void WaitFunction()//用于重置判定的等待函数
    {
        Wait = false;
    }


    void Update()
    {
        if(Input.GetButtonDown("ButtonY"))
        {
            BagOpen=!BagOpen;
            gamemanager.MyBag.SetActive(BagOpen);
        }

         if(Input.GetKeyDown("o"))
        {
            BagOpen=!BagOpen;
            gamemanager.MyBag.SetActive(BagOpen);
            
        }

         if(!Stiff)
        {
            move = Input.GetAxisRaw("Horizontal");//接收左右操作
        }
        else
        {
            move = 0;
        }
    

        if (Idle&&!Stiff)
        {
 
            Jump = (Input.GetButton("ButtonA"));
            Jump = (Input.GetKey("space"));
            Get = (Input.GetButtonDown("ButtonB"));
            Get = (Input.GetButtonDown("Fire1"));
            Crouch = (Input.GetButton("ButtonRB")) || (Input.GetKey("s"));
        }
        ClimbFunction();
        PullFunction();
        CrouchCheck();

        //Debug.Log(transform.localScale.x);

        anim.SetBool(IsCrouchId,Crouch);

        if(Wait)//用于重置判定的等待函数
        {
            Invoke("WaitFunction", WaitTime);
        }

 
        // if(Input.GetButton("ButtonA"))
        // {
        //   Debug.Log("按下A键");  
        // }
        // if(Input.GetButton("ButtonB"))
        // {
        //   Debug.Log("按下B键");  
        // }
        // if(Input.GetButton("ButtonX"))
        // {
        //   Debug.Log("按下X键");  
        // }
        // if(Input.GetButton("ButtonY"))
        // {
        //   Debug.Log("按下Y键");  
        // }
        // if(Input.GetButton("ButtonLB"))
        // {
        //   Debug.Log("按下LB键");  
        // }
        // if(Input.GetButton("ButtonRB"))
        // {
        //   Debug.Log("按下RB键");  
        // }
        // if(Input.GetButton("Back"))
        // {
        //   Debug.Log("按下Back键");  
        // }
        // if(Input.GetButton("Start")) 
        //  {
        //   Debug.Log("按下Start键");  
        // }



    }
    private void FixedUpdate()
    {
        rbody.velocity = new Vector2(move * speed, rbody.velocity.y);//移动刚体
        anim.SetBool("IsAttacking", Attack);
        if (!Stiff)
        {
            anim.SetFloat("IsRunning", Mathf.Abs(move));
            anim.SetBool("IsCharge", Charging);
  
            FaceDirction();
        }
       
        FiringFunction();
        


    }

    }



