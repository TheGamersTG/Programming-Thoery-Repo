using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;


public class Wave{

    public int waveNumber;
   private List<GameObject> enemies;
   private List<Vector2> postions;
   private float time;

   private bool isBossWave;

   public Wave (int waveNumber, List<GameObject> enemies, List<Vector2> postions, float time, bool isBossWave)
    {
        this.waveNumber = waveNumber;
        this.enemies = enemies;
        this.postions = postions;
        this.time=time;
        this.isBossWave = isBossWave;
    }

    public int getWaveNumber() { return waveNumber; }
    public List<GameObject> getEnemies() { return enemies;}
    public List<Vector2> getPostions() {return postions;}
    public float getTime() { return time; }

    public bool CheckifBossWave() { return isBossWave;}
}