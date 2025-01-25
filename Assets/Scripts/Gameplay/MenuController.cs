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

    public void Move(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ChangeSelectedValue((int)context.ReadValue<float>());
        }
    }
    public void Options(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            SceneManager.LoadScene("Main", LoadSceneMode.Single);


        }
    }

    public void ChangeSelectedValue(int value)
    {
        selectedValue -= value;
        selectedValue = selectedValue <= -1 ? 2 : (selectedValue >= 3 ? 0 : selectedValue);
        OptionSelect(selectedValue);
    }

    public void OptionSelect(int position)
    {
        switch (position)
        {
            case 0:
                arrow.rectTransform.anchoredPosition = new Vector3(143, 156, 0);
                break;
            case 1:
                arrow.rectTransform.anchoredPosition = new Vector3(143, 68, 0);
                break;
            case 2:
                arrow.rectTransform.anchoredPosition = new Vector3(143, -28, 0);
                break;
            case 3:
                arrow.rectTransform.anchoredPosition = new Vector3(143, -28, 0);
                break;
            default:
                break;
        }
    }
}
