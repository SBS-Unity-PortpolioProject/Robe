using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFalling : MonoBehaviour
{
    [SerializeField] private GameObject obj;
    [SerializeField] private Vector2 spawnPosition;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(obj, spawnPosition, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
