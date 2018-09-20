using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {


    public bool isTrigger = false;
    private Rigidbody2D rbd;
    public bool isTargeting = true;
    public GameObject MissileWarning;
    public int speed = 3;
    private Vector2 direction;
    Renderer rend;
    private Animator anim;
    // Use this for initialization
    void Start () {
        rbd = GetComponent<Rigidbody2D>();
        rend = GetComponent<Renderer>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (isTrigger)
        {
            MissileMove();

            if (rend.isVisible)
            {
                MissileWarning.gameObject.SetActive(false);
            }
        }

       
	}

    void MissileMove()
    {
        if (isTargeting && Player1.Instance.gameObject.transform.position.x<this.gameObject.transform.position.x)
        {
            direction = new Vector2(Player1.Instance.gameObject.transform.position.x - this.gameObject.transform.position.x, Player1.Instance.gameObject.transform.position.y - this.gameObject.transform.position.y);
            rbd.velocity = direction * speed;
        }

        if (Player1.Instance.gameObject.transform.position.x >= this.gameObject.transform.position.x)
        {
            isTargeting = false;
        }

        if (!isTargeting)
        {
            rbd.velocity = Vector2.left * speed;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            anim.SetBool("explosion", true);
            
            Player1.Instance.Dead();
        }
    }
}
