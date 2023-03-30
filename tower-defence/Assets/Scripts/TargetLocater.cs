using System;
using UnityEngine;

public class TargetLocater : MonoBehaviour
{
    [SerializeField] private Transform TopMesh;
    [SerializeField] private float radius = 15f;
    [SerializeField] private ParticleSystem projectTileParticle;
    private Transform _target;

    private void Start()
    {
        _target = FindObjectOfType<EnemyMovement>().transform;
    }

    private void Update()
    {
        FindClosesTarget();
        AimWeapon();
    }

    private void FindClosesTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closestTarger = null;
        float maxDistance = Mathf.Infinity;

        foreach (var enemy in enemies)
        {
            var targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if (!(targetDistance < maxDistance))
                continue;
            closestTarger = enemy.transform;
        }
        _target = closestTarger;
    }

    private void AimWeapon()
    {
        var targetDistance = Vector3.Distance(_target.position, transform.position);
        TopMesh.LookAt(_target);
        Attack(targetDistance < radius);
    }

    private void Attack(bool isActive)
    {
        var emission = projectTileParticle.emission;
        emission.enabled = isActive;
    }
    
}
