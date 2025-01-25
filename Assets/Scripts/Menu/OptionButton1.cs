using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionButton1 : MonoBehaviour
{
  public GameObject mainMenu;
  public GameObject optionMenu;

  public void Options()
  {
    optionMenu.SetActive(true);
    mainMenu.SetActive(false);
  }
  public void MainMenu()
  {
    optionMenu.SetActive(false);
    mainMenu.SetActive(true);
  }

}
