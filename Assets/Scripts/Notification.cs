using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notification : MonoBehaviour
{
    #region public var
    public string test;
    #endregion

    #region private var
    [SerializeField] private PlayerHealth playerHealth;
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
        playerHealth = GameObject.Find("MainCharacter").GetComponent<PlayerHealth>();
    }

    private void Start()
    {
        playerHealth.onPlayerDeath += OnGameOver;
        playerHealth.onPlayerDeath2 += OnTest;
    }

    public void OnGameOver()
    {
        Debug.Log("Game Over...");
    }

    public void OnTest(string test)
    {
        Debug.Log("Game Over " + test + " .......");
    }
}
