using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField]
    bool levelIsExitable = false;

    [SerializeField]
    int levelIndex = -1;



    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            Debug.Log("player tried to leave");
            if(levelIsExitable){
                leaveLevel();
            }
        }
    }

    void leaveLevel(){
        //leave the level
        Debug.LogWarning("Player is Leaving!");
        gameObject.SetActive(false);
        GameProgressTracker.Instance.updateLevelStatus(levelIndex, LevelStatus.Completed);
        SceneManager.LoadScene(levelIndex+1);
    }

    public void SetReadyToLeave(){
        levelIsExitable = true;
    }

    public void setLevelIndex(int value){
        levelIndex = value;
    }


}
