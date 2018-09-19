using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class TitlecardScriptV4 : MonoBehaviour {

   

    // Use this for initialization
    void Start () {

       
       
        
        
		
	}

    // Update is called once per frame
    void Update()
    {

       

        StarttheGamu();

        if (Input.GetButton("P1Select"))
        {
            Quit();
        }
        

    }

    public void StarttheGamu()
    {
        if (Input.GetButton("P1Start"))
        {
            
            SceneManager.LoadScene("Temp-Arnaud");
        }
    }


  

    public void Quit()
    {
        Application.Quit();
    }

}
