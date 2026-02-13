using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{

    public int level;

    public int HScore;

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

    public int getLevel()
    {
        return level;
    }

[System.Serializable]
class SaveData
{
    public int HScore;
    public int level;
}

public void SaveScore()
{
    SaveData data = new SaveData();
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
    SaveData data = new SaveData();
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
}