using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{

    public int numberScenes;

    // Update is called once per frame
    void Update()
    {
        SceneChangers();
    }

    void SceneChangers()
    {

        LevelUnLock();
        

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LevelUnLock();
            SceneManager.LoadScene(0);
        }

    }

    public void LevelUnLock()

    {
        int currentLevel = SceneManager.GetActiveScene().buildIndex;


        if (currentLevel >= PlayerPrefs.GetInt("levels"))
        {
            PlayerPrefs.SetInt("levels", currentLevel + 1);
        }


    }

    
}
