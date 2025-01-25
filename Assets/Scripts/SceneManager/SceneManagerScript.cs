using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{

    public void Play()
    {

        SceneManager.LoadScene("Main", LoadSceneMode.Single);
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
    public void Credits()
    {
        SceneManager.LoadScene("Credits", LoadSceneMode.Single);
    }
}