using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ������� ����� ���������������
[CreateAssetMenu(fileName = "NewScriptableObject", menuName = "ScriptableObjects/Basde", order = 1)]

public class Basdepapji : ScriptableObject
{
    public int coins;
    public int plusCount;
    public int skinIndex;
    public int chunkCount;
}
