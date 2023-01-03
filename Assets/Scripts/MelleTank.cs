using UnityEngine;
public class MelleTank : Tank
{
    [SerializeField] private int _damage;
    private Transform _target;
    private float _timer;
    private float _hitCoolDown = 1f;

    protected override void Start()
    {
        base.Start();
        _target = FindObjectOfType<Player>().transform;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Player>() != null && _timer <= 0)
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(_damage);
            _timer = _hitCoolDown;
        }
    }

    private void Update()
    {
        if(_target != null)
        {
            if (_timer <= 0)
            {
                Move();
                SetAngle(_target.position);
            }
            else _timer -= Time.deltaTime;
        } 
    }
}
