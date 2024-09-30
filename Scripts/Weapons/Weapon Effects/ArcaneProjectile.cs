using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneProjectile : Projectile
{
    public override void AcquireAutoAimFacing()
    {
        float aimAngle; // We need to determine where to aim.

        // Find all enemies on the screen.
        EnemyStats[] targets = FindObjectsOfType<EnemyStats>();

        if (targets.Length > 0)
        {
            // Initialize the minimum distance with a large value and the closest target as null.
            float minDistance = float.MaxValue;
            EnemyStats closestTarget = null;

            // Iterate through all targets to find the closest one.
            foreach (EnemyStats target in targets)
            {
                float distance = Vector2.Distance(target.transform.position, weapon.Owner.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestTarget = target;
                }
            }

            // If a closest target is found, aim at it.
            if (closestTarget != null)
            {
                Vector2 difference = closestTarget.transform.position - transform.position;
                aimAngle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            }
            else
            {
                // If no target is found, pick a random angle.
                aimAngle = Random.Range(0f, 360f);
            }
        }
        else
        {
            // If there are no targets, pick a random angle.
            aimAngle = Random.Range(0f, 360f);
        }

        // Point the projectile towards where we are aiming at.
        transform.rotation = Quaternion.Euler(0, 0, aimAngle);
    }
}
