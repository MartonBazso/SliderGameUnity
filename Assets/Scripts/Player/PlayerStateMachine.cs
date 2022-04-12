using System;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
	[SerializeField]
	public int Speed = 2;


	public PlayerStateBase CurrentState { get; private set; }
	public Vector3 MoveDirection { get; set; }
    private PlayerControls controls;

	void Awake() { 
		
        controls = new PlayerControls();
        controls.PlayerMovement.Move.performed += ctx => MoveInput(ctx.ReadValue<Vector2>());
	}

	void Start()
	{
		CurrentState = PlayerStateFactory.Create(PlayerStateType.Idle);
		CurrentState.Enter(this);
	}

	void Update()
	{
		CurrentState.Update(this);
	}

	public void ChangeState(PlayerStateBase newState)
	{
		CurrentState = newState;
		CurrentState.Enter(this);
	}

	void OnCollisionEnter(Collision collision)
	{
		CurrentState.HandleCollision(this, collision);
	}

	private void MoveInput(Vector2 vector2)
	{
        CurrentState.HandleMovementInput(this, vector2);
	}

    void OnEnable() {
        controls.Enable();
    }

    void OnDisable() {
        controls.Disable();
    }

}