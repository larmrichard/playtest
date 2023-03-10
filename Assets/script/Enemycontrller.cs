using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;//加载编辑器


public enum Enemystatus//枚举出敌人所有状态，（枚举无法同时具有多个状态，应用布尔集代替）
{
    Idle,//待机状态
    Stay,//攻击间隔状态
    Patrol,//巡逻状态
    Chaseing,//追逐玩家状态
    Back,//往重置地点返回状态
    Break,//撞到巡逻点时候的发呆状态、硬直
    Stun,//眩晕状态
    Attacked,//受创硬直
}
public class Enemycontrller : MonoBehaviour
{
    // Start is called before the first frame update
    Enemystatus enemystatus;//定义敌人状态
    float Staytimer;//定义停止计时器
    float Breaktimer;
    float StunTimer;
    float AttackedTimer;
    public float speed = 1.5f;//敌人对玩家的方向，速度
    public float ChaseingSpeed= 1.5f;//敌人追逐玩家时的速度
    public float PatrolSpeed= 1.5f;//敌人巡逻时的速度
    public float Staytime;//定义敌人停止时间
    public float Breaktime;//撞到巡逻点时候的发呆时间
    public float StiffTime;//硬直时间
    Rigidbody2D rbody;//获取刚体组件 
    /* public float listenrange = 5f;//定义敌人察觉范围 */
    public Transform target; //定义位置变量
    public Transform backpoint; //定义返回位置变量
    public LayerMask playerlayer;
    private CapsuleCollider2D coll;
    private float spotrayoffset;//射线起点偏移量
    public float spotrange=2f;//定义敌人前方察觉范围
    public float spotrangeBack=1f;//定义敌人后方察觉范围
    public playercontrller playercontrller;
    public float StunTime;//定义敌人眩晕的时长
    public float AttackedTime;//受创硬直时长
    public int EnemyIndex;//此敌人在datamanager中的list序号
    public DataManager dataManager;
    FlameContrller flamecontrller;
    public bool Stiff;//硬直

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();   //赋值刚体组件 
        enemystatus = Enemystatus.Idle;//敌人初始状态为站立
        coll= GetComponent<CapsuleCollider2D>();
        spotrayoffset=coll.size.x/2f;//射线偏移量为碰撞盒二分之一
        playercontrller = GameObject.Find("player").GetComponent<playercontrller>();
        StiffTime = 1.5f;
    }
    void StiffFalse()
    {
        Stiff = false;
    }
    void FaceDirction()
    {
      if (speed>0)
      {
          transform.localScale=new Vector3(1,1,1);
      }  
      else
      {
        transform.localScale=new Vector3(-1,1,1);
      }
    }

    void DirctionFunction()
    {
        if (enemystatus == Enemystatus.Back)
        {
            if (backpoint.position.x - transform.position.x > 0)//判断返回点方向
            {
                speed = Mathf.Abs(speed);
            }
            else
            {
                speed = -Mathf.Abs(speed);
            }
        }
         if (enemystatus == Enemystatus.Chaseing)
        { 
        if (target.position.x - transform.position.x > 0)//判断玩家方向
            {
                speed = Mathf.Abs(speed);
            }
            else
            {
                speed = -Mathf.Abs(speed);
            }
        }

    }
    void PatrolFunction()
    {
        if (enemystatus == Enemystatus.Idle)
        {
            enemystatus = Enemystatus.Patrol;
            speed=PatrolSpeed;
           
        }    
    }

    void OnTriggerEnter2D(Collider2D other)
    {


      if (other.gameObject.CompareTag("BackPoint") && enemystatus == Enemystatus.Back)//撞到返回点切回巡逻状态
        {

            enemystatus = Enemystatus.Patrol;

        }


        if (other.gameObject.CompareTag("PatrolPoint")&& enemystatus == Enemystatus.Patrol)//撞到巡逻点转向
        {
            enemystatus = Enemystatus.Break;
            speed = -speed;

        } 

        if (other.gameObject.CompareTag("Player")&& enemystatus == Enemystatus.Chaseing)//追踪中触碰到玩家
        {
            
            enemystatus = Enemystatus.Stay;
            Staytimer += Time.deltaTime;//停止器开始计时

        }
        if (other.gameObject.CompareTag("Flame") && enemystatus != Enemystatus.Attacked)//扣血功能
        {
            flamecontrller = other.gameObject.GetComponent<FlameContrller>();
            dataManager.EnemyHPList[EnemyIndex] = dataManager.EnemyHPList[EnemyIndex] - flamecontrller.FlamePower;
            AttackedTimer += Time.deltaTime;
            Debug.Log("敌人收到伤害");
            Stiff = true;
            Invoke("StiffFalse", StiffTime);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
 if (other.gameObject.CompareTag("BackPoint") && enemystatus == Enemystatus.Back)//解决在返回点内切换回巡逻状态
        {

            enemystatus = Enemystatus.Patrol;

        }

    }
    RaycastHit2D Raycast(Vector2 offset,Vector2 rayDiraction,float length,LayerMask layer)//融合射线检测与画线功能于Raycast函数,如不需要显示射线则注释掉debug
    {
        Vector2 pos =transform.position;
        RaycastHit2D hit= Physics2D.Raycast(pos+offset,rayDiraction,length,layer);
        Color color =hit?Color.red:Color.green;
        Debug.DrawRay(pos+offset,rayDiraction*length,color);
        return hit;
    }

    void SpotFunction ()//发现玩家跟踪玩家的功能
    {
        float direction = transform.localScale.x;
        Vector2 lookdirection =new Vector2 (direction,0f);
        RaycastHit2D SpotCheck =Raycast(new Vector2 (spotrayoffset*direction,0f),lookdirection,spotrange,playerlayer);
        RaycastHit2D SpotCheckBack =Raycast(new Vector2 (spotrayoffset*-direction,0f),-lookdirection,spotrangeBack,playerlayer);
           if (SpotCheck&&!playercontrller.Hide&&enemystatus != Enemystatus.Stay)
        {
            enemystatus = Enemystatus.Chaseing;
            if(speed>0)
            {
              speed=ChaseingSpeed;  
            }
            if(speed<0)
            {
              speed=-ChaseingSpeed;   
            }

        }

            if (SpotCheckBack&&!playercontrller.Hide&&enemystatus != Enemystatus.Stay)
        {
            enemystatus = Enemystatus.Chaseing;
            if(speed>0)
            {
              speed=ChaseingSpeed;  
            }
            if(speed<0)
            {
              speed=-ChaseingSpeed;   
            }

        }
 
    } 

    void BreakFunction()
    {
         if(enemystatus == Enemystatus.Break)
        {

            Breaktimer += Time.deltaTime;//如果状态为停止则继续计时
        }

        if (Breaktimer>= Breaktime)//如果计时器大于停止时间状态切换为站立，计时器清零
        {
            enemystatus = Enemystatus.Patrol;
            Breaktimer = 0;
        }

        if(enemystatus != Enemystatus.Break)
        {
           Breaktimer = 0; 
        }
    }

    // Update is called once per frame
    void Update()
    {

       /* Debug.Log(enemystatus); */

        if(enemystatus == Enemystatus.Stay)
        {

            Staytimer += Time.deltaTime;//如果状态为停止则继续计时
        }

        if (Staytimer>= Staytime)//如果计时器大于停止时间状态切换为站立，计时器清零
        {
            enemystatus = Enemystatus.Back;
            speed=PatrolSpeed;
            Staytimer = 0;
        }
        if (AttackedTimer>= AttackedTime)
        {
         enemystatus = Enemystatus.Chaseing;
         AttackedTimer = 0;
        }
        BreakFunction();


       

    }


    private void FixedUpdate()
    {
        if(dataManager.EnemyHPList[EnemyIndex]<=0)//死亡功能
        {
            Destroy(gameObject);
        }
        if(enemystatus != Enemystatus.Stay)
        {


            if((enemystatus != Enemystatus.Break)&&!Stiff)
            {
                rbody.velocity = new Vector2(speed, rbody.velocity.y);//移动刚体

            }
            

        }
        
        PatrolFunction();
        SpotFunction ();
        FaceDirction();
        DirctionFunction();



    }

}
