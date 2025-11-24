using UnityEngine;

public class StepGas : StepAtomicBase
{
    private void OnEnable()
    {
        TotalSteps = 2;
        StartStep();
        Debug.Log("StartStepGas");
    }
    protected override void ExecuteCurrentStep()
    {
        switch (CurretSteps)
        {
            case 0:
                Debug.Log("Solid step 0");
                break;
            case 1:
                Debug.Log("Solid step 1");
                break;
        }
    }
}

