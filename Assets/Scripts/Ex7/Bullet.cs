using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region public var
    #endregion

    #region private var
    [SerializeField] private float flySpeed;
    [SerializeField] private Rigidbody2D rb2d;
    #endregion

    private void Awake()
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
}
