using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressTracker : MonoBehaviour {
    

    [SerializeField]
    List<McGuffin> mcGuffins;

    [SerializeField]
    RadialProgressIndicator progressIndicator;

    [SerializeField]
    int LevelIndex = -1;

    private float progress;
    
    private bool _levelReadyToComplete = false;

    public bool LevelIsReadyToComplete{
        get { return _levelReadyToComplete;}
    }

    [SerializeField]
    Slider slider;
    
    bool allAreFound = true;

    void Start() {
        
        foreach(McGuffin mg in mcGuffins){
            if (mg == null) mcGuffins.Remove(mg);
        }

        ProgressTracker.Instance.updateLevelStats(LevelIndex, LevelStatus.Inprogress);

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

        progressIndicator.progress = progress;

        checkCompletion(allAreFound);
    }

    void checkCompletion(bool allAreFound){
        Debug.LogWarning($"All are found: {allAreFound}");
        if(allAreFound){
            _levelReadyToComplete = true;
        }
    }

    

}


