using UnityEngine;
using Gpm;
using Gpm.Ui;
using TMPro;
public class MyItem : InfiniteScrollItem
{
    public override void UpdateData(InfiniteScrollData scrollData)
    {
        MyItemData myItemData = scrollData as MyItemData;
        GetComponentInChildren<TextMeshProUGUI>().text = myItemData.Number.ToString();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
