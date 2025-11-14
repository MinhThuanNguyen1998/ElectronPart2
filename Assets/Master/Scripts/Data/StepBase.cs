using UnityEngine;
using UnityEngine.Rendering;

public abstract class StepBase : MonoBehaviour
{
    public int TotalSteps { get; protected set; }
    public int CurretSteps { get; protected set; }

    public virtual void StartStep()
    {
        CurretSteps = 0;
    }
    protected void NextStep()
    {
        CurretSteps++;
        if(CurretSteps <= TotalSteps)
        {
            ExecuteCurrentStep();
        }
        else
        {
            OnAllStepCompleted();
        }
    }

    protected abstract void ExecuteCurrentStep();
    
    protected virtual void OnAllStepCompleted()
    {

    }
}
