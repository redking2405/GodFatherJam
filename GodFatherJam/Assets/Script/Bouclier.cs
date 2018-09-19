using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouclier : MonoBehaviour {

    public float time;
	// Use this for initialization
	void Start () {
        MyDestroy(gameObject, time);
	}

    private void MyDestroy(GameObject game, float time)
    {
        Player1.Instance.isGuarding = false;
        Destroy(game, time);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            Destroy(collision.gameObject);
            MyDestroy(this.gameObject, 0);
        }
    }
}
