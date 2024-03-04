using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEditor;
using System.IO;
public class LevelChange : MonoBehaviour
{

    int levelUnlock = 1;
    public Button[] buttons;
    private const string Elif = "Info.txt";

    void Start()
    {
        levelUnlock = PlayerPrefs.GetInt("levels");

        for (int i = 1; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;


        }



        for (int i = 1; i < levelUnlock; i++)
        {


            buttons[i].interactable = true;

        }

    }



    public void loadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }



}
