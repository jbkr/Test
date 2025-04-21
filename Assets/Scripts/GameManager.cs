using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingletone<GameManager>
{

    [SerializeField]
    private Transform _canvasTrasn; // 씬이 바뀌면 사라짐 

    void Start()
    {
        var temp = Instance;

        UIManager.Instance.CreateUI<StartUI>();
    }

    public void OnClickStartButton()
    {
        UIManager.Instance.RemoveUI<StartUI>();
        UIManager.Instance.CreateUI<ModeUI>();

        ModeUI modeUI = UIManager.Instance.GetUI<ModeUI>();
        modeUI.AddTimeClickEvent(OnClickTimeAttackMode);
        modeUI.AddTimeClickEvent(UIManager.Instance.RemoveUI<ModeUI>);

        // 찾았다 !!
        //Destroy(gameObject);
    }

    public void OnClickTimeAttackMode()
    {
        StartCoroutine(LoadSceneAsync("GameScene"));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // 여기서 게임씬이 다 로드 된 이후에 다음 코드를 읽겠습니다. 
        yield return SceneManager.LoadSceneAsync(sceneName);

        // 플레이어 생성해주면 됨 
        GameObject resGO = Resources.Load<GameObject>("Prefab/PangPlayer");
        GameObject realGO = Instantiate(resGO);
        realGO.transform.position = new Vector3(0, -2.66f, 0);

        // 배경도 로드해야겠다.
        GameObject bottomRes = Resources.Load<GameObject>("Prefab/Bottom");
        GameObject bottomGo = Instantiate(bottomRes);

        // 일반 공을 생성해봐야겠다. 
        GameObject gongRes = Resources.Load<GameObject>("Prefab/Gong");
        GameObject gongGo = Instantiate(gongRes);
        gongGo.transform.position = new Vector3(0, 6, 0);

        Transform tr = realGO.transform;

        UIManager.Instance.CreateUI<ScoreUI>();
    }

    public void CreateEffect(Vector3 pos)
    {
        // 일반 공을 생성해봐야겠다. 
        GameObject gongRes = Resources.Load<GameObject>("Prefab/ExplosionEffect");
        GameObject gongGo = Instantiate(gongRes);
        gongGo.transform.position = pos;
    }

    int index = 0;

    private IEnumerator TimeCheck()
    {
        while (true)
        {

            yield return new WaitForSeconds(1);


            index++;

            Debug.Log("index : " + index);
        }
    }





    private void OnClickStageMode()
    {

    }

}
