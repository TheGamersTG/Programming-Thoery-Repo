using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
  private List<Wave> empty = new List<Wave>{null};

private List<Wave> Level1Waves;

private List<Wave> Level2Waves;

//ENEMY LISTS
public List<GameObject> Level1Enemies;

public List<GameObject> Level2Enemies;


  void Awake()
    {
        //LEVEL 1 WAVES
        Level1Waves = new List<Wave>
        {
            new Wave(1, new List<GameObject> { Level1Enemies[1], Level1Enemies[0] }, new List<Vector2> { new Vector2(0, 0), new Vector2(0, 0) }, 1f, false),
            new Wave(2, new List<GameObject> { Level1Enemies[1], Level1Enemies[0], Level1Enemies[2] }, new List<Vector2> { new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0) }, 10f, false),
            new Wave(3, new List<GameObject> { Level1Enemies[3], Level1Enemies[0] }, new List<Vector2> { new Vector2(0, 0), new Vector2(0, 0) }, 10f, true)
        };
  
        //LEVEL 2 WAVES (CHANGE THIS TO LEVEL2ENEMIES[0] LATER!!!)
        Level2Waves = new List<Wave>
        {
            new Wave(1, new List<GameObject> { Level1Enemies[1], Level1Enemies[0] }, new List<Vector2> { new Vector2(0, 0), new Vector2(0, 0) }, 1f, false),
            new Wave(2, new List<GameObject> { Level1Enemies[1], Level1Enemies[0], Level1Enemies[2] }, new List<Vector2> { new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0) }, 5f, false),
            new Wave(3, new List<GameObject> { Level1Enemies[0], Level1Enemies[0], Level1Enemies[0] }, new List<Vector2> { new Vector2(0, 0), new Vector2(0, 0), new Vector2(0, 0) }, 7f, false),
            new Wave(4, new List<GameObject> { Level1Enemies[3], Level1Enemies[0] }, new List<Vector2> { new Vector2(0, 0), new Vector2(0, 0) }, 10f, true)
        };
    }

  public List<Wave> GetWaveByLevel(){
    
        if (MainManager.instance.level == 1)
        {
            return Level1Waves;
        }

        else if (MainManager.instance.level == 2)
        {
            return Level2Waves;
        }
    else{
        return empty;
    }
}
}
