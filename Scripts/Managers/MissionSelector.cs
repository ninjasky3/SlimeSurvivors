using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MissionSelector : MonoBehaviour
{
    public static MissionSelector instance;

    public string level;
    public int specificLevel;

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


    public void SelectLevel(string chosenLevel)
    {
        level = chosenLevel;
    }
    public void SelectSpecificLevel(int missionLevel)
    {
        specificLevel = missionLevel;
    }


    // Destroys the character selector.
    public void DestroySingleton()
    {
        instance = null;
        Destroy(gameObject);
    }
}