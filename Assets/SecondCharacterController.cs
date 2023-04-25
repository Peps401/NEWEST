using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCharacterController : MonoBehaviour
{
    public float speed = 4.0f;
    public int health = 100;
    private int maxHealth = 100;

    public LevelController levelController;

    public HealthUiController healthBar;

    public GameOverController GameOverController;
    // Start is called before the first frame update
    void Awake()
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow)){
            this.transform.position += Vector3.up * speed * Time.deltaTime;
            //transform.position = new Vector3(transform.position.x, transform.position.y + speed*Time.deltaTime, transform.position.z);
        }
        if(Input.GetKey(KeyCode.DownArrow)){
            this.transform.position += Vector3.down * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.LeftArrow)){
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    public void Teleport(Vector3 newPosition){
        this.transform.position = newPosition;
    }

    public void LoseHealth(int healthToLose){
        health -= healthToLose;
        levelController.UpdateHealth(health);
        if(health == 0){
            GameOverController.Setup();
        }
    }
}
