using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectScaler : MonoBehaviour
{
    private Vector3 originalScale;
    private bool isScaledDown = false;

    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;

    }

    public void OnGreyButton()
    {
        if (isScaledDown)
        {
            // Return to original scale
            transform.localScale = originalScale;
            isScaledDown = false;
            Debug.Log("Scaled up to original size: " + originalScale);
        }
        else
        {
            // Scale down to 0.1x
            transform.localScale = originalScale * 0.1f;
            isScaledDown = true;
            Debug.Log("Scaled down to 0.1x: " + transform.localScale);
        }
    }

    
}
