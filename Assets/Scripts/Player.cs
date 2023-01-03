﻿using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : ShootableTank
{
    private float _timer;
    public override void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        UI.UpdateHealth(_currentHealth);
        if(_currentHealth <= 0)
        {
            Stats.ResetAllStats();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Destroy(gameObject);
        }
    }
    protected override void Move()
    {
        transform.Translate(Vector3.down * Input.GetAxis("Vertical") * MovementSpeed * Time.deltaTime);
    }
    private void Update()
    {
        Move();
        SetAngle(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (_timer <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
                _timer = ReloadTime;
            }
        }
        else _timer -= Time.deltaTime;
    }
}
