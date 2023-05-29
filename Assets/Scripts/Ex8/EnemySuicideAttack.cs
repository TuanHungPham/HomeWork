using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySuicideAttack : MonoBehaviour
{
    #region public var
    #endregion

    #region private var
    [SerializeField] private int damage;
    [SerializeField] private DamageReceiver enemyDamageReceiver;
    [SerializeField] private Health enemyHealth;
    #endregion

    private void Awake()
    {
        LoadComponents();
    }

    private void Reset()
    {
        LoadComponents();
    }

    private void LoadComponents()
    {
        enemyDamageReceiver = GetComponent<DamageReceiver>();
        enemyHealth = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {

        if (!collider.CompareTag("Player")) return;

        DamageReceiver playerDamageReceiver = collider.GetComponent<DamageReceiver>();
        if (playerDamageReceiver == null) return;

        playerDamageReceiver.ReceiveDamage(damage);
        enemyDamageReceiver.ReceiveDamage(enemyHealth.MaxHP);
    }
}
