using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterSlot : MonoBehaviour
{
    [SerializeField]
    private int slotCharLevel;
    [SerializeField]
    private int slotCharExp;
    [SerializeField]
    public bool slotCharUnlocked = false;
    [SerializeField]
    public CharacterData slotCharacterData;
    [SerializeField]
    private CharacterManager characterManager;

    private int expCap = 100;
    private int charLevelCap = 10;
    public bool isMaxLevel;

    [Header("UI Displays")]
    public TMP_Text expDisplay;
    public TMP_Text levelDisplay;
    public Slider expBar;

    // Start is called before the first frame update
    void Start()
    {
        if (!ES3.KeyExists(slotCharacterData.Name.ToString()))
        {
            return;
        }
        CharacterSaveDataObj charSaveObj = ES3.Load<CharacterSaveDataObj>(slotCharacterData.Name.ToString());
        if (charSaveObj != null) //fix this to data
        {

                slotCharExp = charSaveObj.CharExp;
                slotCharLevel = charSaveObj.CharLevel;


                Debug.Log("FoundChar" + slotCharExp+slotCharLevel);
            //DataPersistenceManager.Instance.SaveGame(); todo fix exp saving
            
        }
        characterManager = FindObjectOfType<CharacterManager>();
        Debug.Log("didnt find char");
        if (characterManager.savedUnlockedCharacters != null)
        {
            Debug.Log("char in manager");
            Debug.Log(characterManager.savedUnlockedCharacters.Count());
            foreach (CharacterData slots in characterManager.savedUnlockedCharacters)
            {
              /*  Debug.Log("didididi");
                if (slots.CharData == slotCharacterSaveData.CharData && slots.CharData != null && slots.CharData != GameDataManager.instance.GetSelectedCharacter())
                {
                    slotCharExp = slots.CharExp;
                    slotCharLevel = slots.CharLevel;
                    slotCharUnlocked = slots.SlotCharUnlocked;
                    Debug.LogWarning(slotCharExp + "set slot exp");
                }*/
            }
        }
        else
        {
            Debug.Log("nochar in manager");
        }
        List<CharacterData> characterDatas = GameDataManager.instance.GetUnlockedCharacters();
/*        if (characterDatas != null && characterDatas.Contains(slotCharacterSaveData.CharData))
        {
            slotCharUnlocked = true;
        }*/


        if (isMaxLevel)
        {
            expBar.value = 0;
            expBar.image.color = Color.yellow;
            expDisplay.text = expCap.ToString() + "/" + expCap.ToString();
            levelDisplay.text = "MAX";
        }
        else
        {
            expBar.value = (float)slotCharExp / expCap;
            levelDisplay.text = slotCharLevel.ToString() + "/ 10";
            expDisplay.text = slotCharExp.ToString() + "/ 100";
        }

    }


}
