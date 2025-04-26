using TMPro;
using UnityEngine;
using System;
using System.IO;

// 떨어져 있는 데이터를 한 곳에
[Serializable] // 파일로 쓸 수 있거나
public class PlayerInfo
{
    public string Name;
    public int Level;
}

public class InGameScoreUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textMeshProUGUI;

    private void SaveToFile()
    {
        PlayerInfo newPlayerInfo = new PlayerInfo();
        newPlayerInfo.Name = "Pacman";
        newPlayerInfo.Level = 10;

        string json = JsonUtility.ToJson(newPlayerInfo, true);
        string path = Application.persistentDataPath + "/" + "pacman.txt";
        File.WriteAllText(path, json);
        Debug.Log(path);
    }

    private void LoadToFile()
    {
        string fileName = "pacman.txt";
        string path = Path.Combine(Application.persistentDataPath, fileName);
        string json = File.ReadAllText(path);
        PlayerInfo stats = JsonUtility.FromJson<PlayerInfo>(json);
        Debug.Log("불러오기 완료" + stats.Name + " " + stats.Level);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SaveToFile();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadToFile();
        }
    }
}
