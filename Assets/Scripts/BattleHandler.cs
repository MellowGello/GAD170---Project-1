using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Static class with method (function) to determine the outcome of a dance battle based on the player and NPC that are 
///     dancing off against each other.
///     
/// TODO:
///     Battle needs to use stats and random to determine the winner of the dance off
///       - outcome value to be a float value between 1 and negative 1. 1 being the biggest possible player win over NPC, 
///         through to -1 being the most decimating defeat of the player possible.
/// </summary>
public static class BattleHandler
{
    public static void Battle(BattleEventData data)
    {
        //This needs to be replaced with some actual battle logic, at present 
        // we just award the maximum possible win to the player
        float rand = Random.Range(-2.0f, 2.0f);

        if (data.player.luck >= 5)
        {
            rand += Random.Range(0.0f, 3.0f);
        }
        else if (data.player.luck <= -5)
        {
            rand -= Random.Range(-3.0f, 0.0f);
        }


        float outcome = ((data.player.rhythm - data.player.style) + rand);

        outcome = Mathf.Clamp(outcome, -1.0f, 1.0f);
        Debug.Log(outcome);
        
        var results = new BattleResultEventData(data.player, data.npc, outcome);

        GameEvents.FinishedBattle(results);

    }
}
