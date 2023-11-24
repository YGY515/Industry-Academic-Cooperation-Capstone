using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "proverbData", menuName = "MiniGame3/ProverbDatas", order = 2)]
public class ProverbPool : ScriptableObject
{
    public string[] start;
    public string[] end;
    public string[] meaning;
}
