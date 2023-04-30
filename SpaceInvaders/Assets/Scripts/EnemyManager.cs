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

    [SerializeField] Vector2 baseEnemySpeed;

    [SerializeField] int enemyRows;
    [SerializeField] int enemyCollumns;

    [SerializeField] float baseTickLength;

    List<Enemy> enemyList = new();
    float timer;

    [HideInInspector] public bool hasCollidedWithGameBounds;
    [HideInInspector] public bool hasUpdatedSpeed;

    // Start is called before the first frame update
    void Start()
    {
        if (baseEnemySpeed.y > 0)
            baseEnemySpeed *= -1;

        SpawnEnemies();

        enemyHolder = GameObject.Find("EnemyHolder").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasCollidedWithGameBounds)
        {
            UpdateEnemySpeed();
        }

        if (timer >= baseTickLength)
        {
            MoveEnemies();
            timer = 0;
        }
        timer += Time.deltaTime;
    }

    void MoveEnemies()
    {
        MoveEnemyHolder(baseEnemySpeed.x, 0);
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
        if (hasCollidedWithGameBounds == true && hasUpdatedSpeed == false)
        {
            Debug.Log("Collided & Updated with Game Bounds");

            baseEnemySpeed.x *= -1;
            MoveEnemyHolder(0, baseEnemySpeed.y);

            hasUpdatedSpeed = true;
        }
    }
}
