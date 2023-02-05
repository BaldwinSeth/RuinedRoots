using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressDisplay : MonoBehaviour
{
    [SerializeField]
    List<RadialProgressIndicator> progressIndicators;

    void Awake(){
        if(progressIndicators == null){
            progressIndicators = new List<RadialProgressIndicator>();
        }
    }
    
}
