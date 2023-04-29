using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] Transform enemyHolder;

    [SerializeField] Vector2 positionOffset;

    [SerializeField] Vector2 enemySpeed;

    [SerializeField] int enemyRows;
    [SerializeField] int enemyCollumns;

    List<Enemy> enemyList = new();

    [HideInInspector] public bool collidedWithGameBounds;
    [HideInInspector] public bool updatedSpeed;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();

        enemyHolder = GameObject.Find("EnemyHolder").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemyHolder(enemySpeed.x, 0);

        if (collidedWithGameBounds)
        {
            UpdateEnemySpeed();
        }
    }

    void MoveEnemyHolder(float horizontalMovement, float verticalMovement)
    {
        enemyHolder.transform.position += new Vector3(horizontalMovement, verticalMovement);
    }

    void SpawnEnemies()
    {
        for (int y = 0; y < enemyRows; y++)
        {
            for (int x = 0; x < enemyCollumns; x++)
            {
                var currentEnemy = Instantiate(enemy, enemyHolder, false);

                Vector2 currentOffset = new Vector2(positionOffset.x * x, positionOffset.y * y);

                currentEnemy.transform.position += (Vector3)currentOffset;

                currentEnemy.manager = this;

                enemyList.Add(currentEnemy);
            }
        }
    }

    public void UpdateEnemySpeed()
    {
        Debug.Log($"CollidedWithGameBounds : {collidedWithGameBounds}");

        if (collidedWithGameBounds == true && updatedSpeed == false)
        {
            Debug.Log("Collided & Updated with Game Bounds");
            enemySpeed.x *= -1;

            MoveEnemyHolder(0, enemySpeed.y);
        }
    }
}
