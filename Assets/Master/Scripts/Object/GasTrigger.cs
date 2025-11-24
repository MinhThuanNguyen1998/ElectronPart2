using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GasTrigger : MonoBehaviour
{
    [SerializeField] private StepGas m_StepGas;
    [SerializeField] private Material m_OriginMaterial;
    [SerializeField] private Material m_EffectMaterial;
    [SerializeField] private List<Renderer> m_ListRenderer;
    private bool m_IsGasTrigger = false;
    private float m_LerpDuration = 6f;
    private float m_TimeToChangeMaterial = 8f;
    private void OnTriggerEnter(Collider other)
    {
        if (m_IsGasTrigger) return;
        if (other.CompareTag("Pipe"))
        {
            m_StepGas?.GoToNextStep();
            m_IsGasTrigger = true;
            StartCoroutine(ChangeMaterialAfterDelay(m_TimeToChangeMaterial, m_LerpDuration));
        }
    }
    private IEnumerator ChangeMaterialAfterDelay(float delay, float lerpDuration)
    {
        MouseDragLock.Block();
        yield return new WaitForSeconds(delay);
        yield return LerpMaterial(m_OriginMaterial, m_EffectMaterial, lerpDuration);
    }
    private IEnumerator LerpMaterial(Material fromMat, Material toMat, float duration)
    {
       
        float time = 0f;
        while (time < duration)
        {
            float t = time / duration;
            foreach (var renderer in m_ListRenderer)
            {
                if (renderer != null) renderer.material.Lerp(fromMat, toMat, t);
            }
            time += Time.deltaTime;
            yield return null;
        }
        SetMaterial(toMat);
        MouseDragLock.Unblock();
    }
    private void SetMaterial(Material material)
    {
        if (m_ListRenderer == null) return;
        foreach (var renderer in m_ListRenderer)
        {
            if (renderer != null) renderer.material = material;
        }
    }
}
