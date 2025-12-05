using UnityEngine;

public class PetriBottomTrigger : MonoBehaviour
{
    public bool IsTriggeredFromBottom { get; private set; }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Solid"))
        {
            IsTriggeredFromBottom = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Solid"))
        {
            IsTriggeredFromBottom = false;
        }
    }
}
