using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageReceiver : MonoBehaviour
{
    #region public var
    #endregion

    #region private var
    [SerializeField] private Health objHealth;
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
        objHealth = GetComponent<Health>();
    }

    public void ReceiveDamage(int damage)
    {
        objHealth.CurrentHP -= damage;
    }
}
