using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class CutScenePlay : MonoBehaviour
{
    [SerializeField] private PlayableDirector pd;
    [SerializeField] private int cutSceneId;
    [SerializeField] private string BackToScene;
    
    private void Awake()
    {
        pd.stopped += OnPlayableDirectorStopped; // end call back √ﬂ∞°.
    }

  
    // Playable Dircetor¿« end callback
    private void OnPlayableDirectorStopped(PlayableDirector a)  //Why is this Argument required
    {
        if (pd == a) //Why is this required?
        {
            DataManager.Instance().updataStoryData(cutSceneId);
            DataManager.Instance().updataAlarmData(true);
            SceneManager.LoadScene(BackToScene);
        }
    }

    public void FinishCutScene()
    {
        pd.Stop();
    }
}
