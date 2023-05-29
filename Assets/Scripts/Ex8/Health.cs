using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    #region public var
    public int CurrentHP { get => currentHP; set => currentHP = value; }
    public int MaxHP { get => maxHP; set => maxHP = value; }
    #endregion

    #region protected var
    [SerializeField] protected int currentHP;
    [SerializeField] protected int maxHP;
    [SerializeField] protected bool isDead;
    [SerializeField] protected GameObject explosionVFX;
    #endregion

    protected virtual void Awake()
    {
        LoadComponents();
    }

    protected virtual void Reset()
    {
        LoadComponents();
    }

    protected abstract void LoadComponents();

    protected virtual void Update()
    {
        CheckHP();
    }

    protected virtual void CheckHP()
    {
        if (CurrentHP > 0) return;

        CurrentHP = 0;
        Die();
    }

    protected abstract void Die();
}
