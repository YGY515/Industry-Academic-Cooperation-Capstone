using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

// 저장하는 방법
// 1. 저장할 데이터가 존재.
// 2. 데이터를 Json으로 변환
// 3. Json을 외부에 저장

// 불러오는 방법
// 1. 외부에 저장된 제이슨을 가져옴
// 2. 제이슨을 데이터 형태로 변환
// 3. 불러온 데이터 사용
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
