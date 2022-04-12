using System;
using UnityEngine;

public abstract class PlayerStateBase
{
	public virtual void Enter(PlayerStateMachine context) { }
	public virtual void Update(PlayerStateMachine context) { }

	public virtual void HandleMovementInput(PlayerStateMachine context, Vector2 vector2) { }

	public virtual void HandleCollision(PlayerStateMachine context, Collision collision) { }
}
