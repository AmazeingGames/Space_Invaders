using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector] public EnemyManager manager;

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
            manager.hasUpdatedSpeed = false;
            manager.hasCollidedWithGameBounds = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GameBoundTag"))
        {
            manager.hasUpdatedSpeed = true;
            manager.hasCollidedWithGameBounds = false;
        }
    }
}
