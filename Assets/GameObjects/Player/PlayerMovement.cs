using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] GameObject PlayerActorPrefab;

    InputAction moveAction;
    Rigidbody rigidBody;

    private void Awake()
    {
        GameObject playerActor = Instantiate(PlayerActorPrefab);

        rigidBody = playerActor.GetComponent<Rigidbody>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirecton = moveAction.ReadValue<Vector2>();
        Vector3 moveForce = new Vector3(moveDirecton.x, 0, moveDirecton.y);

        rigidBody.AddForce(moveForce * 5);
    }
}
