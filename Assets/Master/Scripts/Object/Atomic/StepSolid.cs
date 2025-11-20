using UnityEngine;

public class StepSolid : StepAtomicBase
{

    private void OnEnable()
    {
        TotalSteps = 2;
        StartStep();
        Debug.Log("StepSolid");
    }
    protected override void ExecuteCurrentStep()
    {
        Debug.Log("Step step: " + CurretSteps);
    }
}
