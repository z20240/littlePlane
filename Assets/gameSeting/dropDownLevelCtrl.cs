using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropDownLevelCtrl : MonoBehaviour {

	public Dropdown drondownLevel;
    //显示选择的内容
    public Text Txt_CurrentNode;

	void Start () {
        //清空默认节点
        drondownLevel.options.Clear();
        //初始化
        string[] str_level = {"簡單", "一般", "困難"};

        foreach (var item in str_level) {
            Dropdown.OptionData op = new Dropdown.OptionData();
            op.text = item;
            drondownLevel.options.Add(op);
        }
        // 默認為一般級別
        Txt_CurrentNode.text = drondownLevel.options[1].text;
	}

	// Update is called once per frame
	void Update () {

	}

    public void GetCurrentNode() {
        Txt_CurrentNode.text = drondownLevel.options[drondownLevel.value].text;
    }
}
