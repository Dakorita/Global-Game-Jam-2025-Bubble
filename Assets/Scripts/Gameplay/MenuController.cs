using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public int selectedValue;
    public bool selectedMenu;
    public Image arrow;

    public OptionHandler optionHandler;
    public Animator animator;
    public AudioSource clickSound;



    public void Move(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ChangeSelectedValue((int)context.ReadValue<float>());
        }
    }
    public void Accept(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Action(selectedValue);
        }
    }

    public void ChangeSelectedValue(int value)
    {
        clickSound.Play();
        selectedValue -= value;
        selectedValue = selectedValue <= -1 ? 2 : (selectedValue >= 3 ? 0 : selectedValue);
        OptionSelect(selectedValue);
    }

    public void OptionSelect(int position)
    {
        switch (position)
        {
            case 0:
                arrow.rectTransform.anchoredPosition = new Vector3(-108, -55, 0);
                break;
            case 1:
                arrow.rectTransform.anchoredPosition = new Vector3(-108, -92, 0);
                break;
            case 2:
                arrow.rectTransform.anchoredPosition = new Vector3(-108, -126, 0);
                break;

            default:
                break;
        }
    }
    public void Action(int value)
    {
        switch (value)
        {
            case 0:
                SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
                break;
            case 1:
                SceneManager.LoadScene("Credits", LoadSceneMode.Single);
                break;
            case 2:
                Application.Quit();
                Debug.Log("APAGA");
                break;
            default:
                break;
        }
    }
}
