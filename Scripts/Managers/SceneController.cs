using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private MissionSelector missionSelector;
    public void SceneChange(string name)
    {
        SceneManager.LoadScene(name);
        Time.timeScale = 1;
    }
    private void Start()
    {
        missionSelector = FindAnyObjectByType<MissionSelector>();
    }
    public void StartBattle()
    {
        missionSelector = (MissionSelector)GameObject.FindObjectOfType(typeof(MissionSelector));

        if(missionSelector != null )
        {
            SceneChange(missionSelector.level);
        }
        else
        {
            SceneChange("Game");
        }
        
    }
}
