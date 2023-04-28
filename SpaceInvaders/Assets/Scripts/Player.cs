using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] Bullet bulletObject;

    float horizontalInput;
    bool shouldShoot;

    Bullet bulletInstance;

    new Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        bulletInstance = Instantiate(bulletObject);

        bulletInstance.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        shouldShoot = Input.GetButtonDown("Fire1");

        if (shouldShoot)
        {
            Shoot();
        }
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(horizontalInput * playerSpeed * Time.deltaTime * 100, rigidbody2D.velocity.y);
    }

    void Shoot()
    {

        if (!bulletInstance.isActiveAndEnabled)
        {
            Debug.Log("Player Fired");

            bulletInstance.gameObject.SetActive(true);

            bulletInstance.transform.position = transform.position;
        }
    }
}
