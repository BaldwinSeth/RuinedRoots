using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {
    [SerializeField]
    List<RadialProgressIndicator> indicators;

    void Awake() {
        RadialProgressIndicator[] foundIndicators = GetComponentsInChildren<RadialProgressIndicator>();
        indicators.AddRange(foundIndicators);
        indicators.Sort(
            delegate(RadialProgressIndicator RPI1, RadialProgressIndicator RPI2){
                return RPI1.LevelIndex.CompareTo(RPI2.LevelIndex);
            }
        );

    }
}
