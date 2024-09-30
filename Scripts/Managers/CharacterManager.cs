using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//This class is used for selecting and unlocking characters in the character select screen.
public class CharacterManager : MonoBehaviour
{
    public List<CharacterData> savedUnlockedCharacters; //List containing all the characters that are unlocked
    public List<CharacterData> savedStartingCharacters; //This list contains the characters the player starts with when first playing.
    public string catalystHeroId = ""; //String id used for unlocking new characters

    void Awake()
    {
        //DataPersistenceManager.Instance.getPersistenceObjects(); //old save code  
        if (savedUnlockedCharacters == null)
        {
            savedUnlockedCharacters = new List<CharacterData>();
        }
    }

    void Start()
    {
        //Check if there are unlocked characters and load them if there are.
        if (ES3.KeyExists("savedUnlockedCharacters"))
        {
            savedUnlockedCharacters = ES3.Load<List<CharacterData>>("savedUnlockedCharacters");
        }

        //unlock the first 2 characters on the first time playing
        if (savedUnlockedCharacters != null && savedUnlockedCharacters.Count == 0 && !savedUnlockedCharacters.Contains(savedStartingCharacters[0]))
        {
            UnlockCharSlot(savedStartingCharacters[0]);
            UnlockCharSlot(savedStartingCharacters[1]);
           
        }
    }

    //Method for unlocking characters in the character select screen.
    public void UnlockCharSlot(CharacterData slot)
    {
        catalystHeroId = slot.Name; 
        if (ES3.KeyExists("savedUnlockedCharacters")){
            savedUnlockedCharacters = ES3.Load<List<CharacterData>>("savedUnlockedCharacters");
        }
        
        if (savedUnlockedCharacters.Contains(slot))
        {
            return;
        }

        //if checks for different characters to unlock.
        //TODO: make this less hardcoded.
        if(catalystHeroId == "Dark Slime")
        {
            savedUnlockedCharacters.Add(slot);
            Debug.Log("Added slot: " + slot.Name);

            if (GameDataManager.instance != null)
            {


                ES3.Save("savedUnlockedCharacters", savedUnlockedCharacters, "SlimeFile.es3");
                //GameDataManager.instance.UnlockCharacter(slot.CharData); //fix unlock
                Debug.Log("Character unlocked: " + slot.Name);
                GameDataManager.instance.SetUnlockedCharacters(savedUnlockedCharacters);

            }
            else
            {
                Debug.LogError("GameDataManager.instance is null!");
            }
        }
        if (catalystHeroId == "Arcane Adult") 
        {
            savedUnlockedCharacters.Add(slot);
            Debug.Log("Added slot: " + slot.Name);

            if (GameDataManager.instance != null)
            {


                ES3.Save("savedUnlockedCharacters", savedUnlockedCharacters, "SlimeFile.es3");
                //GameDataManager.instance.UnlockCharacter(slot.CharData); //fix unlock
                Debug.Log("Character unlocked: " + slot.Name);
                GameDataManager.instance.SetUnlockedCharacters(savedUnlockedCharacters);

            }
            else
            {
                Debug.LogError("GameDataManager.instance is null!");
            }
        }
        if (catalystHeroId == "Antonio")
        {
            savedUnlockedCharacters.Add(slot);
            Debug.Log("Added slot: " + slot.Name);

            if (GameDataManager.instance != null)
            {


                ES3.Save("savedUnlockedCharacters", savedUnlockedCharacters, "SlimeFile.es3");
                //GameDataManager.instance.UnlockCharacter(slot.CharData); //fix unlock
                Debug.Log("Character unlocked: " + slot.Name);
                GameDataManager.instance.SetUnlockedCharacters(savedUnlockedCharacters);

            }
            else
            {
                Debug.LogError("GameDataManager.instance is null!");
            }
        }
        else
        {
            if (ES3.KeyExists(catalystHeroId))
            {
                CharacterSaveDataObj catalystHero = ES3.Load<CharacterSaveDataObj>(catalystHeroId);
                if (catalystHero != null)
                {
                    if (catalystHero.CharLevel > 0)
                    {


                        savedUnlockedCharacters.Add(slot);
                        Debug.Log("Added slot: " + slot.Name);

                        if (GameDataManager.instance != null)
                        {


                            ES3.Save("savedUnlockedCharacters", savedUnlockedCharacters, "SlimeFile.es3");
                            //GameDataManager.instance.UnlockCharacter(slot.CharData); //fix unlock
                            Debug.Log("Character unlocked: " + slot.Name);
                            GameDataManager.instance.SetUnlockedCharacters(savedUnlockedCharacters);

                        }
                        else
                        {
                            Debug.LogError("GameDataManager.instance is null!");
                        }
                    }
                }
            }

        }
    }
    //Method for setting the character needed to unlock in the scene.
    public void SetCatalystName(string catalystName)
    {
        catalystHeroId = catalystName;
    }

