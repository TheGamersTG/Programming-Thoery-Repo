using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Unity.VisualScripting;

public class MainManager : MonoBehaviour
{

    SaveData data = new SaveData();

    public int level;

    public int HScore;

    public int player; // 0 = opila, 1 = tartra, ect

    //ENCAPSULATION
    public static MainManager instance { get; private set; }


    private void Awake()
    {
        if (instance != null){
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }
    // Start is called before the first frame update
    void Start()
    {
        level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

//functions to get and set the current level. will be updated with save stuff later
    public void updateLevel()
    {
        level += 1;
    }

//set the current player.
    public void setPlayer(int player)
    {
        this.player = player;
    }

  public int getPlayer(int player)
    {
       return player;
    }
    public int getLevel()
    {
        return level;
    }

[System.Serializable]
class SaveData
{
    public int HScore;
    public int level;
    public int player;

}



public void SaveScore()
{
    data.HScore = HScore;

    string json = JsonUtility.ToJson(data);
  
    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
}

public void LoadScore()
{
    string path = Application.persistentDataPath + "/savefile.json";
    if (File.Exists(path))
    {
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        HScore = data.HScore;
    }
}

public void SaveLevel()
{
    data.level = level;

    string json = JsonUtility.ToJson(data);
  
    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
}

public void LoadLevel()
{
    string path = Application.persistentDataPath + "/savefile.json";
    if (File.Exists(path))
    {
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        level = data.level;
    }
}

    public void savePlayer()
{
    data.player = player;

    string json = JsonUtility.ToJson(data);
  
    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
}

public void loadPlayer()
{
    string path = Application.persistentDataPath + "/savefile.json";
    if (File.Exists(path))
    {
        string json = File.ReadAllText(path);
        SaveData data = JsonUtility.FromJson<SaveData>(json);

        player = data.player;
    }
}
}