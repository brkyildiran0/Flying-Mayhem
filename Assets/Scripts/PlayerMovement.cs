using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 7f;
    [SerializeField] float yRange = 5f;

    [SerializeField] float positionPitchFactor = 3f;
    [SerializeField] float controlPitchFactor = -15f;
    [SerializeField] float controlRollFactor = -12f;
    [SerializeField] float controlYawFactor = -5f;


    float xThrow, yThrow;

    void Update()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        HandleMovement();
        HandleRotation();
    }
     
    void HandleRotation()
    {
        float pitch = transform.localRotation.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localRotation.x * controlYawFactor;
        float roll = transform.localRotation.z + xThrow * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void HandleMovement()
    {
        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange);

        float yOffset = yThrow * controlSpeed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -yRange + 1f, yRange);


        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
