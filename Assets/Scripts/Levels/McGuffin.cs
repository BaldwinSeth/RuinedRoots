using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class McGuffin : MonoBehaviour {
    
    private bool _isFound = false;
    public bool isFound{
        get {return _isFound;}
        private set{ _isFound = value;}
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
        if(DebuggingStatus.isDebuggingMcGuffins) {
            Debug.Log($"{name} collided with {other.name}");
        }
        if(other.tag=="Player"){
            Collect();
        }
    }
    
    private void Collect() {
        levelProgressTracker.updateMcGuffinCollection(this);
        isFound = true;
        
    }
}
