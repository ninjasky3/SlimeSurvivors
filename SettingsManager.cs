using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public CharacterSaveData characterSaveData;
    [SerializeField]
    private CharacterData characterData;
    void Start()
    {
        if (!ES3.KeyExists("first"))
        {
            var settings = new ES3Settings();
            settings.memberReferenceMode = ES3.ReferenceMode.ByRefAndValue;
            GameDataManager.instance.SetSelectedCharacter(characterData);

            CharacterSaveDataObj characterSaveDataObj = new CharacterSaveDataObj();
            characterSaveDataObj.Name = characterSaveData.Name;
            characterSaveDataObj.CharExp = characterSaveData.CharExp;
            characterSaveDataObj.SlotCharUnlocked = characterSaveData.SlotCharUnlocked;
            characterSaveDataObj.CharLevel = characterSaveData.CharLevel;
            ES3.Save(GameDataManager.instance.GetSelectedCharacter().Name, characterSaveDataObj, "SlimeFile.es3");

            CharacterSaveDataObj charobj = ES3.Load<CharacterSaveDataObj>(GameDataManager.instance.GetSelectedCharacter().Name);
            characterSaveData.CharExp = charobj.CharExp;
            characterSaveData.CharLevel = charobj.CharLevel;
            characterSaveData.Name = charobj.Name;

            ES3.Save("selectedCharacterSaveData", characterSaveData, "SlimeFile.es3");
            ES3.Save("selectedCharacterData", characterData, "SlimeFile.es3", settings);


            Debug.Log(GameDataManager.instance.GetSelectedCharacter().Name);
            GameDataManager.instance.SetSelectedCharacterSaveData(characterSaveData);

            ES3.Save("first", "yes", "SlimeFile.es3");
        }

    }


}
