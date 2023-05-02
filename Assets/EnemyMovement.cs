using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyMovement : MonoBehaviour
{

    public UnityEvent<Vector2> OnMovementInput, OnPointerInput;
    public UnityEvent OnAttack;
    private Transform player;

    private float chaseDistance = 3;
    private float attackDistance = 0.8f;

    private float attackDelay = 1;
    private float passedTime = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if its unll player is dead
        if(player == null){
            return;
        }

        //distance between enemy and player
        float distance = Vector2.Distance(player.position, transform.position);
        if(distance < chaseDistance){
            //start chasing player
            //char is always looking and pointing the weapon 
            //at the pointer of our mouse
            OnPointerInput?.Invoke(player.position);
            if(distance <= attackDistance){
                //attack behaviour
                // we dont wanna move if we are close to charachter
                OnMovementInput?.Invoke(Vector2.zero);
                if(passedTime >= attackDelay){
                    //waiting 1sec before attacking again
                    passedTime = 0;
                    OnAttack?.Invoke();
                }
            }else{
                //chasing the player
                //if too far away from player move closer 
                Vector2 direction = player.position - transform.position;
                OnMovementInput?.Invoke(direction.normalized);
            }
        }
        if(passedTime < attackDelay){
            passedTime += Time.deltaTime;
        }
    }
}
