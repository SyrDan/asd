using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private InputAction MovementAction;
    [SerializeField] private float speed =  5f;
    [SerializeField] private float maxX = 3f;
    [SerializeField] private float maxY = 8f;
    [SerializeField] private float minY = -4f;

    [SerializeField] private float pitchFactor = -5f;
    [SerializeField] private float controlPitchFactor = 5f;
    [SerializeField] private float controlRollFactor = 15f;
    [SerializeField] private float yawFactor = 4f;
 
    private Vector3 shipLocalPos;

    float _horizontalMovement;
    float _verticalMovement;

    private void Update()
    {
        ProcessRoration();
        ProcessThrow();
    }
    void ProcessRoration()
    {
        float pitch = transform.localPosition.y * pitchFactor + _verticalMovement * controlPitchFactor;
        float yaw = transform.localPosition.x * yawFactor;
        float roll = _horizontalMovement * controlRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessThrow()
    {
        _horizontalMovement = MovementAction.ReadValue<Vector2>().x;
        _verticalMovement = MovementAction.ReadValue<Vector2>().y;

        shipLocalPos.x = Mathf.Clamp(transform.localPosition.x + _horizontalMovement * Time.deltaTime * speed, -maxX, maxX);
        shipLocalPos.y = Mathf.Clamp(transform.localPosition.y + _verticalMovement * Time.deltaTime * speed, minY, maxY);

        transform.localPosition = shipLocalPos;
    }
}
