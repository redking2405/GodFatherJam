using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelSelectorScript : MonoBehaviour {

    [System.Serializable]
    public class Level
    {
        public string Name;
        
        

        public string functionableName;

        public int Number;

        public Sprite Image;

        

     

      
    }


    public Level[] LevelLists;
    public float Buffer = 0.5f;
    private float BufferTimer = 0;
    public bool OneJoueurActivate = false;
    public bool OtherJoueurActivate = false;

    private bool P1Shield = false;
    public bool P1Spam = false;
    private bool P1Attack = false;
    private bool P1Activate = false;

    private bool P2Shield = false;
    public bool P2Spam = false;
    private bool P2Attack = false;
    private bool P2Activate = false;





    public Image[] ButtonList;

    public Text[] LevelTextName;

   
   

	// Use this for initialization
	void Start () {

       
        FillPanel();
	}
	
	// Update is called once per frame
	void Update () {
        StartTuto();
        StartLevel1();
        StartLevel2();
        BacktoMenu();
	}


    void FillPanel()
    {
        
        
        for (var j=0; j< ButtonList.Length; j++)
        {
            
            ButtonList[j].gameObject.GetComponent<Image>().sprite = LevelLists[j].Image;
           
            
            
            
        }

        for (var k=0; k<LevelTextName.Length; k++)
        {
            LevelTextName[k].text = LevelLists[k].Name;
        }


    }

   public void StartTuto()
    {
        if (Input.GetButtonDown("P1Spam") && !OneJoueurActivate)
        {
            OneJoueurActivate = true;
            P1Spam = true;
        }

        if (Input.GetButtonDown("P2Spam") && !OtherJoueurActivate)
        {
            OtherJoueurActivate = true;
            P2Spam = true;
        }
        if (P1Spam && P2Spam)
        {
            P1Spam = false;
            P2Spam = false;
            OneJoueurActivate = false;
            OtherJoueurActivate = false;
            PlayerPrefs.SetString("CurrentLevel", "Tuto");
            PlayerPrefs.SetInt("CurrentLevelNumber", 1);
            PlayerPrefs.SetInt("PlayerMaxLevel", 1);

            PlayerPrefs.Save();
            SceneManager.LoadScene("Tuto");
        }
    }

    public void StartLevel1()
    {
        if (Input.GetButtonDown("P1Attack") && !OneJoueurActivate)
        {
            OneJoueurActivate = true;
            P1Attack = true;
        }

        if (Input.GetButtonDown("P2Attack") && !OtherJoueurActivate)
        {
            OtherJoueurActivate = true;
            P2Attack = true;
        }
        if (P1Attack && P2Attack)
        {
            P1Attack = false;
            P2Attack = false;
            OneJoueurActivate = false;
            OtherJoueurActivate = false;
            PlayerPrefs.SetString("CurrentLevel", "Level 1");
            PlayerPrefs.SetInt("CurrentLevelNumber", 1);
            

            PlayerPrefs.Save();
            SceneManager.LoadScene("Level 1");
        }
    }

    public void StartLevel2()
    {
        if (Input.GetButtonDown("P1Activate") && !OneJoueurActivate)
        {
            OneJoueurActivate = true;
            P1Activate = true;
        }

        if (Input.GetButtonDown("P2Activate") && !OtherJoueurActivate)
        {
            OtherJoueurActivate = true;
            P2Activate = true;
        }
        if (P1Attack && P2Attack)
        {
            P1Activate = false;
            P2Activate = false;
            OneJoueurActivate = false;
            OtherJoueurActivate = false;
            PlayerPrefs.SetString("CurrentLevel", "Level 2");
            PlayerPrefs.SetInt("CurrentLevelNumber", 2);


            PlayerPrefs.Save();
            SceneManager.LoadScene("Level 2");
        }
    }

    public void BacktoMenu()
    {
        if (Input.GetButtonDown("P1Shield") && !OneJoueurActivate)
        {
            OneJoueurActivate = true;
            P1Shield = true;
        }

        if (Input.GetButtonDown("P2Shield") && !OtherJoueurActivate)
        {
            OtherJoueurActivate = true;
            P2Shield = true;
        }
        if (P1Shield && P2Shield)
        {
            P1Shield = false;
            P2Shield = false;
            OneJoueurActivate = false;
            OtherJoueurActivate = false;
           
            SceneManager.LoadScene("StartingScene");
        }
    }
}

    