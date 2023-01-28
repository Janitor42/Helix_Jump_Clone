using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public Transform Level;
    public float Sensinvity;
    private Vector3 _previousMousePosition;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _previousMousePosition;
            Level.Rotate(0, -delta.x * Sensinvity, 0);

        }
        _previousMousePosition = Input.mousePosition;
    }
}
