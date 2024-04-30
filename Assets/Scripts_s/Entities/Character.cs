using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacter", menuName = "Data/New Character")]
[System.Serializable]
public class Character : ScriptableObject
{
    public string charName;
    public Sprite sprite;
}