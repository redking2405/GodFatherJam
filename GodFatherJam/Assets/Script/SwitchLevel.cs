using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevel : MonoBehaviour {

    public bool target = false;
    protected int nextLevelNumber;
    protected string nextLevelName;
    protected int currentLevelNumber;
    protected string currentLevelName;
    public static SwitchLevel Instance;
   

    private void Awake()
    {
        Instance = this;
    }

    // Use this for initialization
    void Start()
    {
        currentLevelName = PlayerPrefs.GetString("CurrentLevel");
        currentLevelNumber = PlayerPrefs.GetInt("CurrentLevelNumber");
        switch (currentLevelName)
        {
            case ("Tuto"):
                currentLevelNumber = 1;
                break;
            case ("Level 2"):
                currentLevelNumber = 2;
                break;
            case ("Level 3"):
                currentLevelNumber = 3;
                break;
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target && Input.GetKey(KeyCode.E))
        {
            nextLevelNumber = currentLevelNumber + 1;
            nextLevelName = "Level " + nextLevelNumber;
            PlayerPrefs.SetInt("CurrentLevelNumber", nextLevelNumber);
            PlayerPrefs.SetString("CurrentLevel", nextLevelName);
            PlayerPrefs.SetInt("PlayerMaxLevel", currentLevelNumber);
            PlayerPrefs.Save();
            //launch animation de fin de level

            NextLevel();
        }
    }

    private void GoToNextLevel()
    {
        SceneManager.LoadScene("LoadingScreen");
    }

    private void NextLevel()
    {

        FadeScript.Instance.FadeOut = false;
        

        if (nextLevelNumber == 3)
        {
            Invoke("EndofGame", 1.2f);
        }
        //a la fin de l'animation faire 
        else Invoke("GoToNextLevel", 1.2f);

    }

    private void EndofGame()
    {

        SceneManager.LoadScene("Congratulation");
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            NextLevel();
           


        }
    }

   

    private void OnDestroy()
    {
        Instance = null;
    }
}
