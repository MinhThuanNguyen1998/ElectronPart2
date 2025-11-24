using System.Collections;
using LiquidVolumeFX;
using UnityEngine;
using static Unity.VisualScripting.Member;
using static UnityEngine.GraphicsBuffer;

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
            if (!m_IsPipetFilled || m_LiquidVolumeTube.level >= m_MaxLevelVolume) return;
            StartCoroutine(ChangeLiquidLevel(m_LiquidVolumePipet, m_MinLevelVolume, m_DurationTime)); // Transfer volume from source pipet to target tube and set volume of pipet = 0
            StartCoroutine(ChangeLiquidLevel(m_LiquidVolumeTube, m_MaxLevelVolume, m_DurationTime)); // Transfer volume from source pipet to target tube and set volume of tube = 0.5
            m_StepLiquid?.GoToNextStep();
        }
        else if (other.CompareTag("Flask"))
        {
            if (m_LiquidVolumePipet.level >= m_MaxLevelVolume || m_LiquidVolumeTube.level >= m_MaxLevelVolume) return;
            m_IsPipetFilled = true;
            StartCoroutine(ChangeLiquidLevel(m_LiquidVolumePipet, m_MaxLevelVolume, m_DurationTime)); // Transfer volume from source flask to target pipet and set volume of pipet = 0.5
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
