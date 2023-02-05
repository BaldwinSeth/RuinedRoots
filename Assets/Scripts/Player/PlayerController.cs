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
    [SerializeField] 
    List<Transform> terrainObjectsInRange;

    private Rigidbody2D rigidBody2D;

    [SerializeField]
    float moveSpeed = 3f;
    [SerializeField]
    float jumpHeight = 20f;

    public bool isGrounded {
        get {return terrainObjectsInRange.Count>0;}
        private set {}
    }
    
    
    

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
        jumpAction.performed += _ => Jump();
        terrainObjectsInRange = new List<Transform>();
    }

    void OnDisable(){
        attackAction.performed -= _ => Attack();
        jumpAction.performed -= _ => Jump();
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

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.tag == "Terrain"){
            terrainObjectsInRange.Add(other.transform);
        }
        
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(terrainObjectsInRange.Contains(other.transform)){
            terrainObjectsInRange.Remove(other.transform);
        }
    }



    private void Jump(){
        Debug.Log("I'm jumping");
        if(isGrounded) rigidBody2D.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
    }

    private void Attack(){
        Debug.Log($"{transform.name} attacked.");
        weapon.Attack();

    }
}
