using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class EndingLoader : MonoBehaviour
{
    public TextMeshProUGUI text;

    public static List<int> flagsRissen = new List<int> { };
    public int rand = 0;
    public EndScene pred;
    public EndScene end1;
    public EndScene end2;
    public EndScene end3;
    public EndScene end4;
    public EndScene end5;


    // Start is called before the first frame update
    void Start()
    {
        if (flagsRissen.Count != 0)
        {
            rand = Random.Range(0, flagsRissen.Count);
            switch (flagsRissen[rand])
            {
                case 1:
                    text.text = end1.finaltext;

                    break;
                case 2:
                    text.text = end2.finaltext;

                    break;
                case 3:
                    text.text = end3.finaltext;

                    break;
                case 4:
                    text.text = end4.finaltext;

                    break;
                case 5:
                    text.text = end5.finaltext;

                    break;
            }
        }
        else
        {
            text.text = pred.finaltext;

        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
