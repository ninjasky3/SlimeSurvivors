using UnityEngine;

public class DeathCoin : MonoBehaviour
{
    public float lifespan = 0.5f;
    protected PlayerStats target; // If the pickup has a target, then fly towards the target.
    protected float speed; // The speed at which the pickup travels.
    Vector2 initialPosition;

    // To represent the bobbing animation of the object.
    [System.Serializable]
    public struct BobbingAnimation
    {
        public float offset; // The amount the object will move upwards
        public float speed;  // The speed of the movement
    }
    public BobbingAnimation bobbingAnimation = new BobbingAnimation
    {
        offset = 0.3f,
        speed = 2f
    };

    [Header("Bonuses")]
    public int experience;
    public int health;

    private float elapsedTime = 0f;

    protected virtual void Start()
    {
        initialPosition = transform.position;
    }

    protected virtual void Update()
    {
        elapsedTime += Time.deltaTime;

        // Calculate the fraction of lifespan that has passed
        float normalizedTime = elapsedTime / lifespan;

        // Move up in the first half of the lifespan, then move back down in the second half
        if (normalizedTime < 0.5f)
        {
            transform.position = Vector2.Lerp(initialPosition, initialPosition + Vector2.up * bobbingAnimation.offset, normalizedTime * 2);
        }
        else
        {
            transform.position = Vector2.Lerp(initialPosition + Vector2.up * bobbingAnimation.offset, initialPosition, (normalizedTime - 0.5f) * 2);
        }

        // Destroy the object once the lifespan is over
        if (elapsedTime >= lifespan)
        {
            Destroy(gameObject);
        }
    }
}