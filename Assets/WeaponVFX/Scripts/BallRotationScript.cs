using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScript : MonoBehaviour
{

    [Header("Rotation X")]
    [SerializeField]
    [Range(-100.0f, 100.0f)]
    private float rotationSpeedX;

    [SerializeField]
    private bool useSinX = false;

    [Header("Rotation Y")]
    [SerializeField]
    [Range(-100.0f, 100.0f)]
    private float rotationSpeedY;

    [SerializeField]
    private bool useSinY = false;

    [Header("Rotation Z")]
    [SerializeField]
    [Range(-100.0f, 100.0f)]
    private float rotationSpeedZ;

    [SerializeField]
    private bool useSinZ = false;

    [Header("Sin Min Value")]
    [SerializeField]
    [Range(0.1f, 0.99f)]
    private float sinValue = 0.7f;

    void Update()
    {
        float calculatedRotationSpeedX = CalculateRotationSpeed(rotationSpeedX, useSinX);
        float calculatedRotationSpeedY = CalculateRotationSpeed(rotationSpeedY, useSinY);
        float calculatedRotationSpeedZ = CalculateRotationSpeed(rotationSpeedZ, useSinZ);

        Quaternion rotationX = Quaternion.AngleAxis(calculatedRotationSpeedX, Vector3.right);
        Quaternion rotationY = Quaternion.AngleAxis(calculatedRotationSpeedY, Vector3.up);
        Quaternion rotationZ = Quaternion.AngleAxis(calculatedRotationSpeedZ, Vector3.forward);

        transform.localRotation *= rotationX * rotationY * rotationZ;
    }

    private float CalculateRotationSpeed(float baseSpeed, bool useSin)
    {
        float rotationSpeed = baseSpeed * Time.deltaTime;
        if (useSin)
        {
            rotationSpeed *= (Mathf.Sin(Time.timeSinceLevelLoad) * sinValue) + (1.0f - sinValue);
        }
        return rotationSpeed;
    }
}
