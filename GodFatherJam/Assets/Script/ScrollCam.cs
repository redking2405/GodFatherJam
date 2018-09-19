using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollCam : MonoBehaviour {

    public float scroll;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
            var cameraPosition = Camera.main.gameObject.transform.position;
            cameraPosition.x += scroll;
            Camera.main.gameObject.transform.position = cameraPosition;
        
    }
}
