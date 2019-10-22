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
            data.player.xp += (data.player.rhythm + data.player.style) * 100;
            Debug.Log(data.player.xp);
        }

        int xplevelcap = 500 + (data.player.level * 250);
        if (data.player.xp >= xplevelcap)
        {
            data.player.level += 1;
            data.player.xp = 0;
            Debug.Log(data.player.level);
        }

    }
}
