using UnityEngine;

public class PetriTrigger : MonoBehaviour
{
    [SerializeField] StepSolid m_StepSolid;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Solid"))
        {
            m_StepSolid = other.GetComponent<StepSolid>();
            m_StepSolid.GoToNextStep();
            MagnifyingManager.Instance.ActiveMagnifyingObject(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Solid"))
        {
            m_StepSolid = other.GetComponent<StepSolid>();
            m_StepSolid.GoToPrevStep();
            MagnifyingManager.Instance.ActiveMagnifyingObject(false);
        }
    }
    
}
