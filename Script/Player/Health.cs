using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public static int health;
    public GameObject health1, health2, health3;

    void Start()
    {
        health1.SetActive(true);
        health2.SetActive(true);
        health3.SetActive(true);
        health = 3;

    }


    void Update()
    {
        switch (health)
        {




            case 3:

                health1.SetActive(true);
                health2.SetActive(true);
                health3.SetActive(true);
                break;
            case 2:
                health1.SetActive(true);
                health2.SetActive(true);
                health3.SetActive(false);
                break;
            case 1:
                health1.SetActive(true);
                health2.SetActive(false);
                health3.SetActive(false);
                break;
            case 0:
                health1.SetActive(false);
                health2.SetActive(false);
                health3.SetActive(false);
                break;
        }

        if (health == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
        }
    }
}
