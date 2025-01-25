using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class News : ScriptableObject
{
    [TextArea(10, 100)]
    public string newsBody;
    public string firstOption;
    public string secondOption;
    public string thirdOption;
    public int flagToRaise;
}
