using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressTracker: MonoBehaviour
{
    private static GameProgressTracker _instance;
    
    public static GameProgressTracker Instance {
        get {
            if(_instance !=null) {return _instance;}
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
            Instance = this;
            return;
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

}

public enum LevelStatus{
    Incomplete,
    Inprogress,
    Completed
}

