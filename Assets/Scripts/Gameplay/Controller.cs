using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    protected int selectedValue;
    protected bool selectedMenu;
    protected int currentQuestion;
    public GameObject menu;
    public Image arrow;
    public Image calendar;
    protected OptionHandler optionHandler;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ChangeSelectedValue((int)context.ReadValue<float>());
            selectedValue = 0;
        }
    }
    public void Options(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ChangeSelectedMenu((int)context.ReadValue<float>());
        }
    }
    public void Accept(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Action(currentQuestion);
        }
    }
    public void ChangeSelectedValue(int value)
    {
        selectedValue -= value;
        selectedValue = selectedValue <= -1 ? 2 : (selectedValue >= 3 ? 0 : selectedValue);
        OptionSelect(selectedValue);
    }
    public void ChangeSelectedMenu(int value)
    {
        selectedMenu = value != -1;
        MenuOrNot(selectedMenu);

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
            default:
                break;
        }
    }
    public void MenuOrNot(bool menu)
    {
        var trueMenu = new Vector3(280, 263, arrow.rectTransform.transform.position.z);
        var falseMenu = new Vector3(143, 156, arrow.rectTransform.transform.position.z);
        arrow.rectTransform.anchoredPosition = menu ? trueMenu : falseMenu;

    }

    public void Action(int situation)
    {
        if (!selectedMenu)
        {
            switch (situation)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                default:
                    break;
            }
        }
        else
        {
            menu.SetActive(!menu.activeSelf);
        }
    }

}
