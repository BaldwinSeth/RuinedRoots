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
    LevelExit levelExit;

    [SerializeField]
    int levelIndex = -1;

    [SerializeField]
    UIController uIController;

    [SerializeField]
    private float progress;
    
    [SerializeField]
    private bool _levelReadyToComplete = false;


    public bool LevelIsReadyToComplete{
        get { return _levelReadyToComplete;}
    }

    [SerializeField]
    Slider slider;

    void Start() {

        GameProgressTracker.Instance.updateLevelStatus(levelIndex, LevelStatus.Inprogress);
        levelExit = GetComponentInChildren<LevelExit>();
        levelExit.setLevelIndex(levelIndex);
        uIController = FindFirstObjectByType<UIController>();

    }

    private void OnEnable(){
        refreshMcGuffins();
    }

    private void refreshMcGuffins(){
        List<McGuffin> newMcGuffinList = new List<McGuffin>();
        McGuffin[] foundMcGuffins = GetComponentsInChildren<McGuffin>();
        Debug.LogWarning($"McGuffin Count: {foundMcGuffins.Length}");
        newMcGuffinList.AddRange(foundMcGuffins);
        mcGuffins = newMcGuffinList;
    }

    public void updateMcGuffinCollection(){

        float foundMcGuffinCount = mcGuffins.Count;
        bool anyStillNotFound = false;
        foreach(McGuffin mg in mcGuffins){
            if(!mg.isFound){
                anyStillNotFound = true;
                foundMcGuffinCount -= 1f;
            }
        }

        progress = foundMcGuffinCount/mcGuffins.Count;
        uIController.updateLevelProgress(levelIndex, progress);

        if(!anyStillNotFound){
            _levelReadyToComplete = !anyStillNotFound;
            levelExit.SetReadyToLeave();
        }
        

    }

    
    

}


