using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressTracker : MonoBehaviour {
    

    [SerializeField]
    List<McGuffin> mcGuffins;

    private float progress;

    [SerializeField]
    Slider slider;
    
    bool allAreFound = true;

    void Awake() {

    }
    public void updateCollection(McGuffin mcGuffin){
        float foundMcGuffinCount = mcGuffins.Count + 1f;
        foreach(McGuffin mg in mcGuffins){
            if(mg.isFound){
                allAreFound = false;
                foundMcGuffinCount -= 1f;
            }
        }

        progress = foundMcGuffinCount/mcGuffins.Count;
        slider.value = progress;

    }

}


