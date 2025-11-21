using UnityEngine;

public class StepLiquid : StepAtomicBase
{
    private void OnEnable()
    {
        TotalSteps = 3;
        StartStep();
        Debug.Log("StepLiquid");
    }
    protected override void ExecuteCurrentStep()
    {
        //Debug.Log("Step step: " + CurretSteps);
        switch (CurretSteps)
        {
            case 0:
                Debug.Log("Solid step 0");
                break;
            case 1:
                Debug.Log("Solid step 1");
                break;

            case 2:
                Debug.Log("Solid step 2");
                break;
            case 3:
                Debug.Log("Solid step 3");
                break;
        }
    }
}
