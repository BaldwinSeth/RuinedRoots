using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class McGuffin : MonoBehaviour {
    public bool isFound{
        get {return isFound;}
        private set{ isFound = value;}
    }

    LevelProgressTracker levelProgressTracker;

    void Awake(){
        levelProgressTracker = GetComponentInParent<LevelProgressTracker>();
        if(levelProgressTracker == null) {
            Debug.LogError($"{transform.name} has the wrong parent.");
            Destroy(gameObject, 1f);
        }
    }
    
    void OnTriggerEnter2D(Collider2D other){
        if(other.tag=="Player"){
            Collect();
        }
    }
    
    private void Collect() {
        levelProgressTracker.updateCollection(this);
        Debug.Log("I was found!");
    }
}
