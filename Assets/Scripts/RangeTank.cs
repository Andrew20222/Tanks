using UnityEngine;

public class RangeTank : ShootableTank
{
    [SerializeField] private float _distanceToPlayer = 5f;
    private Transform _target;
    private float _timer;

    protected override void Start()
    {
        base.Start();
        _target = FindObjectOfType<Player>().transform;
    }
    private void Update()
    {
        if (Vector2.Distance(transform.position, _target.position) > _distanceToPlayer) Move();
        SetAngle(_target.position);
        if (_timer <= 0)
        {
            Shoot();
            _timer = ReloadTime;
        }
        else _timer -= Time.deltaTime;
    }
}
