using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster_walk : MonoBehaviour
{

    public static float Speed = 1;

    Rigidbody rb;

    public static float OffsetY = 0;
    public static float Offsetx = 0;

    [SerializeField] private float Freeze_time;

    private float _timeLeft = 0f;
    private bool _timerOn = false;

    Vector3 raycastWallPos;

    bool walk = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        _timeLeft = Freeze_time;
        _timerOn = true;
    }

    private void Update()
    {
        if (_timerOn)
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= Time.deltaTime;
                UpdateTimeText();
            }
            else
            {
                _timeLeft = Freeze_time;
                _timerOn = false;
            }
        }
    }

    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
        {
            walk = true;
            _timerOn = false;
        }
    }

    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!walk)
            MovementLogic(false);
        else
            MovementLogic(true);
    }
    void MovementLogic(bool forward)
    {
        if (forward)
        {
            if (WallRaycasts_forward() != Vector3.zero)
            {
                rb.MoveRotation(Quaternion.LookRotation(-transform.right + transform.forward));
            }
            else if (WallRaycast_right() != Vector3.zero)
            {
                rb.MoveRotation(Quaternion.LookRotation(-transform.right + transform.forward));
            }
            else if (WallRaycast_left() != Vector3.zero)
            {
                rb.MoveRotation(Quaternion.LookRotation(transform.right + transform.forward));
            }

            rb.velocity = (Speed * transform.forward);
        }
        else rb.velocity = Vector3.zero;
    }

    Vector3 WallRaycasts_forward()
    {
        raycastWallPos = transform.TransformPoint(0, 0 + 0.01f, 0);

        Debug.DrawRay(raycastWallPos, transform.forward * 0.28f, Color.magenta);

        if (Physics.Raycast(raycastWallPos, transform.forward * 0.28f, out RaycastHit hit_forward, 0.28f))
        {
            return hit_forward.point;
        }
        return Vector3.zero;
    }
    Vector3 WallRaycast_right()
    {
        raycastWallPos = transform.TransformPoint(0, 0 + 0.01f, 0);

        Debug.DrawRay(raycastWallPos, (transform.right + transform.forward) * 0.2f, Color.magenta);

        if (Physics.Raycast(raycastWallPos, transform.right * 0.2f, out RaycastHit hit_right, 0.2f))
        {
            return hit_right.point;
        }
        return Vector3.zero;
    }
    Vector3 WallRaycast_left()
    {
        raycastWallPos = transform.TransformPoint(0, 0 + 0.01f, 0);

        Debug.DrawRay(raycastWallPos, (-transform.right + transform.forward) * 0.2f, Color.magenta);

        if (Physics.Raycast(raycastWallPos,- transform.right * 0.2f, out RaycastHit hit_left, 0.2f))
        {
            return hit_left.point;
        }
        return Vector3.zero;
    }
}

