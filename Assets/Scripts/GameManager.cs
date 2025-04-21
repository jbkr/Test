using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoSingletone<GameManager>
{

    [SerializeField]
    private Transform _canvasTrasn; // ���� �ٲ�� ����� 

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

        // ã�Ҵ� !!
        //Destroy(gameObject);
    }

    public void OnClickTimeAttackMode()
    {
        StartCoroutine(LoadSceneAsync("GameScene"));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // ���⼭ ���Ӿ��� �� �ε� �� ���Ŀ� ���� �ڵ带 �аڽ��ϴ�. 
        yield return SceneManager.LoadSceneAsync(sceneName);

        // �÷��̾� �������ָ� �� 
        GameObject resGO = Resources.Load<GameObject>("Prefab/PangPlayer");
        GameObject realGO = Instantiate(resGO);
        realGO.transform.position = new Vector3(0, -2.66f, 0);

        // ��浵 �ε��ؾ߰ڴ�.
        GameObject bottomRes = Resources.Load<GameObject>("Prefab/Bottom");
        GameObject bottomGo = Instantiate(bottomRes);

        // �Ϲ� ���� �����غ��߰ڴ�. 
        GameObject gongRes = Resources.Load<GameObject>("Prefab/Gong");
        GameObject gongGo = Instantiate(gongRes);
        gongGo.transform.position = new Vector3(0, 6, 0);

        Transform tr = realGO.transform;

        UIManager.Instance.CreateUI<ScoreUI>();
    }

    public void CreateEffect(Vector3 pos)
    {
        // �Ϲ� ���� �����غ��߰ڴ�. 
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
