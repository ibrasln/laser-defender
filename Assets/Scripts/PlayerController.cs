using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed;

    Vector2 rawInput;

    Vector2 minBounds, maxBounds;
    [SerializeField] float padding = .5f;

    Shooter shooter;

    private void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    private void Start()
    {
        InitBounds();
    }

    private void Update()
    {
        Movement();
    }

    void InitBounds()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(Vector2.zero);
        maxBounds = mainCamera.ViewportToWorldPoint(Vector2.one);
    }

    void Movement()
    {
        Vector3 delta = moveSpeed * Time.deltaTime * rawInput;
        Vector2 newPos = new()
        {
            x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + padding, maxBounds.x - padding),
            y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + padding, maxBounds.y - padding)
        };
        transform.position = newPos;
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if (shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }

}
