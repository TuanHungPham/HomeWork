using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region public var
    #endregion

    #region private var
    [SerializeField] private int bulletDmg;
    [SerializeField] private float flySpeed;
    [SerializeField] private Rigidbody2D rb2d;
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
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Fly();
    }

    private void Fly()
    {
        rb2d.MovePosition(transform.position + transform.up * flySpeed * Time.fixedDeltaTime);

        Destroy(this.gameObject, 2f);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (!collider.CompareTag("Enemy")) return;

        Debug.Log("Hit " + collider.name + " with " + bulletDmg + " Damage!");

        DamageReceiver damageReceiver = collider.GetComponent<DamageReceiver>();
        if (damageReceiver == null) return;
        damageReceiver.ReceiveDamage(bulletDmg);

        Destroy(this.gameObject);
    }
}
