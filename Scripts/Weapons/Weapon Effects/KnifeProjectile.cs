using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeProjectile : Projectile
{
    protected override void FixedUpdate()
    {
        // Only drive movement ourselves if this is a kinematic.
        if (rb.bodyType == RigidbodyType2D.Kinematic)
        {

            Weapon.Stats stats = weapon.GetStats();
            float moveSpeed = stats.speed * weapon.Owner.Stats.speed * Time.fixedDeltaTime;

            // Calculate the movement direction and apply it to the position.
            Vector2 movement = (Vector2)transform.right * moveSpeed;
            Vector2 newPosition = rb.position + movement;
            rb.MovePosition(newPosition);

            // Rotate the transform at the given rotation speed.
            transform.Rotate(rotationSpeed * Time.deltaTime);
        }
    }
}
