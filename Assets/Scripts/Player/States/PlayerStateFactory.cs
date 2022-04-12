using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateFactory
{
	public static PlayerStateBase Create(PlayerStateType type)
	{
		switch (type)
		{
			case PlayerStateType.Idle:
				return new PlayerStateIdle();
			case PlayerStateType.Move:
				return new PlayerStateMove2();
			case PlayerStateType.Collide:
				return new PlayerStateCollide();
			case PlayerStateType.Rotate:
				return new PlayerStateRotate();
			default:
				return null;
		}
	}
}
