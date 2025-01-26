using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class Controller : MonoBehaviour
{
    public int selectedValue;
    public bool selectedMenu;
    public int currentQuestion;
    public int timeInDay;
    public GameObject menu;
    public Image arrow;
    public Image calendar;
    public OptionHandler optionHandler;
    public Animator animator;
    public int bubbleValue;
    public AudioMixer audioMixer;
    public float volume;
    public AudioSource clickSound;

    // Start is called before the first frame update
    void Start()
    {
        bubbleValue = 0;
        currentQuestion = 1;
        NextDay(currentQuestion);
        StartDay();
    }

    // Update is called once per frame
    void Update()
    {
        if (bubbleValue >= 3) StartCoroutine(GoToEnding());
    }

    public void Move(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!selectedMenu) ChangeSelectedValue((int)context.ReadValue<float>());
        }
    }
    public void Options(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (!selectedMenu)
            {
                ChangeSelectedMenu((int)context.ReadValue<float>());
                selectedValue = 0;
            }
            else
            {
                audioMixer.GetFloat("Master", out volume);
                volume += context.ReadValue<float>();
                audioMixer.SetFloat("Master", volume);
            }


        }
    }
    public void Accept(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Action();
        }
    }
    public void ChangeSelectedValue(int value)
    {
        clickSound.Play();
        selectedValue -= value;
        selectedValue = selectedValue <= -1 ? 2 : (selectedValue >= 3 ? 0 : selectedValue);
        OptionSelect(selectedValue);
    }
    public void ChangeSelectedMenu(int value)
    {
        clickSound.Play();
        selectedMenu = value != -1;
        MenuOrNot(selectedMenu);

    }
    public void OptionSelect(int position)
    {
        switch (position)
        {
            case 0:
                arrow.rectTransform.anchoredPosition = new Vector3(123, 156, 0);
                break;
            case 1:
                arrow.rectTransform.anchoredPosition = new Vector3(123, 68, 0);
                break;
            case 2:
                arrow.rectTransform.anchoredPosition = new Vector3(123, -28, 0);
                break;
            default:
                break;
        }
    }
    public void MenuOrNot(bool menu)
    {
        var trueMenu = new Vector3(280, 263, 0);
        var falseMenu = new Vector3(123, 156, 0);
        arrow.rectTransform.anchoredPosition = menu ? trueMenu : falseMenu;
        Time.timeScale = menu ? 0 : 1;

    }

    public void Action()
    {
        if (!selectedMenu)
        {
            currentQuestion += 1;
            NextDay(currentQuestion);
            bubbleValue += optionHandler.OptionSelect(currentQuestion, selectedValue);

        }
        else
        {
            selectedMenu = !selectedMenu;
            MenuOrNot(selectedMenu);
            menu.SetActive(!menu.activeSelf);
        }

    }
    public void NextDay(int situation)
    {
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

    public IEnumerator GoToEnding()
    {
        //Invoke Animations
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
}
