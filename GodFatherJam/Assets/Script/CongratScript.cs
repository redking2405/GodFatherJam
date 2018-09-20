using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CongratScript : MonoBehaviour {


    public Text MyScore; // y mettre le UI text appelé score de la scene Congratulation
    public static CongratScript Instance;
	// Use this for initialization
	void Start () {
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
        UpdateScore(PlayerPrefs.GetInt("score"));
        if (Input.GetButtonDown("P1Start"))
        {
            PlayerPrefs.SetInt("score", 0);
            SceneManager.LoadScene("StartingScene");
        }
	}

    //fonction qui va update le score de l'écran de Win

    public void UpdateScore(int PScore)
    {
        MyScore.text = "Score : " + PScore;
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
