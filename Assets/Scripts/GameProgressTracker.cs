using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressTracker: MonoBehaviour
{
    private static GameProgressTracker _instance;
    
    public static GameProgressTracker Instance {
        get {
            if(GameProgressTracker._instance !=null) {return _instance;}
            else {CreateProgressTracker(); return _instance;}
        }
        private set{
            _instance = value;
        }
        
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (_instance==null){
            Debug.LogWarning("reassigning GameProgTracker");
            Instance = this;
            return;
        } else {
            Destroy(gameObject, 1f);
        }
    }

    static void CreateProgressTracker(){
        GameObject newProgressTracker = new GameObject();
        newProgressTracker.AddComponent<GameProgressTracker>();

        _instance = newProgressTracker.GetComponent<GameProgressTracker>();
    }

    [SerializeField]
    List<LevelStatus> _levelStatuses;

    public void updateLevelStatus(int index, LevelStatus newStatus) {
        _levelStatuses[index] = newStatus;
    }

    public void updateDisplays(UIController controller){
        for(int i = 0; i<_levelStatuses.Count;i++){
            if(_levelStatuses[i] == LevelStatus.Completed){
                Debug.LogWarning("Completed");
                controller.updateLevelProgress(i, 1f);
            }
        }
    }

}

public enum LevelStatus{
    Incomplete,
    Inprogress,
    Completed
}

