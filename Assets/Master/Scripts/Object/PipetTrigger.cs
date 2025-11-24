using System.Collections;
using LiquidVolumeFX;
using UnityEngine;

public class PipetTrigger : MonoBehaviour
{
    [SerializeField] private LiquidVolume m_LiquidVolumePipet;
    [SerializeField] private LiquidVolume m_LiquidVolumeTube;
    [SerializeField] private StepLiquid m_StepLiquid;
    private float m_DurationTime = 4f;
    private float m_MinLevelVolume = 0f;
    private float m_MaxLevelVolume = 0.5f;

    private bool m_IsPipetFilled = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tube"))
        {
            if (!m_IsPipetFilled || m_LiquidVolumeTube.level >= 0.5) return;
            StartCoroutine(ChangeLiquidLevel(m_LiquidVolumePipet, m_MinLevelVolume, m_DurationTime));
            StartCoroutine(ChangeLiquidLevel(m_LiquidVolumeTube, m_MaxLevelVolume, m_DurationTime));
            m_StepLiquid?.GoToNextStep();
        }
        else if (other.CompareTag("Flask"))
        {
            if (m_LiquidVolumePipet.level >= 0.5 || m_LiquidVolumeTube.level >= 0.5) return;
            m_IsPipetFilled = true;
            StartCoroutine(ChangeLiquidLevel(m_LiquidVolumePipet, m_MaxLevelVolume, m_DurationTime));
            m_StepLiquid?.GoToNextStep();
        }
    }
    IEnumerator ChangeLiquidLevel(LiquidVolume liquid, float targetLevel, float duration)
    {
        MouseDragLock.Block();
        float start = liquid.level;
        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            liquid.level = Mathf.Lerp(start, targetLevel, t / duration);
            yield return null;
        }
        liquid.level = targetLevel;
        MouseDragLock.Unblock();
    }
}
