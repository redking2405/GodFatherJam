using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTrigger : MonoBehaviour {

    public GameObject MissileWarningHaute;
    public GameObject MissileWarningMiddle;
    public GameObject MissileWarningLow;
    private float height;
    
    
    
    // Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 10)


        {

            Vector3 NormalisedPoint= Camera.main.WorldToViewportPoint(collision.transform.position);
            Missile missile = collision.GetComponent<Missile>();
            if(NormalisedPoint.y>0 && NormalisedPoint.y < 0.33)
            {
                missile.isTrigger = true;
                missile.MissileWarning = MissileWarningLow;
                MissileWarningLow.SetActive(true);
            }

            else if(NormalisedPoint.y>0.33 && NormalisedPoint.y < 0.67)
            {
                missile.isTrigger = true;
                missile.MissileWarning = MissileWarningMiddle;
                MissileWarningMiddle.SetActive(true);
            }

            else if(NormalisedPoint.y<1 && NormalisedPoint.y>0.67)
            {
                missile.isTrigger = true;
                missile.MissileWarning = MissileWarningHaute;
                MissileWarningHaute.SetActive(true);
            }
        }
    }
}
