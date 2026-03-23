using UnityEngine;

public class Interactable_Pickup : MonoBehaviour, IInteractable
{
    // Use this bool in the inspector to enable or disable debug messages in the console.
    public bool debugEnabled = false;




    public void Interact()
    {
        if (debugEnabled) Debug.Log("Interacted with " + gameObject.name);

        // add logic to add item to inventory
        Destroy(gameObject);
    }


    public void Focused()
    {
       
    }

    public void UnFocused()
    {
    }
}
