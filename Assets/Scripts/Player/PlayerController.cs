using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    PlayerInput playerInput; 
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction attackAction;
    private InputAction interactAction;
    
    [SerializeField]
    Weapon weapon;

    private Rigidbody2D rigidBody2D;

    [SerializeField]
    float moveSpeed = 3f;
    
    
    

    void Awake() {
        playerInput = GetComponent<PlayerInput>();
        rigidBody2D = GetComponent<Rigidbody2D>();
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        attackAction = playerInput.actions["Attack"];
        interactAction = playerInput.actions["Interact"];
    }

    void Start(){

    }

    void OnEnable() {
        attackAction.performed += _ => Attack();
    }

    void OnDisable(){
        attackAction.performed -= _ => Attack();

    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        Move();
    }

    private void Move(){
        Vector2 input = moveAction.ReadValue<Vector2>();
        
        
        if(input.x>0.1f || input.x<-0.1f){
        rigidBody2D.AddForce(new Vector2(input.x * moveSpeed, 0f), ForceMode2D.Impulse);
        }
        

    }

    private void Attack(){
        Debug.Log($"{transform.name} attacked.");
        weapon.Attack();

    }



}
