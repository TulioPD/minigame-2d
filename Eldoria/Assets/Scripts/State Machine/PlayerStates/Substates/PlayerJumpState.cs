using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    private int amountOfJumpsLeft;
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        amountOfJumpsLeft = playerData.amountOfJumps;
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocityY(playerData.jumpVelocity);
        isAbilityDone=true;
        amountOfJumpsLeft--;
        player.AirState.SetIsJumping();
    }
    public void ResetAmountOfJumpsLeft() => amountOfJumpsLeft = playerData.amountOfJumps;
    public bool CanJump() => amountOfJumpsLeft > 0;
    public void DecreaseAmountOfJumpsLeft() => amountOfJumpsLeft--;
}
