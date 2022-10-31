using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseModel : MonoBehaviour
{
    private GameObject currentGo;
    public List<Button> btnList;
    public List<string> nameList;
    public Transform modelController;

    private void Start()
    {
        for (int i = 0; i < btnList.Count; ++i)
        {
            // 注意闭包问题
            var btn = btnList[i];
            btn.onClick.AddListener(() => { LoadModel(btn); });
        }
    }


    void LoadModel(Button btn)
    {
        // 每次加载前销毁 可优化：记录上一次，每一次重新点击同一个按钮判断是否徐娅重新加载
        if (currentGo != null) Destroy(currentGo);

        var index = btnList.IndexOf(btn);
        var name = nameList[index];
        GameObject prefab = Resources.Load<GameObject>("Prefabs/" + name);
        var go = Instantiate(prefab);
        
        // 设置坐标和父级关系，每次设置前需要把parent的旋转角度归0
        go.transform.position = Vector3.zero;
        modelController.eulerAngles = Vector3.zero;
        go.transform.SetParent(modelController, false);

        currentGo = go;
        Debug.Log(name);
    }

  
}