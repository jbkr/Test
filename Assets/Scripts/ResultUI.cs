using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultUI : UIBase
{
    [SerializeField]
    private Button _gotoLobby;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _gotoLobby.onClick.AddListener(OnClickGotoLobby);
    }

    private void OnClickGotoLobby()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
