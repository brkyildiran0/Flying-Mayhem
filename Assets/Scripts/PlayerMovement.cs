using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Position Parameters")]
    [SerializeField] float controlSpeed = 10f;
    [SerializeField] float xRange = 7f;
    [SerializeField] float yRange = 5f;

    [Header("Rotation Parameters")]
    [SerializeField] float positionPitchFactor = 3f;
    [SerializeField] float positionYawFactor = 3f;
    [SerializeField] float controlPitchFactor = 15f;
    [SerializeField] float controlRollFactor = 2f;
    [SerializeField] float rotationFactor = 3f;

    [SerializeField] GameObject[] lasers;

    float xThrow, yThrow;

    void Update()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        HandleMovement();
        HandleRotation();
        HandleLasers();
    }

    void HandleLasers()
    {
        if (Input.GetButton("Fire1"))
        {
            SetLasersActive(true);
        }
        else
        {
            SetLasersActive(false);
        }
    }

    void SetLasersActive(bool state)
    {
        foreach (GameObject laser in lasers)
        {
            var laserParticleSystem = laser.GetComponent<ParticleSystem>().emission;
            laserParticleSystem.enabled = state;
        }
    }

    void HandleRotation()
    {
        float pitchDuetoPosition = transform.localPosition.y * -positionPitchFactor;
        float pitchDueToControlThrow = -yThrow * controlPitchFactor;
        float pitch = pitchDuetoPosition + pitchDueToControlThrow;

        float yaw = transform.localPosition.x * positionYawFactor;

        float roll = xThrow * -controlRollFactor;

        Quaternion targetRotation = Quaternion.Euler(pitch, yaw, roll);
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rotationFactor);
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
