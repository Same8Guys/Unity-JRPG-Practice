using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class Teleporter : MonoBehaviour
{
    private Collider2D sensor;
    public string destinationScene;
    public float x, y;
    public string destinationLayer;

    void Awake()
    {
        sensor = GetComponent<Collider2D>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        GameManager gameManager = GameManager.Instance;
    }
}
