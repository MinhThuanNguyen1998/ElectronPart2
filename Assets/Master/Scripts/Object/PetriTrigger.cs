using UnityEngine;

public class PetriTrigger : MonoBehaviour
{
    [SerializeField] StepSolid m_StepSolid;
    [SerializeField] GameObject m_ParentPetri;
    [SerializeField] GameObject m_EmptyParent;
    [SerializeField] GameObject m_CyclinderPetri;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Solid"))
        {
            
            m_StepSolid = other.GetComponent<StepSolid>();
            float otherY = other.transform.position.y;
            float thisY = transform.position.y;
            if (otherY < thisY) m_CyclinderPetri.SetActive(false);
            else 
            {
                m_CyclinderPetri.SetActive(true);
                m_StepSolid.GoToNextStep();
                MagnifyingManager.Instance.ActiveMagnifyingObject(true);
                other.transform.SetParent(m_ParentPetri.transform);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Solid"))
        {
            m_StepSolid = other.GetComponent<StepSolid>();
            m_StepSolid.GoToPrevStep();
            MagnifyingManager.Instance.ActiveMagnifyingObject(false);
            other.transform.SetParent(m_EmptyParent.transform);
        }
    }
}
