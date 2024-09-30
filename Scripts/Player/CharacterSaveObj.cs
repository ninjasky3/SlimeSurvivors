using UnityEngine;



[System.Serializable]
public class CharacterSaveDataObj
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