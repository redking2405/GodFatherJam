using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeScript : MonoBehaviour {


    private float transparence=0;

    public bool FadeOut = true;

    public static FadeScript Instance;

    public float Step = 0.05f;


    private void Awake()
    {
        Instance = this;
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


        transparence = Mathf.Clamp(transparence, 0, 1);

        if(!FadeOut)
        {
            transparence += Step;
        }

        if (FadeOut)
        {
            transparence -= Step;
        }


        GetComponent<CanvasGroup>().alpha = transparence;
	}


    private void OnDestroy()
    {
        Instance = null;
    }
}
