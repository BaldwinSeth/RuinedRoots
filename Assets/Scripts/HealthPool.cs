using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPool : MonoBehaviour
{
    [SerializeField]
    int health = 3;

    public bool isDead{
        get {return health>0;}
    }
    public int getHealth(){
        return health;
    }

    public void DealDamage(){
        if(health>0) {health-=1;}
        if(DebuggingStatus.isDebugging){
            Debug.Log($"Damage Delt, current health is {health}. currently dead: {isDead}");
        } 
        
    }
}
