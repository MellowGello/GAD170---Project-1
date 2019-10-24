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
        /// I added a random variable that simply has a randomized number each time the player dance.
        /// As well as adding more into the random number, either positively or negatively, depending on the player's current luck level.
        float rand = Random.Range(-2.0f, 2.0f);

        if (data.player.luck >= 5)
        {
            rand += Random.Range(0.0f, 3.0f);
        }
        else if (data.player.luck <= -5)
        {
            rand += Random.Range(-3.0f, 0.0f);
        }

        ///I made a formula that determines whether the battle is a win or a loss.
        ///The formula maybe simple, but this is the best I can get that makes the game balanced.
        float outcome = ((data.player.rhythm - data.player.style) + rand);

        ///The Clamp feature is there to make the win at maximum of 1 and minimum of -1.
        ///Then it displays the result of the battle by whether the player wins or lose in the console.
        outcome = Mathf.Clamp(outcome, -1.0f, 1.0f);
        if (outcome >= 0.0f)
        { 
           Debug.Log("You Win!");
        }
        else if(outcome <= 0.0f)
        {
            Debug.Log("You Lose!");
        }
        
        
        var results = new BattleResultEventData(data.player, data.npc, outcome);

        GameEvents.FinishedBattle(results);

    }
}
