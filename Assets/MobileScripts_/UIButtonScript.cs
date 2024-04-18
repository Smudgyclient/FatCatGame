using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonScript : MonoBehaviour
{
    // Method to toggle the active state of the attached GameObject
    public void ToggleGameObject()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    // Method to enable the attached GameObject
    public void EnableGameObject()
    {
        gameObject.SetActive(true);
    }

    // Method to disable the attached GameObject
    public void DisableGameObject()
    {
        gameObject.SetActive(false);
    }

    public void SetGameObjectActive()
    {
        gameObject.SetActive(!gameObject.activeSelf);
    }
}