using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LevelRewards : MonoBehaviour
{

    public int gems;
    public int gold;
    public int energy;
    public int exp;

    //private GameDataManager gameData;

    private void Awake()
    {
        //gameData = FindAnyObjectByType<GameDataManager>();
    }


    public void levelFinished()
    {
        GameDataManager.instance.AddGems(gems);
        GameDataManager.instance.AddGold(gold);
        GameDataManager.instance.AddCharacterExp(exp);
    }

}
