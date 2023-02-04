using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Weapon : MonoBehaviour
{
    BoxCollider2D attackRange;

    public bool isInRange {
        get {return healthPoolsInRange.Count>0;}
        private set {}
    }

    private List<HealthPool> healthPoolsInRange;

    void Awake() {
        attackRange = GetComponent<BoxCollider2D>();
        healthPoolsInRange = new List<HealthPool>();
    }

    void onEnable(){
        Debug.Log($"{transform.name}enabled");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        
        if (other.transform.tag == "Enemy"){
            healthPoolsInRange.Add(other.GetComponent<HealthPool>());
        }
        Debug.Log($"{other.name} in range");
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.transform.tag == "Enemy"){
            healthPoolsInRange.Remove(other.GetComponent<HealthPool>());
        }
        Debug.Log($"{other.name} no longer in range");
    }
    
    public void Attack(){
        foreach(HealthPool hp in healthPoolsInRange){
            hp.DealDamage();
        }
    }
}
