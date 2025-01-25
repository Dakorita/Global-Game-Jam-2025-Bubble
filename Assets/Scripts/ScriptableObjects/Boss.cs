using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Boss : ScriptableObject
{

    [TextArea(10, 100)]
    public string bossGood;
    public string bossNeutral;
    public string bossBad;

}
