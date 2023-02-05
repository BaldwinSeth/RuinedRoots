using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressTracker : MonoBehaviour {
    

    [SerializeField]
    List<McGuffin> mcGuffins;

    [SerializeField]
    List<RadialProgressIndicator> progressIndicators;

    private float progress;

    [SerializeField]
    Slider slider;
    
    bool allAreFound = true;

    void Start() {
        foreach(RadialProgressIndicator mg in progressIndicators){
            if (mg == null) progressIndicators.Remove(mg);
        }
        foreach(McGuffin mg in mcGuffins){
            if (mg == null) mcGuffins.Remove(mg);
        }

    }

    public void updateMcGuffinCollection(McGuffin mcGuffin){
        if(DebuggingStatus.isDebugging){
            Debug.Log($"{mcGuffin.name} updated.");
        }
        float foundMcGuffinCount = mcGuffins.Count + 1f;
        foreach(McGuffin mg in mcGuffins){
            if(mg.isFound){
                allAreFound = false;
                foundMcGuffinCount -= 1f;
            }
        }

        progress = foundMcGuffinCount/mcGuffins.Count;

        checkCompletion(allAreFound);
    }

    void checkCompletion(bool allAreFound){
        Debug.LogWarning($"All are found: {allAreFound}");
    }

}


