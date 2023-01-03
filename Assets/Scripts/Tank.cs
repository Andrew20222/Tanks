using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class Tank : MonoBehaviour
{
    [Header("Характеристики")]
    [Range(10,50)]
    [SerializeField] private int _maxHealth;
    [Range(0f,5f)]
    [SerializeField] protected float MovementSpeed;
    [SerializeField] protected float AngleOffset = 90f;
    [Tooltip("Швидкість повороту")]
    [SerializeField] protected float RotationSpeed = 7f;
    [SerializeField] private int _points = 0;
    protected UI UI;
    protected int _currentHealth;
    protected Rigidbody2D Rigidbody;

    public virtual void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
            Stats.Score += _points;
            UI.UpdateLevelAndScore();
        }
    }

    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
        Rigidbody = GetComponent<Rigidbody2D>();
        UI = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
    }

    protected void SetAngle(Vector3 target)
    {
        Vector3 deltaPosition = target - transform.position;
        float angleZ = Mathf.Atan2(deltaPosition.y, deltaPosition.x) * Mathf.Rad2Deg;
        Quaternion angle = Quaternion.Euler(0f, 0f, angleZ + AngleOffset);
        transform.rotation = Quaternion.Lerp(transform.rotation, angle, Time.deltaTime * RotationSpeed);
    }

    protected virtual void Move()
    {
        transform.Translate(Vector3.down * MovementSpeed * Time.deltaTime);
    }
}
