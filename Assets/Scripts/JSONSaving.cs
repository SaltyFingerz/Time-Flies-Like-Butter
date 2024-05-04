using System.IO;
using UnityEngine;

public class JSONSaving : MonoBehaviour
{
    private PlayerData playerData;
    private string path = "";
    private string peristentPath = "";
    [SerializeField] private int ThisLevelInt = 0;
   

    private void Start()
    {
     
        SetPaths();
    }

    
    public void ResetPlayerData()
    {
       
        playerData = new PlayerData(0);
    }

    private void SetPaths()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
        peristentPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }

    public void SaveData()
    {
        string savePath = path;
        Debug.Log("Saving Data at" + savePath);
        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);

        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);


    }

    public void LoadData()
    {
        using StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        int level = data.level;
       
        Debug.Log(data.ToString());
    }

    public void LevelComplete ()
    {
        playerData = new PlayerData(ThisLevelInt);
        SaveData();
    }


    public int LoadLevelInt()
    {
        using StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        int level = data.level;
        return level;
    }



}
