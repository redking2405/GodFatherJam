using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

    public int speed;
    Rigidbody2D rdb;

	// Use this for initialization
	void Start () {
        rdb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 2);
	}
	
	// Update is called once per frame
	void Update () {
        rdb.velocity = new Vector2(speed,0);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            Destroy(gameObject);
            if (collision.tag == "Obstacle")
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
