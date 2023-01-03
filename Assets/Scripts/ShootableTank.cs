using UnityEngine;

public abstract class ShootableTank : Tank
{
    [Header("Стрильба")]
    [SerializeField] private GameObject _projectile;
    [SerializeField] private string _projectileTag;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] protected float ReloadTime = 0.5f;
    private ObjectPooler _objectPooler;

    protected override void Start()
    {
        base.Start();
        _objectPooler = ObjectPooler.Instance;
    }

    protected void Shoot()
    {
        _objectPooler.SpawnFromPool(_projectileTag, _shootPoint.position, transform.rotation);
    }
}
