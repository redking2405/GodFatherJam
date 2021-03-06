﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class TitlecardScriptV4 : MonoBehaviour {


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
    // Use this for initialization
    void Start () {

       
       
        
        
		
	}

    // Update is called once per frame
    void Update()
    {



        if (OneJoueurActivate && !OtherJoueurActivate || !OneJoueurActivate && OtherJoueurActivate)
        {


            if (BufferTimer >= Buffer)
            {
                OneJoueurActivate = false;
                OtherJoueurActivate = false;
                
                P1Spam = false;
                P1Attack = false;
                P1Activate = false;

                P2Activate = false;
                P2Spam = false;
                P2Attack = false;
               
                BufferTimer = 0;
            }

            BufferTimer += BufferTimer + Time.deltaTime;
        }

        StarttheGamu();
        ChooseYourLevel();
        Quit();


    }

    public void StarttheGamu()
    {
        if (Input.GetButtonDown("P1Spam") && !OneJoueurActivate)
        {
            OneJoueurActivate = true;
            P1Spam = true;
        }

        if(Input.GetButtonDown("P2Spam")&& !OtherJoueurActivate)
        {
            OtherJoueurActivate = true;
            P2Spam = true;
        }
        if (P1Spam&&P2Spam)
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

    public void ChooseYourLevel()
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
            SceneManager.LoadScene("LevelSelectorScreen");
        }
    }




    public void Quit()
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
            Application.Quit();
        }
    }

}
