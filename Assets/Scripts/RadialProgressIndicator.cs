using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialProgressIndicator : MonoBehaviour
{
    [SerializeField]
    Image image;

    [SerializeField]
    private float m_progress = 0;
    public float progress {
        get {return m_progress;}
        set {
            m_progress = value;
            image.fillAmount = value;
        }
    }

    [SerializeField]
    int _levelIndex = -1;

    public int LevelIndex{
        get {return _levelIndex;}
    }

    private void Awake() {
        Debug.Assert(image !=null);
        image.fillAmount = progress;
        Debug.Assert(LevelIndex!=-1);
    }
}
