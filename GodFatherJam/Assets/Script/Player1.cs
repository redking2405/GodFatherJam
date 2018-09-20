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
        if (Input.GetButtonDown("P1Shield")&&!isGuarding)
        {
            
            GameObject Guard = Instantiate(PrefabGuard, origin.position, Quaternion.identity);
            Guard.transform.parent = origin;
            Guard.GetComponent<Bouclier>().time = GuardTime;
            isGuarding = true;


        }
    }

    void PlayerShoot()
    {
        if(Input.GetButtonDown("P1Attack") && !isShooting && !isGuarding)
        {
            GameObject Shoot = Instantiate(PrefabShoot, origin.position, Quaternion.identity);
            Shoot.GetComponent<projectile>().speed = MissileSpeed;
            isShooting = true;
            
        }
    }

    void PlayerMove()
    {
        speedX = Input.GetAxis(PlayerNum + "Horizontal") * Speed;
        speedY = (Input.GetAxis(PlayerNum + "Vertical") * Speed) * -1;

        direction = new Vector2(speedX, speedY);

        if (Input.GetButton("P1Dash"))
        {
       
            rbd.velocity = Vector2.right * Dashspeed;
        }
        else
        {

            if (speedX != 0.0f && speedY != 0.0f)
            {
                rbd.velocity = direction;
            }

            if (speedX == 0.0f || speedY == 0.0f)
            {
                if (speedX != 0.0f && speedY == 0.0f)
                {
                    rbd.velocity = direction;
                }

                else if (speedX == 0.0f && speedY != 0.0f)
                {
                    rbd.velocity = direction;
                }

                if (speedY == 0.0f && speedX == 0.0f)
                {
                    rbd.velocity = Vector2.zero;
                }
            }
        }
    }


    public void OpenDoor()
    {
        if (Input.GetButtonDown("P1Activate"))
        {
            isInRange = false;
            Door.SetActive(false);
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
        Debug.Log(PlayerPrefs.GetInt("score"));
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