    //Method for selecting the character you will be playing with.
    public void SelectNewCharacter(CharacterData newCharacter)
    {
        if(!savedUnlockedCharacters.Contains(newCharacter))
        {
            return;
        }
        var settings = new ES3Settings();
        settings.memberReferenceMode = ES3.ReferenceMode.ByRefAndValue;
        GameDataManager.instance.SetSelectedCharacter(newCharacter);
        //ES3.Save("selectedCharacterData", newCharacter, "SlimeFile.es3");

        if (ES3.KeyExists("selectedCharacterData"))
        {
            /*            var testharacterData = ScriptableObject.CreateInstance<CharacterData>();
                        ES3.LoadInto<CharacterData>("selectedCharacterData", testharacterData, settings);
                        testharacterData.Name = newCharacter.Name;
                        testharacterData.CharacterImage = newCharacter.CharacterImage;
                        testharacterData.CharacterAnimator = newCharacter.CharacterAnimator;
                        testharacterData.CharacterSprite = newCharacter.CharacterSprite;
                        testharacterData.StartingWeapon = newCharacter.StartingWeapon;
                        ES3.Save("selectedCharacterData", testharacterData, "SlimeFile.es3", settings);*/
            ES3.Save("selectedCharacterData", newCharacter, "SlimeFile.es3", settings);
        }
        else
        {
            ES3.Save("selectedCharacterData", newCharacter, "SlimeFile.es3", settings);
            /*var testharacterData2 = ScriptableObject.CreateInstance<CharacterData>();

            testharacterData2.Name = newCharacter.Name;
            testharacterData2.CharacterImage = newCharacter.CharacterImage;
            testharacterData2.CharacterAnimator = newCharacter.CharacterAnimator;
            testharacterData2.CharacterSprite = newCharacter.CharacterSprite;
            testharacterData2.StartingWeapon = newCharacter.StartingWeapon;
            ES3.Save("selectedCharacterData", testharacterData2, "SlimeFile.es3", settings);*/
        }




    }

    //Method for selecting the save character data and scriptable object.
    public void SelectNewCharacterSave(CharacterSaveData charSaveData)
    {

        
        if (!savedUnlockedCharacters.Contains(GameDataManager.instance.GetSelectedCharacter()))
        {
            return;
        }

        if (ES3.KeyExists(GameDataManager.instance.GetSelectedCharacter().Name))
        {
            //if there is a save for the selecter character load the data into the save object.
            CharacterSaveDataObj charobj = ES3.Load<CharacterSaveDataObj>(GameDataManager.instance.GetSelectedCharacter().Name);
            charSaveData.CharExp = charobj.CharExp;
            charSaveData.CharLevel = charobj.CharLevel;
            charSaveData.Name = charobj.Name;
        }
        else
        {
            //if there is not a save for the selected character create a new savedata object and load the scritable object data into it.

            /*var testharacterData = ScriptableObject.CreateInstance<CharacterSaveData>();
            testharacterData.Name = charSaveData.Name;
            testharacterData.CharExp = charSaveData.CharExp;
            testharacterData.SlotCharUnlocked = charSaveData.SlotCharUnlocked;
            testharacterData.CharLevel = charSaveData.CharLevel;*/
            ES3.Save("selectedCharacterSaveData", charSaveData, "SlimeFile.es3");

            CharacterSaveDataObj characterSaveDataObj = new CharacterSaveDataObj();
            characterSaveDataObj.Name = charSaveData.Name;
            characterSaveDataObj.CharExp = charSaveData.CharExp;
            characterSaveDataObj.SlotCharUnlocked = charSaveData.SlotCharUnlocked;
            characterSaveDataObj.CharLevel = charSaveData.CharLevel;
            ES3.Save(GameDataManager.instance.GetSelectedCharacter().Name, characterSaveDataObj, "SlimeFile.es3");

        }

        GameDataManager.instance.SetSelectedCharacterSaveData(charSaveData); // set current character save data in the static GameDataManager for reference.


    }
}
