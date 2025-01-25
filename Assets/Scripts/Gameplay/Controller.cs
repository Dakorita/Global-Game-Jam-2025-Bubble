using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    public int selectedValue;
    public bool selectedMenu;
    protected int currentQuestion;
    public int timeInDay;
    public GameObject menu;
    public Image arrow;
    public Image calendar;
    public OptionHandler optionHandler;
    public Animator animator;
    public int bubbleValue;


    // Start is called before the first frame update
    void Start()
    {
        currentQuestion = 1;
        NextDay(currentQuestion);
        StartDay();
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
        }
    }
    public void Options(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ChangeSelectedMenu((int)context.ReadValue<float>());
            selectedValue = 0;

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
            NextDay(situation);
        }
        else
        {
            menu.SetActive(!menu.activeSelf);
        }
    }
    public void NextDay(int situation)
    {
        bubbleValue += optionHandler.OptionSelect(situation, selectedValue);
        calendar.enabled = true;
        optionHandler.UpdateText(situation);

    }
    public void StartDay()
    {
        timeInDay = 15;
        StartCoroutine(DayRun());
    }
    public IEnumerator DayRun()
    {
        if (timeInDay == 0)
        {
            NextDay(currentQuestion);
            currentQuestion += 1;
        }
        yield return new WaitForSeconds(1);
        timeInDay -= 1;
        if (timeInDay >= 0) StartCoroutine(DayRun());

    }

}
