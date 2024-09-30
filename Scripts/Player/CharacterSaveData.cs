using UnityEngine;

[CreateAssetMenu(fileName = "Character Save Data", menuName = "Player/Character Save Data")]


public class CharacterSaveData : ScriptableObject
{


    [SerializeField]
    new string name;
    public string Name { get => name;  set => name = value; }

    [SerializeField]
    bool slotCharUnlocked;
    public bool SlotCharUnlocked { get => slotCharUnlocked;  set => slotCharUnlocked = value; }

    [SerializeField]
     int charExp;
    public int CharExp { get => charExp;  set => charExp = value; }

    [SerializeField]
    int charLevel;
    public int CharLevel { get => charLevel;  set => charLevel = value; }

    
}