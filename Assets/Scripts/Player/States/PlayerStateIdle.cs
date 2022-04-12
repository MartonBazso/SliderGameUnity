using UnityEngine;

public class PlayerStateIdle : PlayerStateBase
{
	public override void HandleMovementInput(PlayerStateMachine context, Vector2 vector2)
	{
		context.MoveDirection = new Vector3(vector2.x, 0, vector2.y);
		context.ChangeState(PlayerStateFactory.Create(PlayerStateType.Rotate));
	}
}