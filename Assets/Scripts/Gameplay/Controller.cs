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
    private bool canAct;
    public int selectedValue;
    public bool selectedMenu;
    public int currentQuestion;
    public int timeInDay;
    public Image arrow;
    public Image calendar;
    public OptionHandler optionHandler;
    public Animator animatorBubble;
    public GameObject menu;
    public Animator animatorCalendar;
    public Animator animatorBoss;
    public int bubbleValue;
    public AudioMixer audioMixer;
    public float volume;
    public AudioSource clickSound;
    public AudioSource bossMessage;
    public GameObject Cross1;

    public GameObject Cross2;

    public GameObject Cross3;

    public GameObject Cross4;

    public GameObject Cross5;

    // Start is called before the first frame update
    void Start()
    {
        canAct = false;
        StartCoroutine(CanActAgain());
        bubbleValue = 0;
        currentQuestion = 1;
        NextDay(currentQuestion);
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
            ChangeSelectedValue((int)context.ReadValue<float>());
        }
    }

    public void Accept(InputAction.CallbackContext context)
    {
        if (context.performed && canAct)
        {
            canAct = false;
            StartCoroutine(CanActAgain());
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


    public void Action()
    {

        currentQuestion += 1;
        CrossDay();
        NextDay(currentQuestion);
        bubbleValue += optionHandler.OptionSelect(currentQuestion, selectedValue);
        animatorBubble.SetInteger("BubbleValue", bubbleValue);
        animatorBoss.SetBool("In", true);
        animatorCalendar.SetBool("CalendarIn", true);
        bossMessage.Play();
        StartCoroutine(ExitAnimations());


    }
    public void NextDay(int situation)
    {
        if (currentQuestion == 6)
        {
            StartCoroutine(GoToEnding());
        }
        calendar.enabled = true;
        optionHandler.UpdateText(situation);

    }

    public void CrossDay()
    {
        switch (currentQuestion)
        {
            case 2:
                Cross1.SetActive(true);
                break;
            case 3:
                Cross2.SetActive(true);
                break;
            case 4:
                Cross3.SetActive(true);
                break;
            case 5:
                Cross4.SetActive(true);
                break;
            case 6:
                Cross5.SetActive(true);
                break;
        }
    }
    public IEnumerator GoToEnding()
    {
        //Invoke Animations
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }
    public IEnumerator CanActAgain()
    {
        yield return new WaitForSeconds(1.7f);
        canAct = true;
    }
    public IEnumerator ExitAnimations()
    {
        yield return new WaitForSeconds(1);
        animatorBoss.SetBool("In", false);
        animatorCalendar.SetBool("CalendarIn", false);
    }

}
