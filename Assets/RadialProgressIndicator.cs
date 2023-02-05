using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Image))]
public class RadialProgressIndicator : MonoBehaviour
{
    Image image;
    
    private float m_progress = 0;
    public float progress {
        get {return m_progress;}
        set {
            m_progress = value;
            image.fillAmount = value;
        }
    }

    private void Awake() {
        image = GetComponentInParent<Image>();
    }
}
