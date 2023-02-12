using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene("HUB_EPITECH");
    }

    public void Quit()
    {
        Debug.Log("exiting the game");
        Application.Quit();
    }
}