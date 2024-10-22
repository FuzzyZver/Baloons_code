using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewScriptableObject", menuName = "ScriptableObjects/DataBase", order = 1)]
public class DataBase : ScriptableObject
{
    public int coin;

    public bool[] buyChek;
    public bool[] levelChek;

    public bool soundCheck;
    public bool muzikCheck;
    public bool GuidCheck;
    public int languageIndex;

    public ScinBlueprint[] achiveArhive;

}
