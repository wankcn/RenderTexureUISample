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
        if (currentGo != null)
        {
            GameObject.Destroy(currentGo);
        }

        var index = btnList.IndexOf(btn);
        var name = nameList[index];
        GameObject prefab = Resources.Load<GameObject>("Prefabs/" + name);
        var go = Instantiate(prefab);
        go.transform.position = Vector3.zero;
        modelController.eulerAngles = Vector3.zero;
        go.transform.SetParent(modelController, false);
        currentGo = go;
        
        Debug.Log(name);
    }
}