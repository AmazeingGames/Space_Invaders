using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed;

    float playerInput;

    new Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        playerInput = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(playerInput * playerSpeed * Time.fixedDeltaTime * 100, rigidbody2D.velocity.y);
    }
}
