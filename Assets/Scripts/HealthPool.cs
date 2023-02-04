using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPool : MonoBehaviour
{
    [SerializeField]
    int health = 3;

    public int getHealth(){
        return health;
    }

    public void dealDamage(){
        if(health>0) {health-=1;}
    }

    public bool isDead(){
        return health>0;
    }
}
