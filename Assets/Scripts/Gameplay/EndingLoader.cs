using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class EndingLoader : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image image;
    public List<int> flagsRissen;
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
        rand = Random.Range(0, flagsRissen.Count);
        switch (rand)
        {
            case 1:
                text.text = end1.finaltext;
                image.sprite = end1.finalimage;
                break;
            case 2:
                text.text = end2.finaltext;
                image.sprite = end2.finalimage;
                break;
            case 3:
                text.text = end3.finaltext;
                image.sprite = end3.finalimage;
                break;
            case 4:
                text.text = end4.finaltext;
                image.sprite = end4.finalimage;
                break;
            case 5:
                text.text = end5.finaltext;
                image.sprite = end5.finalimage;
                break;
            default:
                text.text = pred.finaltext;
                image.sprite = pred.finalimage;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
