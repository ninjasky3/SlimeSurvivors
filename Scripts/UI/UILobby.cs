using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Slider = UnityEngine.UI.Slider;

public class UILobby : MonoBehaviour
{

    private int gold;
    private int gems;
    private int exp;
    private int charLevel;
    private int expCap = 100;
    private int charLevelCap = 10;
    public bool isMaxLevel;

    GameDataManager gameData;

    [Header("UI Displays")]
    public TMP_Text goldTextDisplay;
    public TMP_Text gemTextDisplay;
    public TMP_Text expDisplay;
    public TMP_Text levelDisplay;
    public Slider expBar;
    public Image selectedCharImage;

    void GetGold()
    {
       gold = GameDataManager.instance.GetGoldAmount();
    }
    void GetGems()
    {
        
        gems = GameDataManager.instance.GetGemAmount();
    }
    void GetExp()
    {
        
        exp = GameDataManager.instance.GetSelectedCharacterSaveData().CharExp;
    }
    void GetLevel() 
    {
        charLevel = GameDataManager.instance.GetSelectedCharacterSaveData().CharLevel;
        /*       if (exp >= expCap)
               {
                   if(charLevel >= charLevelCap)
                   {
                       isMaxLevel = true;
                       return;
                   }
                   charLevel++;
                   int tempExp = exp - expCap;
                   exp = 0;
                   exp += tempExp;*/
        // GameDataManager.instance.AddCharacterExp(-expCap);
        //GameDataManager.instance.AddCharacterLevel(1);
        //GameDataManager.instance.GetSelectedCharacterSaveData().CharLevel = GameDataManager.instance.GetLevelAmount();
        //GameDataManager.instance.GetSelectedCharacterSaveData().CharExp = GameDataManager.instance.GetExpAmount();


        //}
    }
    // Start is called before the first frame update
    void Start()
    {
        //DataPersistenceManager.Instance.getPersistenceObjects();
        if (ES3.KeyExists("selectedCharacterData"))
        {
            if (ES3.KeyExists(GameDataManager.instance.GetSelectedCharacter().Name))
            {


                GameDataManager.instance.LoadCharsaveData();
                GetGold();
                GetGems();
                GetExp();
                GetLevel();
                selectedCharImage.sprite = GameDataManager.instance.GetSelectedCharacter().CharacterImage;
                Debug.Log(gold);
                if (isMaxLevel)
                {
                    expBar.value = 0;
                    expBar.image.color = Color.yellow;
                    expDisplay.text = expCap.ToString() + "/" + expCap.ToString();
                    levelDisplay.text = "MAX";
                }
                else
                {
                    expBar.value = (float)exp / expCap;
                    levelDisplay.text = charLevel.ToString() + "/ 10";
                    expDisplay.text = exp.ToString() + "/ 100";
                }

                goldTextDisplay.text = gold.ToString();
                gemTextDisplay.text = gems.ToString();


                Debug.Log(gold + "" + gems + "" + exp + "" + charLevel);

                if (GameDataManager.instance.GetSelectedCharacterSaveData() != null)
                {
                    GameDataManager.instance.SetSelectedCharacterExpLevel();
                    //GameDataManager.instance.GetSelectedCharacterSaveData().CharExp = GameDataManager.instance.GetExpAmount();
                    // ES3.Save<int>("exp", GameDataManager.instance.GetExpAmount(), "SlimeFile.es3");
                    //ES3.Save<int>("selectedCharLevel", GameDataManager.instance.GetLevelAmount(), "SlimeFile.es3");
                }

            }
        }

    }

}
