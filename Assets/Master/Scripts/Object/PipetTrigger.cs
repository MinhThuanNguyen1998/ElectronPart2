using System.Collections;
using LiquidVolumeFX;
using UnityEngine;

public class PipetTrigger : MonoBehaviour
{
    [SerializeField] private LiquidVolume m_LiquidVolumePipet;
    [SerializeField] private LiquidVolume m_TubeLiquidVolumeTube;

    private float m_DurationTime = 4f;
    private float m_MinLevelVolume = 0f;
    private float m_MaxLevelVolume = 0.5f;

    private bool m_IsPipetFilled = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tube"))
        {
            if (!m_IsPipetFilled) return;
            StartCoroutine(ChangeLiquidLevel(m_LiquidVolumePipet, m_MinLevelVolume, m_DurationTime));
            StartCoroutine(ChangeLiquidLevel(m_TubeLiquidVolumeTube, m_MaxLevelVolume, m_DurationTime));
            
        }
        else if (other.CompareTag("Flask"))
        {
            m_IsPipetFilled = true;
            StartCoroutine(ChangeLiquidLevel(m_LiquidVolumePipet, m_MaxLevelVolume, m_DurationTime));
        }
    }
    IEnumerator ChangeLiquidLevel(LiquidVolume liquid, float targetLevel, float duration)
    {
        float start = liquid.level;
        float t = 0;
        while (t < duration)
        {
            t += Time.deltaTime;
            liquid.level = Mathf.Lerp(start, targetLevel, t / duration);
            yield return null;
        }
        liquid.level = targetLevel;
    }
}
