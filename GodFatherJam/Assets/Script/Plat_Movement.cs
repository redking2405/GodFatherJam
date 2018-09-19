using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plat_Movement : MonoBehaviour {

    Rigidbody2D rbd;
    public float intensite;
    public float timeleft;
    public bool bouge = false;
    public bool touche = false;
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
        Debug.Log(touche);
        if(touche)
        {
            if (Input.GetButtonDown("P1Spam"))
            {

                rbd.velocity = Vector2.right * intensite;
                bouge = true;

            }
            if (bouge == true)
            {
                timeleft -= Time.deltaTime;
            }

        }

        restart();

        if (this.gameObject.transform.position.x < PosX)
        {
            rbd.velocity = Vector2.zero;
            this.gameObject.transform.position =new  Vector3 (PosX, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
        }

        if (this.gameObject.transform.position.x > Destination.position.x)
        {
            rbd.velocity = Vector2.zero;

            this.gameObject.transform.position = Destination.position;
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
        rbd.velocity = Vector2.left * intensite;
        Player1.Instance.Snap = null;
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
