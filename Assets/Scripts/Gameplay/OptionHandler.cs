using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OptionHandler : MonoBehaviour
{
    public News firstNews;
    public News secondNews;
    public News thirdNews;
    public News fourthNews;
    public News fifthNews;
    public Boss bossMessage;
    public TextMeshProUGUI newsBody;
    public TextMeshProUGUI firstOption;
    public TextMeshProUGUI secondOption;
    public TextMeshProUGUI thirdOption;
    public TextMeshProUGUI bossText;


    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateText(int situation)
    {
        switch (situation)
        {
            case 1:
                newsBody.text = firstNews.newsBody;
                firstOption.text = firstNews.firstOption;
                secondOption.text = firstNews.secondOption;
                thirdOption.text = firstNews.thirdOption;
                break;
            case 2:
                newsBody.text = secondNews.newsBody;
                firstOption.text = secondNews.firstOption;
                secondOption.text = secondNews.secondOption;
                thirdOption.text = secondNews.thirdOption;
                break;
            case 3:
                newsBody.text = thirdNews.newsBody;
                firstOption.text = thirdNews.firstOption;
                secondOption.text = thirdNews.secondOption;
                thirdOption.text = thirdNews.thirdOption;
                break;
            case 4:
                newsBody.text = fourthNews.newsBody;
                firstOption.text = fourthNews.firstOption;
                secondOption.text = fourthNews.secondOption;
                thirdOption.text = fourthNews.thirdOption;
                break;
            case 5:
                newsBody.text = fifthNews.newsBody;
                firstOption.text = fifthNews.firstOption;
                secondOption.text = fifthNews.secondOption;
                thirdOption.text = fifthNews.thirdOption;
                break;
            default:
                break;
        }
    }
    public int OptionSelect(int situation, int value)
    {
        switch (situation)
        {
            case 1:
                switch (value)
                {
                    case 0:
                        bossText.text = bossMessage.bossBad;
                        return -1;
                    case 1:
                        bossText.text = bossMessage.bossNeutral;
                        return 0;
                    case 2:
                        bossText.text = bossMessage.bossGood;
                        EndingLoader.flagsRissen.Add(firstNews.flagToRaise);
                        return 1;
                    default:
                        return 0;
                }
            case 2:
                switch (value)
                {
                    case 0:
                        bossText.text = bossMessage.bossBad;
                        return -1;
                    case 1:
                        bossText.text = bossMessage.bossNeutral;
                        return 0;
                    case 2:
                        bossText.text = bossMessage.bossGood;
                        EndingLoader.flagsRissen.Add(secondNews.flagToRaise);
                        return 1;
                    default:
                        return 0;
                }
            case 3:
                switch (value)
                {
                    case 0:
                        bossText.text = bossMessage.bossBad;
                        return -1;
                    case 1:
                        bossText.text = bossMessage.bossNeutral;
                        return 0;
                    case 2:
                        bossText.text = bossMessage.bossGood;
                        EndingLoader.flagsRissen.Add(thirdNews.flagToRaise);
                        return 1;
                    default:
                        return 0;
                }
            case 4:
                switch (value)
                {
                    case 0:
                        bossText.text = bossMessage.bossBad;
                        return -1;
                    case 1:
                        bossText.text = bossMessage.bossNeutral;
                        return 0;
                    case 2:
                        bossText.text = bossMessage.bossGood;
                        EndingLoader.flagsRissen.Add(fourthNews.flagToRaise);
                        return 1;
                    default:
                        return 0;
                }
            case 5:
                switch (value)
                {
                    case 0:
                        bossText.text = bossMessage.bossBad;
                        return -1;
                    case 1:
                        bossText.text = bossMessage.bossNeutral;
                        return 0;
                    case 2:
                        bossText.text = bossMessage.bossGood;
                        EndingLoader.flagsRissen.Add(fifthNews.flagToRaise);
                        return 1;
                    default:
                        return 0;
                }
        }
        return 0;
    }
}
