using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 4.0f;
    public int health = 100;
    public int maxHealth = 100;

    private LevelController levelController;

    public bool movementAllowed = false;

    private new Rigidbody2D rigidbody2D;

    private Vector2 currentMoveDirection = new Vector2(0.0f, 0.0f);

    public void InitializeController(LevelController levelController, bool initMovementAllowed){
        this.levelController = levelController;
        movementAllowed = initMovementAllowed;
        rigidbody2D = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (movementAllowed)
        {
            Vector2 moveDirection = new Vector2(0.0f, 0.0f);
            if (Input.GetKey(KeyCode.D))
            {
                moveDirection = new Vector2(1.0f, moveDirection.y);
            }
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = new Vector2(-1.0f, moveDirection.y);
            }
            if (Input.GetKey(KeyCode.S))
            {
                moveDirection = new Vector2(moveDirection.x, -1.0f);
            }
            if (Input.GetKey(KeyCode.W))
            {
                moveDirection = new Vector2(moveDirection.x, 1.0f);
            }

            if (moveDirection != currentMoveDirection)
            {
                currentMoveDirection = moveDirection;
                rigidbody2D.velocity = moveDirection;
            }
        }
    }

    public void Teleport(Vector3 newPosition)
    {
        this.transform.position = newPosition;
    }

    public void LoseHealth(int healthToLose)
    {
        health -= healthToLose;
        levelController.UpdateHealth(health);
    }
}
