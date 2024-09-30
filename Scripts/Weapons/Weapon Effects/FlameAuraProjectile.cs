using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using static UnityEngine.GraphicsBuffer;

public class FlameAuraProjectile : Projectile
{
    private GameObject player;
    private Weapon.Stats stats;
    private Vector3 initialOffset;

    protected override void Start()
    {
        base.Start();
        player = GameObject.FindWithTag("RotatingAura");
        transform.parent = player.transform;
        stats = weapon.GetStats();

        // Set an initial offset relative to the player's position
        float radius = stats.area + 2.0f; // Adjust as needed
        float initialAngle = Random.Range(0, 2 * Mathf.PI);
        initialOffset = new Vector3(
            Mathf.Cos(initialAngle) * radius,
            Mathf.Sin(initialAngle) * radius,
            0); // Assuming 2D movement, set z to 0
    }

    protected override void FixedUpdate()
    {
        float angle = Time.time * 10;
        Vector3 positionCenterObject = player.transform.position;

        float x = positionCenterObject.x + initialOffset.x * Mathf.Cos(angle) - initialOffset.y * Mathf.Sin(angle);
        float y = positionCenterObject.y + initialOffset.x * Mathf.Sin(angle) + initialOffset.y * Mathf.Cos(angle);

        transform.position = new Vector3(x -2, y, transform.position.z);
       
    }
}
