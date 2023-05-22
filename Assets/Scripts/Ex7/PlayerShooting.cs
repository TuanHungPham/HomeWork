using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    #region public var
    #endregion

    #region private var
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootingDelay;
    [SerializeField] private float shootingTimer;
    [SerializeField] private bool isShootingDelay;
    #endregion

    private void Awake()
    {
        shootingDelay = 0.5f;
        shootingTimer = shootingDelay;
    }

    private void Update()
    {
        CheckShootingDelay();
        Shoot();
    }

    private void CheckShootingDelay()
    {
        if (shootingTimer <= 0)
        {
            isShootingDelay = false;
            return;
        }

        isShootingDelay = true;
        shootingTimer -= Time.deltaTime;
    }

    private void Shoot()
    {
        if (!CanShoot()) return;

        CreateBullet();
        shootingTimer = shootingDelay;
        Debug.Log("Shooting...");
    }

    private void CreateBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab);
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation;
    }

    private bool CanShoot()
    {
        if (isShootingDelay || !InputManager.Instance.IsShootingInput)
        {
            return false;
        }

        return true;
    }
}
