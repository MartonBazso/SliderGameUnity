using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerStateMove2 : PlayerStateBase
{
	public override void Enter(PlayerStateMachine context)
	{
		float counter = 0;
		bool hitSomething = false;
		while (!hitSomething)
		{
			RaycastHit hit;

			if (Physics.Raycast(context.transform.position, context.MoveDirection, out hit, counter))
			{
				if (hit.collider.gameObject.CompareTag("Wall"))
				{
					hitSomething = true;
				}
			}
			else
			{
				counter += 1f;
			}
		}
		Vector3 destination = context.transform.position + context.MoveDirection * (counter - 1);
		context.transform.DOMove(destination, counter / context.Speed).OnStepComplete(() =>
		{
			context.ChangeState(PlayerStateFactory.Create(PlayerStateType.Idle));
		});
	}
}
