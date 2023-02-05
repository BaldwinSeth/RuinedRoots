using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
    [SerializeField]
    List<RadialProgressIndicator> indicators;

    void Awake() {
        collectIndicators();
    }

    private void collectIndicators(){
        RadialProgressIndicator[] foundIndicators = GetComponentsInChildren<RadialProgressIndicator>();
        indicators.AddRange(foundIndicators);
        indicators.Sort(
            delegate(RadialProgressIndicator RPI1, RadialProgressIndicator RPI2){
                return RPI1.LevelIndex.CompareTo(RPI2.LevelIndex);
            }
        );
    }

    public void updateLevelProgress(int index, float progress){
        indicators[index].progress = progress;
    }
}
