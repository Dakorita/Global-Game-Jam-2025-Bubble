using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CreditsMAin : MonoBehaviour
{
    public int selectedValue;
    public bool selectedMenu;
    public Image arrow;

    public OptionHandler optionHandler;
    public Animator animator;
    public GameObject music;
    public AudioSource clickSound;


    void Awake()
    {
        DontDestroyOnLoad(music);
    }

    public void Accept(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SceneManager.LoadScene("MEnu", LoadSceneMode.Single);
        }
    }

}