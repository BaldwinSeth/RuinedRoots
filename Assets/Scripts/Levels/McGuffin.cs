using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Collider2D))]
public class McGuffin : MonoBehaviour {
    
    [SerializeField]
    private bool _isFound = false;
    public bool isFound{
        get {return _isFound;}
        private set{ 
            _isFound = value;
            setImageToCollected();
            }
    }

    [SerializeField]
    SpriteRenderer unCollectedSprite;

    [SerializeField]
    SpriteRenderer collectedSprite;

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
        isFound = true;      
        levelProgressTracker.updateMcGuffinCollection();  
    }

    private void setImageToCollected(){
        collectedSprite.gameObject.SetActive(false);
        unCollectedSprite.gameObject.SetActive(true);
    }
}
