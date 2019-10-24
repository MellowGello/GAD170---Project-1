using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///  A <see langword="static"/> class with methods (functions) for initialising or randomising the stats class.
///  
/// TODO:
///     Initialise a stats instance with generated starting stats
///     Handle the assignment of extra points or xp into an existing stats of a character
///         - this is expected to be used by NPCs leveling up to match the player.
/// </summary>
public static class StatsGenerator
{

    public static void InitialStats(Stats stats)
    {
        /// I added the stats variable and randomize the number so that each time the player plays the game, he or she will have a different stats in each playthrough
        /// However, the level and xp variable stays the same in everytime at the start
        /// The Debug.Log is there to simply display the starting stats in the console, although I cannot specify it to the player's own stats as it also displays the npc's stats.
        stats.style = Random.Range(0, 2);
        
        stats.rhythm = Random.Range(1, 2);
        
        stats.luck = Random.Range(-1, 1);
        

        stats.level = 1;
        stats.xp = 0;

        Debug.Log("Style Stats:" + stats.style);
        Debug.Log("Rhythm Stats:" + stats.rhythm);
        Debug.Log("Luck Stats:" + stats.luck);

    }    
    
    public static void AssignUnusedPoints(Stats stats, int points)
    {
        ///I created my own variable for each stat except luck. 
        ///The reason being is that the stats increase at random numbers, 
        /// that random number is stored in it's own unique variable that will be added to the appropriate stats.
        ///All the leftover points will be added in luck.
        ///The new stats will be displayed in the console
        int StylePoints = Random.Range(0, 3);
        stats.style += StylePoints;
        points -= StylePoints;

        int RhythmPoints = Random.Range(0, 2);
        stats.rhythm += RhythmPoints;
        points -= RhythmPoints;

        stats.luck += points;

        Debug.Log("New style Stats:" + stats.style);
        Debug.Log("New rhythm Stats:" + stats.rhythm);
        Debug.Log("New luck Stats:" + stats.luck);
    }
}
