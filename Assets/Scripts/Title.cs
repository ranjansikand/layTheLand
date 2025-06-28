// Lets you start the game


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title : MonoBehaviour
{
    private int lastPlayedLevel;

    [SerializeField] GameObject continueButton;

    void Start() {
        lastPlayedLevel = PlayerPrefs.GetInt("LastPlayedLevel", 0);

        if (lastPlayedLevel > 0) continueButton.SetActive(true);
        else continueButton.SetActive(false);
    }

    public void NewGame() {
        SceneManager.LoadScene("0");
    }

    public void Continue() {
        SceneManager.LoadScene(lastPlayedLevel);
    }

    public void Sandbox() {
        SceneManager.LoadScene("Sandbox");
    }
}
