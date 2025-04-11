using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatEventListener : MonoBehaviour
{
    [SerializeField] private FloatPublisherSO publisher;
    [SerializeField] private UnityEvent<float> EventResponse;

    private void OnEnable()
    {
        publisher.OnEventRaised += Respond;
    }

    private void OnDisable()
    {
        publisher.OnEventRaised -= Respond;
    }

    private void Respond(float value)
    {
        EventResponse?.Invoke(value);
    }
}
