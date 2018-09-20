using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour {

    public static Player1 Instance;
    Rigidbody2D rbd;
    private float speedX;
    private float speedY;
    public float Speed = 10.0f;
    private string PlayerNum = "P1";
    public float Dashspeed;
    Vector2 direction;
    public GameObject PrefabGuard;
    public GameObject PrefabShoot;
    public bool isGuarding = false;
    public bool isShooting = false;
    private float Timer;
    public float MaxTime = 0.5f;
    public Transform origin;
    public int MissileSpeed=10;
    public int GuardTime = 2;
    public bool isOnPlatform = false;
    public Plat_Movement Snap;
    public GameObject Door;
    public bool isInRange = false;
    public float timerMort = 1f;
    public bool OneJoueurActivate = false;
    public bool OtherJoueurActivate = false;
    private bool P1Dash = false;
    private bool P1Shield = false;
    public bool P1Spam = false;
    private bool P1Attack = false;
    private bool P1Activate = false;
    private bool P2Dash = false;
    private bool P2Shield = false;
    public bool P2Spam = false;
    private bool P2Attack = false;
    private bool P2Activate = false;


    public float Buffer = 0.5f;
    private float BufferTimer = 0;
    // Use this for initialization
    void Start () {  
        Instance = this;
        Dashspeed = 10f;
        rbd = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {


        if (!isOnPlatform)
        {
            PlayerMove();
        }

        if (isOnPlatform)
        {
            SnapMove();
        }
        
        PlayerGuard();
        PlayerShoot();
        if (isInRange)
        {
            OpenDoor();
        }
        if (isShooting)
        {
            Timer += Timer + Time.deltaTime;

            if (Timer >= MaxTime)
            {
                isShooting = false;
                Timer = 0.0f;
            }
        }

        if(OneJoueurActivate && !OtherJoueurActivate || !OneJoueurActivate && OtherJoueurActivate)
        {
                    
               
            if (BufferTimer>=Buffer)
            {
                OneJoueurActivate = false;
                OtherJoueurActivate = false;
                P1Dash = false;
                P1Shield = false;
                P1Attack = false;
                P1Activate = false;
                P1Spam = false;
                P2Spam = false;
                P2Activate = false;
                P2Shield = false;
                P2Attack = false;
                P2Dash = false;
                BufferTimer = 0;
            }

            BufferTimer += BufferTimer + Time.deltaTime;
        }
	}


    
    void SnapMove()
    {
        if (Snap != null)
        {
            this.gameObject.transform.position = Snap.gameObject.transform.position;
        }
    }

    void PlayerGuard()
    {

        if (Input.GetButtonDown("P1Shield") && !OneJoueurActivate)
        {
            OneJoueurActivate = true;
            P1Shield = true;
        }

        if (Input.GetButtonDown("P2Shield")&&!OtherJoueurActivate)
        {
            OtherJoueurActivate = true;
            P2Shield = true;
        }
        if (P1Shield&&P2Shield&&!isGuarding)
        {
            
            GameObject Guard = Instantiate(PrefabGuard, origin.position, Quaternion.identity);
            Guard.transform.parent = origin;
            Guard.GetComponent<Bouclier>().time = GuardTime;
            isGuarding = true;
            P1Shield = false;
            P2Shield = false;
            OneJoueurActivate = false;
            OtherJoueurActivate = false;


        }
    }

    void PlayerShoot()
    {
        if (Input.GetButtonDown("P1Attack") && !OneJoueurActivate)
        {
            P1Attack = true;
            OneJoueurActivate = true;
        }

        if (Input.GetButtonDown("P2Attack") && !OtherJoueurActivate)
        {
            P2Attack = true;
            OtherJoueurActivate = true;
        }
        if(P1Attack&&P2Attack && !isShooting && !isGuarding)
        {
            GameObject Shoot = Instantiate(PrefabShoot, origin.position, Quaternion.identity);
            Shoot.GetComponent<projectile>().speed = MissileSpeed;
            isShooting = true;
            P1Attack = false;
            P2Attack = false;
            OneJoueurActivate = false;
            OtherJoueurActivate = false;
            
            
        }
    }

    void PlayerMove()
    {

        if (Input.GetAxis("P1Horizontal") > 0 && Input.GetAxis("P2Horizontal") > 0 || Input.GetAxis("P1Horizontal") < 0 && Input.GetAxis("P2Horizontal") < 0)
        {
            if(Input.GetAxis("P1Horizontal") > 0 && Input.GetAxis("P2Horizontal") > 0)
            {
                speedX = Input.GetAxis("P1Horizontal") * Input.GetAxis("P2Horizontal") * Speed;
            }

            else if(Input.GetAxis("P1Horizontal") < 0 && Input.GetAxis("P2Horizontal") < 0)
            {
                speedX = (Input.GetAxis("P1Horizontal") * Input.GetAxis("P2Horizontal") * Speed) * -1;
            }
            
        }
        else speedX = 0;

        if (Input.GetAxis("P1Vertical") < 0 && Input.GetAxis("P2Vertical") < 0 || Input.GetAxis("P1Vertical") > 0 && Input.GetAxis("P2Vertical") > 0)

        {

            if (Input.GetAxis("P1Vertical") > 0 && Input.GetAxis("P2Vertical") > 0)
            {
                speedY = (Input.GetAxis("P1Vertical") * Input.GetAxis("P2Vertical") * Speed)*-1;
            }

            else if(Input.GetAxis("P1Vertical") < 0 && Input.GetAxis("P2Vertical") < 0)
            {
                speedY = (Input.GetAxis("P1Vertical") * Input.GetAxis("P2Vertical") * Speed);
            }
            
        }

        else speedY = 0;

       

        direction = new Vector2(speedX, speedY);


        if (Input.GetButtonDown("P1Dash") && !OneJoueurActivate)
        {
            OneJoueurActivate = true;
            P1Dash = true;
        }

        if (Input.GetButtonDown("P2Dash") && !OtherJoueurActivate)
        {
            OtherJoueurActivate = true;
            P2Dash = true;
        }

        if (P1Dash && P2Dash)
        {
            rbd.velocity = Vector2.right * Dashspeed;
            P1Dash = false;
            P2Dash = false;
            OneJoueurActivate = false;
            OtherJoueurActivate = false;
        }

        else
        {
            rbd.velocity = direction;
        }
        
        
    }


    public void OpenDoor()
    {

        if(Input.GetButtonDown("P1Activate") && !OneJoueurActivate)
        {
            OneJoueurActivate = true;
            P1Activate = true;
        }

        if (Input.GetButtonDown("P2Activate") && !OtherJoueurActivate)
        {
            OtherJoueurActivate = true;
            P2Activate = true;
        }
        if (P1Activate&&P2Activate)
        {
            isInRange = false;
            P1Activate = false;
            P2Activate = false;
            OneJoueurActivate = false;
            OtherJoueurActivate = false;
            Destroy(Door);
        }
    }

    public void Dead()
    {
        FadeScript.Instance.FadeOut = false;
        Invoke("Death", timerMort);

    }

    public void Arrived()
    {
        FadeScript.Instance.FadeOut = false;
        Invoke("Win", timerMort);
    }

    private void Win()
    {
        //CongratScript.Instance.UpdateScore((int)Score.Instance.ZeScore);
        PlayerPrefs.SetInt("score", (int)Score.Instance.ZeScore);
      
        SceneManager.LoadSceneAsync("Congratulation");
    }

    private void Death()
    {
        SceneManager.LoadScene("GameOver");
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
