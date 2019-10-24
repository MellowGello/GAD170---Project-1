using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class is responsible for converting a battle result into xp to be awarded to the player.
/// 
/// TODO:
///     Respond to battle outcome with xp calculation based on;
///         player win 
///         how strong the win was
///         stats/levels of the dancers involved
///     Award the calculated XP to the player stats
///     Raise the player level up event if needed
/// </summary>
public class XPHandler : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.OnBattleConclude += GainXP;

    }

    private void OnDisable()
    {
        GameEvents.OnBattleConclude -= GainXP;
    }

    public void GainXP(BattleResultEventData data)
    {
        if (data.outcome >= 0)
        {   
            ///Calculated how the player gains xp by adding both style and rhythm and multiply it by a 100.
            ///It will also display the current xp in both the console as well as in the game
            data.player.xp += (data.player.rhythm + data.player.style) * 100;
            GameEvents.PlayerXPGain(data.player.xp);
            Debug.Log("XP:"+data.player.xp);
        }

        ///This variable is here to determine the xp required to level up. It will also increase the xp requirement everytime the player levels up.
        int xplevelcap = 500 + (data.player.level * 250);
        if (data.player.xp >= xplevelcap)
        {
            ///This simply increases the level by one and reset the xp back to 0.
            data.player.level += 1;
            GameEvents.PlayerLevelUp(data.player.level);
            data.player.xp = 0;
            Debug.Log("Player level:" + data.player.level);
        }

    }
}
