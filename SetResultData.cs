using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetResultData : MonoBehaviour
{

    public TMP_Text goldEarnedText;
    public TMP_Text charExpText;
    public TMP_Text charLevelText;
    public TMP_Text gemsText;
    // Start is called before the first frame update
    void Start()
    {
        CharacterSaveDataObj tempobj = ES3.Load<CharacterSaveDataObj>(GameDataManager.instance.GetSelectedCharacter().Name);
        goldEarnedText.text = FindAnyObjectByType<PlayerStats>().playerGold.ToString();
        charExpText.text = tempobj.CharExp.ToString();
        charLevelText.text = tempobj.CharLevel.ToString();
        gemsText.text = FindAnyObjectByType<LevelRewards>().gems.ToString();
    }
}
