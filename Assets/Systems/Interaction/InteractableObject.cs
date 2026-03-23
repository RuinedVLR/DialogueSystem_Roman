using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    // Use this bool in the inspector to enable or disable debug messages in the console.
    public bool debugEnabled = false;




    public void Interact()
    {
        if (debugEnabled) Debug.Log("Interacted with " + gameObject.name);
    }


    public void Focused()
    {
        
    }



    public void UnFocused()
    {
       
    }
}
