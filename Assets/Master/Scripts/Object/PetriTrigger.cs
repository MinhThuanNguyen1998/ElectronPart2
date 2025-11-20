using UnityEngine;

public class PetriTrigger : MonoBehaviour
{
    [SerializeField] StepSolid m_StepSolid;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Solid"))
        {
            m_StepSolid?.GoToNextStep();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Solid"))
        {
            m_StepSolid?.GoToPrevStep();
        }
    }
}
