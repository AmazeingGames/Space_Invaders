using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public EnemyManager manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Die()
    {
        Debug.Log("Enemy died");

        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletTag"))
        {
            Die();
        }

        if (collision.gameObject.CompareTag("GameBoundTag"))
        {
            manager.updatedSpeed = false;
            manager.collidedWithGameBounds = true;

            Debug.Log($"Set manager.CollidedWithGameBounds : {manager.collidedWithGameBounds}");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GameBoundTag"))
        {
            manager.updatedSpeed = true;
            manager.collidedWithGameBounds = false;

            Debug.Log($"Set manager.CollidedWithGameBounds : {manager.collidedWithGameBounds}");
        }
    }
}
