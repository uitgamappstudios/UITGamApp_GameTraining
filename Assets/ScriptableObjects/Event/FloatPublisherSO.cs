using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "FloatPublisherSO", menuName = "ScriptableObjects/Events/FloatPublisherSO")]
public class FloatPublisherSO : ScriptableObject
{
    public UnityAction<float> OnEventRaised;

    public void RaiseEvent(float value)
    {
        OnEventRaised?.Invoke(value);
    }
}
