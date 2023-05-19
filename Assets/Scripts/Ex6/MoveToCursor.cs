using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToCursor : MonoBehaviour
{
    #region public var
    #endregion

    #region private var
    [SerializeField] private float moveSpeed;
    [SerializeField] private Vector3 mouseWorldPos;
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

    private void Update()
    {
        GetMousePos();
    }

    private void FixedUpdate()
    {
        MoveToMousePos();
    }

    private void GetMousePos()
    {
        mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void MoveToMousePos()
    {
        rb2d.MovePosition(mouseWorldPos);
    }
}
