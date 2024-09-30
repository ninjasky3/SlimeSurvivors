using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class FireballAura : ProjectileWeapon
{
    public float radius = 2.0f; // Radius of the circle around the player
    private float rotationSpeed; // Speed at which the fireballs rotate around the player

    public int maxInstances = 3; // Maximum number of fireball instances
    private List<Projectile> activeProjectiles = new List<Projectile>();

    private Transform playerTransform;

    private void Start()
    {
        // Assuming the player's transform is stored in a variable called playerTransform
        playerTransform = GameObject.FindWithTag("Player").transform;

    }

    protected override bool Attack(int attackCount = 1)
    {
        // Ensure the number of active instances is below the maximum allowed
        if (activeProjectiles.Count >= maxInstances) return false;

        // If no projectile prefab is assigned, leave a warning message.
        if (!currentStats.projectilePrefab)
        {
            Debug.LogWarning(string.Format("Projectile prefab has not been set for {0}", name));
            ActivateCooldown(true);
            return false;
        }

        // Calculate the angle and offset for the spawned projectile
        float spawnAngle = GetSpawnAngle();
        Vector2 offset = GetSpawnOffset(spawnAngle);
        Vector3 spawnPosition = playerTransform.position + new Vector3(4, 0, 0);

        // Spawn the fireball
        Projectile spawnedProjectile = Instantiate(
            currentStats.projectilePrefab,
            spawnPosition,
            Quaternion.Euler(0, 0, 0)
        );

        spawnedProjectile.weapon = this;
        spawnedProjectile.owner = owner;


        // Subscribe to the projectile's destruction event to remove it from the active list
        spawnedProjectile.OnDestroyEvent += () => activeProjectiles.Remove(spawnedProjectile);

        // Activate cooldown
        ActivateCooldown(true);

        return true;
    }

}