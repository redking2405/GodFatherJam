using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plat_Movement : MonoBehaviour {

    Rigidbody2D rbd;
    public float intensite;
    public float timeleft;
    public bool bouge = false;
    public bool touche = false;
    private bool isArrived = false;
    private float PosX;
    public Transform Destination;
    // Use this for initialization
    void Start () {
        rbd = GetComponent<Rigidbody2D>();
        intensite = 3f;
        timeleft = 0.2f;
        PosX = this.gameObject.transform.position.x;
    }
	
	// Update is called once per frame
	void Update () {
        
        if(touche)
        {

            if (Input.GetButtonDown("P1Spam") && !Player1.Instance.OneJoueurActivate)
            {
                Player1.Instance.P1Spam = true;
                Player1.Instance.OneJoueurActivate = true;

            }

            if (Input.GetButtonDown("P2Spam") && !Player1.Instance.OtherJoueurActivate)
            {
                Player1.Instance.P2Spam = true;
                Player1.Instance.OtherJoueurActivate = true;
            }
            if (Player1.Instance.P1Spam&&Player1.Instance.P2Spam)
            {

                rbd.velocity = Vector2.right * intensite;
                bouge = true;
                Player1.Instance.P1Spam = false;
                Player1.Instance.P2Spam = false;
                Player1.Instance.OneJoueurActivate = false;
                Player1.Instance.OtherJoueurActivate = false;

            }
            if (bouge)
            {
                timeleft -= Time.deltaTime;
            }

        }
        if (!isArrived)
        {
            restart();
        }
        

        if (this.gameObject.transform.position.x < PosX)
        {
            rbd.velocity = Vector2.zero;
            this.gameObject.transform.position =new  Vector3 (PosX, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }

        if (this.gameObject.transform.position.x > Destination.position.x)
        {
            rbd.velocity = Vector2.zero;
            touche = false;
            this.gameObject.transform.position = Destination.position;
            Player1.Instance.isOnPlatform = false;
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            isArrived = true;
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player1.Instance.isOnPlatform = true;
        Player1.Instance.Snap = this;
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        touche = true;
        
    }




    private void OnTriggerExit2D(Collider2D collision)
    {
        touche = false;
        rbd.velocity = Vector2.zero;
        bouge = false;
        timeleft = 1f;
       
        
    }


   

    void restart()
    {
        if (timeleft < 0)
        {
            rbd.velocity = Vector2.zero;
            bouge = false;
            timeleft = 0.2f;
            rbd.velocity = Vector2.left * intensite;
        }
    }
}
