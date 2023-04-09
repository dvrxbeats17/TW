using UnityEngine;


[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHitPoints = 5;
    [SerializeField] private int healthRamp = 1;
    private int currentHitPoints;
    private Enemy _enemy;
    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }
    private void OnEnable()
    {
        currentHitPoints = maxHitPoints;
    }
    private void OnParticleCollision(GameObject other)
    {
        ProceessHit();
    }
    private void ProceessHit()
    {
        currentHitPoints--;
        if (currentHitPoints <= 0)
        {
            _enemy.RewardGold();
            maxHitPoints += healthRamp;
            gameObject.SetActive(false);
        }
    }
}
