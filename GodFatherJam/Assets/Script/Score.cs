using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {


    public static Score Instance; // pour pouvoir l'appelé depuis n'importe quel script
    public Text MyScore; // y mettre le UI text score de la scène Final Scene ou scene temporaire en cours de traveaux
    public float ZeScore;
    public float ScrollSpeed=0.0f;
	// Use this for initialization
	void Start () {
        Instance = this;
        ZeScore = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (ScrollSpeed == 0.0f)
        {
            ScrollSpeed = 1.0f;
        }
        ZeScore = ZeScore + Time.deltaTime*ScrollSpeed; // calcul du score sachant que pour l'instant c'est 1pt/s
        UpdateScore(ZeScore);
	}

    void UpdateScore(float PScore) // va update le score à chaque frame
    {
        MyScore.text="Score : " + (int)PScore;
    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
