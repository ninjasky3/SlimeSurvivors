using UnityEngine;


[CreateAssetMenu(fileName = "Character Data", menuName = "Player/Character Data")]
public class CharacterData : ScriptableObject
{
    [SerializeField]
    Sprite icon;
    public Sprite Icon { get => icon;  set => icon = value; }

    [SerializeField]
    RuntimeAnimatorController characterAnimator;
    public RuntimeAnimatorController CharacterAnimator { get => characterAnimator;  set => characterAnimator = value; }

    [SerializeField]
    Sprite characterSprite;
    public Sprite CharacterSprite { get => characterSprite;  set => characterSprite = value; }

    [SerializeField]
    Sprite characterImage;
    public Sprite CharacterImage { get => characterImage;  set => characterImage = value; }

    [SerializeField]
    new string name;
    public string Name { get => name;  set => name = value; }

    [SerializeField]
    WeaponData startingWeapon;
    public WeaponData StartingWeapon { get => startingWeapon;  set => startingWeapon = value; }

    // Struct representing various stats for a character in the game.
    [System.Serializable]
    public struct Stats
    {
        public float maxHealth, recovery, armor;
        [Range(-1, 10)] public float moveSpeed, might, area;
        [Range(-1, 5)] public float speed, duration;
        [Range(-1, 10)] public int amount;
        [Range(-1, 1)] public float cooldown;
        [Min(-1)] public float luck, growth, greed, curse;
        public float magnet;
        public int revival;
        //private int maxLevel = 10;

        // Overloaded + operator to combine two Stats objects.
        public static Stats operator +(Stats s1, Stats s2)
        {
            s1.maxHealth += s2.maxHealth;
            s1.recovery += s2.recovery;
            s1.armor += s2.armor;
            s1.moveSpeed += s2.moveSpeed;
            s1.might += s2.might;
            s1.area += s2.area;
            s1.speed += s2.speed;
            s1.duration += s2.duration;
            s1.amount += s2.amount;
            s1.cooldown += s2.cooldown;
            s1.luck += s2.luck;
            s1.growth += s2.growth;
            s1.greed += s2.greed;
            s1.curse += s2.curse;
            s1.magnet += s2.magnet;
            return s1;
        }
    }

    // Default initialization of a Stats object with preset values.
    public Stats stats = new Stats
    {
        maxHealth = 100, moveSpeed = 1, might = 1, amount = 0,
        area = 1, speed = 1, duration = 1, cooldown = 1,
        luck = 1, greed = 1, growth = 1, curse = 1,
    };
}