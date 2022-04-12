using UnityEngine;

public class PlayerStateRotate : PlayerStateBase
{
	private Vector3 up = new Vector3(0, 0, 0);
	private Vector3 right = new Vector3(0, 90, 0);
	private Vector3 down = new Vector3(0, 180, 0);
	private Vector3 left = new Vector3(0, 270, 0);
	public override void Enter(PlayerStateMachine context)
	{
		Debug.Log(context.MoveDirection);
		if (context.MoveDirection.x == 1)
		{
			context.transform.localEulerAngles = left;
		}

		if (context.MoveDirection.x == -1)
		{
			context.transform.localEulerAngles = right;
		}

		if (context.MoveDirection.z == 1)
		{
			context.transform.localEulerAngles = down;
		}

		if (context.MoveDirection.z == -1)
		{
			context.transform.localEulerAngles = up;
		}

		context.ChangeState(PlayerStateFactory.Create(PlayerStateType.Move));
	}

}