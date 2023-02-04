using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Weapon : MonoBehaviour
{
    BoxCollider2D attackRange;

    private bool enemyIsInRange;

    void Awake() {
        attackRange = GetComponent<BoxCollider2D>();
    }

    void onEnable(){
        Debug.Log($"{transform.name}enabled");
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other == GetComponentInParent<Transform>()) {
            Debug.Log("hit parent");
            return;
        }
        if (other.transform.tag == "Enemy"){
            enemyIsInRange=true;
        }
        Debug.Log($"enemy in range: {enemyIsInRange}");
    }

    private void OnTriggerExit2D(Collider2D other){
        if (other.transform.tag == "Enemy"){
            enemyIsInRange=false;
        }
        Debug.Log($"enemy in  not range: {!enemyIsInRange}");

    }

    bool EnemyIsInRange(){
        return enemyIsInRange;
    }
}
