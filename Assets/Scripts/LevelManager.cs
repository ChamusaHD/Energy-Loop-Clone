using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private Button[] buttons;
    [SerializeField] private GameObject levelButtons;

    int unlockedLevels;
    int allLevels;

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }

        
        if (!PlayerPrefs.HasKey("UnlockedLevels"))
        {
            PlayerPrefs.SetInt("UnlockedLevels", 1);
        }

        ButtonsToArray();

        allLevels = buttons.Length;

        unlockedLevels = PlayerPrefs.GetInt("UnlockedLevels");

       if (unlockedLevels >= allLevels)
            unlockedLevels = allLevels;
            Debug.Log(unlockedLevels);


        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < unlockedLevels; i++)
        {
            buttons[i].interactable = true;
        }

    }

    public void ResetPlayerPrefsKeys()
    {
        PlayerPrefs.SetInt("UnlockedLevels", 1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OpenLevel(int levelID)
    {
        string levelName = "Level " + levelID;
        SceneManager.LoadScene(levelName);
    }

    public void UnlockNewLevel()
    {
        int nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;

        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("UnlockedLevels"))
        {
            PlayerPrefs.SetInt("UnlockedLevels", PlayerPrefs.GetInt("UnlockedLevels") + 1);
            PlayerPrefs.Save();
            //SceneManager.LoadScene(nextSceneToLoad);
            
            if (nextSceneToLoad > SceneManager.sceneCountInBuildSettings -1)
            {
                SceneManager.LoadScene("LevelSelection");
            }
            else
            {
                SceneManager.LoadScene(nextSceneToLoad);
            }
        }
        else // go to LevelSelection screen if completed a level unlocked previously
        {
            SceneManager.LoadScene("LevelSelection");
        }

    }

    private void ButtonsToArray()
    {
        int childCount=levelButtons.transform.childCount;
        buttons = new Button[childCount];

        for (int i = 0; i  < childCount; i++) 
        {
            buttons[i] = levelButtons.transform.GetChild(i).GetComponent<Button>();
        }
    }
}
