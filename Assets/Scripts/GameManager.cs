using System;
using System.Collections;
using System.Net.NetworkInformation;
using Mono.Cecil;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoSingletone<GameManager>
{

    [SerializeField]
    private Transform _canvasTrasn; // ���� �ٲ�� ����� 

    void Start()
    {
        var temp = Instance;

        //UIManager.Instance.CreateStartUI();
        UIManager.Instance.CreateUI<StartUI>();

        //StartCoroutine(TimeCheck());
    }

    private UnityAction _onEventAction;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("class Type : " + typeof(StartUI));
        }
    }

    private void ShowLogOne()
    {
        Debug.Log("ShowLogOne");
    }

    private void ShowLogTwo()
    {
        Debug.Log("ShowLogTwo");

    }

    //private void OnClickStartButton()
    //{
    //    //_startButton.gameObject.SetActive(false);       

    //    Debug.Log("OnClickStartButton");
    //    // ModeUI �������� ���ҽ��� �ε��ؼ�, Instantiate�Ѵ�. 
    //    GameObject resGO = Resources.Load<GameObject>("Prefab/ModeUI");
    //    Debug.Log("resGO : " + resGO);

    //    GameObject sceanGO = Instantiate(resGO, _canvasTrasn, false);
    //    ModeUI uiComp = sceanGO.GetComponent<ModeUI>();
    //    uiComp.AddTimeClickEvent(OnClickTimeAttackMode);
    //    uiComp.AddStageClickEvent(OnClickStageMode);
    //}

    public void OnClickStartButton()
    {
        UIManager.Instance.CreateModeUI();

        // ã�Ҵ� !!
        //Destroy(gameObject);
    }

    public void OnClickTimeAttackMode()
    {
        Debug.Log("OnClickTimeAttackMode");

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

        UIManager.Instance.CreateScoreUI();
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
