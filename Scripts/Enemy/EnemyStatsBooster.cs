using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsBooster : MonoBehaviour
{
    // Start is called before the first frame update
    EnemyStats enemyStats;


    private float damageBoost = 0f;
    private float healthBoost = 0f;
    private float level;

    void Start()
    {
        level = (float)MissionSelector.instance.specificLevel;
        enemyStats = GetComponent<EnemyStats>();
        BoostStats();
    }

    void BoostStats()
    {
        if(level > 1) { 
        Debug.LogWarning(level);
        damageBoost = level / 10;
        healthBoost = level / 10;
        damageBoost++;
        healthBoost++;
        Debug.LogWarning(damageBoost);
        enemyStats.currentDamage *= damageBoost;
        enemyStats.currentHealth *= healthBoost;
        }
    }
}
