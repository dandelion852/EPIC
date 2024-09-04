using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform worldRoot;
    private Vector3 originalWorldScale;
    private bool isScaledDown = false;
    private const float scaleFactor = 10f;


    // Start is called before the first frame update
    void Start()
    {
        originalWorldScale = worldRoot.localScale;
    }
  
    public void OnGreyButton()
        {
            if (isScaledDown)
            {
                // Return to original scale
                worldRoot.localScale = originalWorldScale;
                isScaledDown = false;
                Debug.Log("Scaled up to original size: " + originalWorldScale);
            }
            else
            {
                // Scale down
                worldRoot.localScale = originalWorldScale * scaleFactor;
                isScaledDown = true;
                Debug.Log("Scaled down to " + scaleFactor + "x: " + worldRoot.localScale);
            }
        }
}
