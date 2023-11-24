using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

// �����ϴ� ���
// 1. ������ �����Ͱ� ����.
// 2. �����͸� Json���� ��ȯ
// 3. Json�� �ܺο� ����

// �ҷ����� ���
// 1. �ܺο� ����� ���̽��� ������
// 2. ���̽��� ������ ���·� ��ȯ
// 3. �ҷ��� ������ ���
public class DataManager : MonoBehaviour
{
    private static DataManager instance;

    [SerializeField]
    public PlayerData nowPlayer = new PlayerData();

    public string path;
    public string userId;
  //  public string filename = ;

    public PlayerData GetPlayerData() {return nowPlayer; }

    public static DataManager Instance()
    {
        if (null == instance)
        {
            return null;
        }
        return instance;
    }

    private void Awake()
    {
        if (null == instance)
        {
            instance = this;

            DontDestroyOnLoad(this.gameObject);
        }
     

        path = Application.persistentDataPath+"/";
    }

    void Start()
    {
           
    }

    void Update()
    {
       
    }
 
    public void updataStoryData(int storyId)
    {
        nowPlayer.story = storyId;
        SaveData();
    }
    public void updataAlarmData(bool alarmCheck)
    {
        nowPlayer.alarm = alarmCheck;
        SaveData();
    }

    public void updataMiniGameData(int miniGame)
    {
        nowPlayer.miniGame = miniGame;
        SaveData();
    }

    public void SaveData()
    {
        string data = JsonUtility.ToJson(nowPlayer);
        File.WriteAllText(path + userId, data);
    }

    public void LoadData(string userId)
    { 
        string data = File.ReadAllText(path+userId);
        nowPlayer= JsonUtility.FromJson<PlayerData>(data);
    }

    public int NowPlayerStroyData()
    {
        return nowPlayer.story;
    }
    public bool NowPlayerAlarmData()
    {
        return nowPlayer.alarm;
    }
    public int NowPlayerMiniGameData()
    {
        return nowPlayer.miniGame;
    }
   
}
