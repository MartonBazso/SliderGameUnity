
using UnityEngine;
using DG.Tweening;

public class PlayerStateMove : PlayerStateBase
{
	private Vector3 nextPosition, destination;

	public override void Enter(PlayerStateMachine context)
	{
		destination = context.transform.position;
		nextPosition = Vector3.zero;
	}

	public override void Update(PlayerStateMachine context)
	{
		context.transform.position = Vector3.MoveTowards(context.transform.position, destination, context.Speed * Time.deltaTime);

		//context.transform.DOMove(destination, 0.1f);
		nextPosition = destination + context.MoveDirection;

		if (Vector3.Distance(context.transform.position, destination) < 0.001f)
		{
			destination = nextPosition;
		}

		RaycastHit hit;
		if (Physics.Raycast(context.transform.position, context.MoveDirection, out hit, 0.5f))
		{
			if (hit.collider.gameObject.CompareTag("Wall"))
			{
				context.ChangeState(PlayerStateFactory.Create(PlayerStateType.Collide));
			}
		}
	}
}