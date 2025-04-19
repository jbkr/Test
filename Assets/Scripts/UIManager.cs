using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

// 생성, 관리, 삭제
// 이름으로 관리!

public class UIBase : MonoBehaviour
{

}

public class UIManager : MonoSingletone<UIManager>
{
    private Transform _canvasTrasn;

    private Dictionary<string, UIBase> _container = new Dictionary<string, UIBase>();

    private string _uiPath = "Prefab/";
    

    private void Awake()
    {
        if (_canvasTrasn == null)
        {
            gameObject.AddComponent<Canvas>();
            gameObject.AddComponent<CanvasScaler>();
            _canvasTrasn = gameObject.transform;
        }
        else
        {
            _canvasTrasn = transform;
        }
    }

    public void CreateUI<T>() where T : UIBase
    {
        GameObject resGO = Resources.Load<GameObject>(_uiPath + typeof(T).ToString());
        GameObject sceanGO = Instantiate(resGO, _canvasTrasn, false);
        T comp = sceanGO.GetComponent<T>();
        _container.Add(typeof(T).ToString(), comp);
    }

    public void CreateStartUI()
    {
        // ModeUI 프리팹을 리소스를 로드해서, Instantiate한다. 
        //GameObject resGO = Resources.Load<GameObject>("Prefab/StartUI");
        //GameObject sceanGO = Instantiate(resGO, _canvasTrasn, false);
        //StartUI comp = sceanGO.GetComponent<StartUI>();

        //_container.Add(typeof(StartUI).ToString(), comp);
    }

    //모드 UI만드는 코드를 작성해서 StartUI버튼이 눌렸을때
    // 호출해보자 

    //ModeUI uiComp;

    public void CreateModeUI()
    {
        RemoveContainerUI("StartUI");

        // 게임매니저가 ModUI만들어주고 있었는데 
        GameObject resGO = Resources.Load<GameObject>("Prefab/ModeUI");
        GameObject sceanGO = Instantiate(resGO, _canvasTrasn, false);
        ModeUI uiComp = sceanGO.GetComponent<ModeUI>();

        _container.Add(typeof(ModeUI).ToString(), uiComp);

        uiComp.AddTimeClickEvent(GameManager.Instance.OnClickTimeAttackMode);
        uiComp.AddTimeClickEvent(RemoveModeUI);
    }

    private void RemoveModeUI()
    {
        RemoveContainerUI("ModeUI");
    }

    private void RemoveContainerUI(string uiName)
    {
        UIBase strtui;
        bool result = _container.TryGetValue(uiName, out strtui);

        if (result)
        {
            Debug.Log(strtui.gameObject.name);
            Destroy(strtui.gameObject);
            _container.Remove(uiName);
        }
    }

    //ScoreUI scoreUIComp;
    public void CreateScoreUI()
    {
        // 게임 UI 로드하는 부분 
        GameObject scoreUIRes = Resources.Load<GameObject>("Prefab/ScoreUI");
        GameObject scoreUIGo = Instantiate(scoreUIRes, _canvasTrasn, false);
        ScoreUI scoreUIComp = scoreUIGo.GetComponent<ScoreUI>();

        _container.Add(typeof(ScoreUI).ToString(), scoreUIComp);


    }

    public void AddScore()
    {
        UIBase strtui;
        bool result = _container.TryGetValue("ScoreUI", out strtui);

        if (result)
        {
            //((ScoreUI)strtui).ChangeScore(20000);
            ScoreUI comp;
            comp = strtui as ScoreUI;
            if (comp != null)
            {
                comp.ChangeScore(20000);
            }
        }

        //scoreUIComp.ChangeScore(20000);
    }


}
