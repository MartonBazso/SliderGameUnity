public class PlayerStateCollide : PlayerStateBase
{
	public override void Enter(PlayerStateMachine context)
	{
		context.ChangeState(PlayerStateFactory.Create(PlayerStateType.Idle));
	}
}