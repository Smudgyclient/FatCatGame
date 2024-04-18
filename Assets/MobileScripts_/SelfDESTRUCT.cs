using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDESTRUCT : MonoBehaviour
{
    private void OnDisable()
    {
        // Check if the GameObject is being deactivated and is not already marked for destruction
        if (!gameObject.activeSelf && !IsMarkedForDestroy())
        {
            // Mark the GameObject for destruction
            MarkForDestroy();
            // Delay destruction to the end of the frame to avoid potential issues with object iteration
            Destroy(gameObject, 0f);
        }
    }

    // Method to mark the GameObject for destruction
    private void MarkForDestroy()
    {
        // Add a component to mark the GameObject for destruction
        gameObject.AddComponent<SelfDestructMarker>();
    }

    // Method to check if the GameObject is already marked for destruction
    private bool IsMarkedForDestroy()
    {
        return GetComponent<SelfDestructMarker>() != null;
    }
}

// Helper class to mark the GameObject for destruction
public class SelfDestructMarker : MonoBehaviour { }