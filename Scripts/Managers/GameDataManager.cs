using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;
using UnityEngine.TextCore.Text;

public class GameDataManager : MonoBehaviour,IDataPersistence
{
    public static GameDataManager instance;




    [SerializeField]
    private int gold;
    [SerializeField]
    private int gems;
    [SerializeField] 
    private CharacterData selecterCharacter;
    [SerializeField]
    private int selectedCharacterExp;
    [SerializeField]
    private CharacterSaveData selectedCharacterSaveData;
    [SerializeField]
    private int selectedCharacterLevel;
    [SerializeField]
    private List<CharacterData> unlockedCharacters;




    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.LogWarning("EXTRA " + this + " DELETED");
            Destroy(gameObject);
        }

    }

    void Start()
    {


        var settings = new ES3Settings();
        settings.memberReferenceMode = ES3.ReferenceMode.ByRefAndValue;

        if (ES3.KeyExists("Gold"))
        {
            this.gold = ES3.Load<int>("Gold");
        }
           
        if (ES3.KeyExists("Gems"))
        {
            this.gems = ES3.Load<int>("Gems");
        }
            


        //load selected character data.
        if (ES3.KeyExists("selectedCharacterData"))
        {
            selecterCharacter = ES3.Load<CharacterData>("selectedCharacterData");
            Debug.Log(selecterCharacter.CharacterImage.name);
        }



        //old save/load code.
        /*            CharacterData testharacterData = ScriptableObject.CreateInstance<CharacterData>();
                    this.selecterCharacter = testharacterData;

                    ES3.LoadInto<CharacterData>("selectedCharacterData", testharacterData, settings);
                    var temp = ES3.Load<CharacterData>("selectedCharacterData");
                Debug.Log(temp.Icon);
                Debug.Log(testharacterData.Icon);
                Debug.Log(this.selecterCharacter.Icon);
                this.selecterCharacter.Name = testharacterData.Name;
                    this.selecterCharacter.StartingWeapon = testharacterData.StartingWeapon;
                    this.selecterCharacter.Icon = testharacterData.Icon;
                    this.selecterCharacter.CharacterAnimator = testharacterData.CharacterAnimator;
                    this.selecterCharacter.CharacterImage = testharacterData.CharacterImage;
                Debug.Log(this.selecterCharacter.Icon);
        */
        //this.selecterCharacter = ES3.Load<CharacterData>("selectedCharacterData");





        //ES3.LoadInto<CharacterSaveData>("selectedCharacterSaveData", selectedCharacterSaveData);

        //Debug.Log(testharacterSaveData.CharExp);
        // Debug.Log(selectedCharacterSaveData.CharExp);

        //this.selectedCharacterSaveData = ES3.Load<CharacterSaveData>("selectedCharacterSaveData", settings);
        //selectedCharacterSaveData.CharExp = testharacterSaveData.CharExp;
        // selectedCharacterSaveData.CharLevel = testharacterSaveData.CharLevel;
        // selectedCharacterSaveData.Name = testharacterSaveData.Name;
        //Debug.Log(selectedCharacterSaveData.CharExp);
   
        //load character save data.
        if (ES3.KeyExists("selectedCharacterData"))
        {
            if (ES3.KeyExists(selecterCharacter.Name))
            {
                Debug.Log(selecterCharacter.Name + ES3.KeyExists(selecterCharacter.Name).ToString());
                if (ES3.KeyExists(selecterCharacter.Name))
                {
                    selectedCharacterSaveData = ScriptableObject.CreateInstance<CharacterSaveData>();

                    CharacterSaveDataObj charobj = ES3.Load<CharacterSaveDataObj>(selecterCharacter.Name);
                    selectedCharacterSaveData.CharExp = charobj.CharExp;
                    selectedCharacterSaveData.CharLevel = charobj.CharLevel;
                    selectedCharacterSaveData.Name = charobj.Name;

                    Debug.Log(selectedCharacterSaveData);
                }
            }
        }
        
 

    }
    public void LoadCharsaveData()
    {
        if (ES3.KeyExists("selectedCharacterData"))
        {
            selecterCharacter = ES3.Load<CharacterData>("selectedCharacterData");
            Debug.Log(selecterCharacter.CharacterImage.name);
        }
        if (ES3.KeyExists(selecterCharacter.Name))
        {
            selectedCharacterSaveData = ScriptableObject.CreateInstance<CharacterSaveData>();

            CharacterSaveDataObj charobj = ES3.Load<CharacterSaveDataObj>(selecterCharacter.Name);
            selectedCharacterSaveData.CharExp = charobj.CharExp;
            selectedCharacterSaveData.CharLevel = charobj.CharLevel;
            selectedCharacterSaveData.Name = charobj.Name;
        }
        if (ES3.KeyExists("savedUnlockedCharacters"))
        {
            unlockedCharacters = ES3.Load<List<CharacterData>>("savedUnlockedCharacters");
        }
    }

    public void DestroySingleton()
    {
        instance = null;
        Destroy(gameObject);
    }

    //getters and setters for the variables in the manager.
    public void AddGold(int amount)
    {
        gold += amount;

    }
    public void AddGems(int amount)
    {
        gems += amount;

    }
    public void AddCharacterExp(int amount)
    {
        selectedCharacterExp += amount;

    }
    public void SetSelectedCharacter(CharacterData character)
    {
        Debug.Log("indcharmanager" + character);
        selecterCharacter = character;



    }
    public void SetSelectedCharacterExpLevel()
    {
        selectedCharacterExp = selectedCharacterSaveData.CharExp;
        selectedCharacterLevel = selectedCharacterSaveData.CharLevel;


    }
    public void AddCharacterLevel(int amount)
    {
        selectedCharacterLevel += amount;

    }
    public int GetGoldAmount()
    {
        return gold;
    }
    public CharacterData GetSelectedCharacter()
    {
        return selecterCharacter;
    }
    public CharacterSaveData GetSelectedCharacterSaveData()
    {
        return selectedCharacterSaveData;
    }
    public void SetSelectedCharacterSaveData(CharacterSaveData saveData)
    {
        selectedCharacterSaveData = saveData;
    }
    public int GetGemAmount()
    {
        Debug.Log("getting gems"+gems);
        return gems;
      
    }
    public int GetExpAmount()
    {
        return selectedCharacterExp;
    }

    public int GetLevelAmount()
    {
        return selectedCharacterLevel;
    }
    public List<CharacterData> GetUnlockedCharacters()
    {
        return unlockedCharacters;
    }
    public void SetUnlockedCharacters(List<CharacterData> data)
    {
        unlockedCharacters = data;
    }
    public void UnlockCharacter(CharacterData characterToAdd)
    {
        Debug.Log(unlockedCharacters);
        if(unlockedCharacters == null)
        {
            unlockedCharacters = new List<CharacterData>();
        }
        Debug.Log(unlockedCharacters);
        Debug.Log(characterToAdd);
        unlockedCharacters.Add(characterToAdd);
    }

    //old save code working with the datapersistence manager.
    public void LoadData(GameData data)
    {

/*        if (ES3.KeyExists("gold"))
            this.gold = ES3.Load<int>("gold", 0);
        if (ES3.KeyExists("gems"))
            this.gems = ES3.Load<int>("gems", 0);
        if (ES3.KeyExists("selectedCharacterData"))
            this.selecterCharacter = ES3.Load<CharacterData>("selectedCharacterData");

        


        if (ES3.KeyExists("selectedCharacterSaveData"))
            this.selectedCharacterSaveData = ES3.Load<CharacterSaveData>("selectedCharacterSaveData");
        if (ES3.KeyExists("charExp"))
            this.selectedCharacterExp = ES3.Load<int>("charExp", 0);
        if (ES3.KeyExists("selectedCharLevel"))
            this.selectedCharacterLevel = ES3.Load<int>("selectedCharLevel", 0);*/


    }

    public void SaveData(ref GameData data)
    {
/*        ES3.Save<int>("gems", this.gems, "SlimeFile.es3");
        ES3.Save<int>("gold", this.gold, "SlimeFile.es3");
        ES3.Save<int>("exp", this.selectedCharacterExp, "SlimeFile.es3");
        ES3.Save<int>("selectedCharLevel", this.selectedCharacterLevel, "SlimeFile.es3");
        ES3.Save<List<CharacterData>>("unlockedCharacters", this.unlockedCharacters, "SlimeFile.es3");
        ES3.Save<CharacterSaveData>("selectedCharacterSaveData", this.selectedCharacterSaveData, "SlimeFile.es3");
        ES3.Save<CharacterData>("selectedCharacterData", this.selecterCharacter, "SlimeFile.es3");*/

    }
}