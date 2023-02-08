using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNtoUnload : MonoBehaviour
{
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

  
}
