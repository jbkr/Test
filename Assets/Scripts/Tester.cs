using UnityEngine;
using uTools;
using Gpm.Ui;
using UnityEngine.UIElements;

public class MyItemData : InfiniteScrollData
{
    public int Number;
}

// MVC
// Model ( InfiniteScrollData ) , View ( InfiniteScrollItem ), Controller ( InfiniteScroll )

public class Tester : MonoBehaviour
{
    [SerializeField]
    InfiniteScroll _scroll;


    void Start()
    {


    }

    int accIndex;

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            MyItemData data = new MyItemData();
            data.Number = accIndex++;
            MyItemData data2 = new MyItemData();
            data2.Number = accIndex++;
            MyItemData data3 = new MyItemData();
            data3.Number = accIndex++;
            MyItemData data4 = new MyItemData();
            data4.Number = accIndex++;

            _scroll.InsertData(data);
            _scroll.InsertData(data2);
            _scroll.InsertData(data3);
            _scroll.InsertData(data4);
        }


        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    MyItemData data = new MyItemData();
        //    data.Number = accIndex++;
        //    MyItemData data2 = new MyItemData();
        //    data2.Number = accIndex++;
        //    MyItemData data3 = new MyItemData();
        //    data3.Number = accIndex++;
        //    MyItemData data4 = new MyItemData();
        //    data4.Number = accIndex++;

        //    _scroll.InsertData(data);
        //    _scroll.InsertData(data2);
        //    _scroll.InsertData(data3);
        //    _scroll.InsertData(data4);
        //}
    }
}


