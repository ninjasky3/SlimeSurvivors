using System.Collections.Generic;
using UnityEngine;

// Damage does not scale with Might stat currently.
public class LightningRingWeapon : ProjectileWeapon
{

    List<EnemyStats> allSelectedEnemies = new List<EnemyStats>();

    protected override bool Attack(int attackCount = 1)
    {
        // If no projectile prefab is assigned, leave a warning message.
        if (!currentStats.hitEffect)
        {
            Debug.LogWarning(string.Format("Hit effect prefab has not been set for {0}", name));
            ActivateCooldown(true);
            return false;
        }

        // If there is no projectile assigned, set the weapon on cooldown.
        if (!CanAttack()) return false;

        // If the cooldown is less than 0, this is the first firing of the weapon.
        // Refresh the array of selected enemies.
        if (currentCooldown <= 0)
        {
            allSelectedEnemies = new List<EnemyStats>(FindObjectsOfType<EnemyStats>());
            ActivateCooldown();
            currentAttackCount = attackCount;
        }

        // Find an enemy in the map to strike with lightning.
        EnemyStats target = PickEnemy();
        if (target != null)
        {
            if (currentStats != null && currentStats.hitEffect != null)
            {
                // Debug logging
                Debug.Log("Target and currentStats are valid.");
                Debug.Log("Target Position: " + target.transform.position);
                Debug.Log("Area: " + GetArea());
                Debug.Log("Damage: " + GetDamage());

                // Additional null checks
                if (target.transform != null)
                {
                    DamageArea(target.transform.position, GetArea(), GetDamage());

                    // Instantiate the hit effect at the target's position
                    Instantiate(currentStats.hitEffect, target.transform.position, Quaternion.identity);
                }
                else
                {
                    Debug.LogWarning("Target transform is null.");
                }
            }
            else
            {
                Debug.LogWarning("Current stats or hit effect is null.");
            }
        }


        // If we have more than 1 attack count.
        if (attackCount > 0)
        {
            currentAttackCount = attackCount - 1;
            currentAttackInterval = currentStats.projectileInterval;
        }

        return true;
    }

    // Randomly picks an enemy on screen.
    EnemyStats PickEnemy()
    {
        EnemyStats target = null;
        while(!target && allSelectedEnemies.Count > 0)
        {
            int idx = Random.Range(0, allSelectedEnemies.Count);
            target = allSelectedEnemies[idx];

            // If the target is already dead, remove it and skip it. 
            if(!target)
            {
                allSelectedEnemies.RemoveAt(idx);
                continue;
            }

            // Check if the enemy is on screen.
            // If the enemy is missing a renderer, it cannot be struck, as we cannot
            // check whether it is on the screen or not.
            Renderer r = target.GetComponent<Renderer>();
            if (!r || !r.isVisible)
            {
                allSelectedEnemies.Remove(target);
                target = null;
                continue;
            }
        }

        allSelectedEnemies.Remove(target);
        return target;
    }

    // Deals damage in an area.
    void DamageArea(Vector2 position, float radius, float damage)
    {
        Collider2D[] targets = Physics2D.OverlapCircleAll(position, radius);
        foreach (Collider2D t in targets)
        {
            if (t.TryGetComponent<EnemyStats>(out var es)) {
                es.TakeDamage(damage, transform.position);
            } 
        }
    }
}