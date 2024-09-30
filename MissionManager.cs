using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionManager : MonoBehaviour
{

    public TMP_Text levelDisplay;
    public TMP_Text MissionDisplay;
    MissionSelector missionSelector;
    // Start is called before the first frame update
    int currentLevel = 1; 
    void Start()
    {
        missionSelector = FindAnyObjectByType<MissionSelector>();
    }

    public void SelectMission(string mission)
    {
        missionSelector.SelectLevel(mission);
        MissionDisplay.text = mission;
    }
    public void SelectLevel(int level)
    {
        missionSelector.SelectSpecificLevel(level);
    }
    public void AddLevel()
    {
        if(currentLevel < 10)
        {
            currentLevel++;
            levelDisplay.text = currentLevel.ToString();
            missionSelector.SelectSpecificLevel(currentLevel);

        }
        
    }
    public void SelectLevelAuto()
    {
        SceneController controller = FindObjectOfType<SceneController>();
        controller.SceneChange(missionSelector.level);
    }
    public void ReduceLevel()
    {
        if(currentLevel > 1)
        {
            currentLevel--;
            levelDisplay.text = currentLevel.ToString();
            missionSelector.SelectSpecificLevel(currentLevel);
        }
       
    }
}
