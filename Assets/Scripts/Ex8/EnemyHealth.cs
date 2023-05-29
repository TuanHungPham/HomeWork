using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : Health
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void Reset()
    {
        base.Reset();
    }

    protected override void LoadComponents()
    {
        InitializeHeatlhSystem();
    }

    private void InitializeHeatlhSystem()
    {
        MaxHP = 100;
        CurrentHP = MaxHP;
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void CheckHP()
    {
        base.CheckHP();
    }

    protected override void Die()
    {
        Instantiate(explosionVFX, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
