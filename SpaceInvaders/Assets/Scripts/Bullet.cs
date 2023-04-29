
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;


    new Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(0, speed * Time.deltaTime * 100);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GameBoundTag") || collision.gameObject.CompareTag("EnemyTag"))
        {
            gameObject.SetActive(false);
        }
    }
}
