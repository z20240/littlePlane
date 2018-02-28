using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using LitJson;
public class LocalFile {
    public void SaveLocalFile(string path, string fileName, object obj) {
        string fpath = System.IO.Path.Combine(path, fileName);

        //將myPlayer轉換成json格式的字串
        string saveString = JsonMapper.ToJson(obj);

        //將字串saveString存到硬碟中
        StreamWriter file = new StreamWriter(fpath);
        file.Write(saveString);
        file.Close();
    }

    public JsonData LoadLocalFile(string path, string fileName) {
        string fpath = System.IO.Path.Combine(path, fileName);
        Debug.Log("path:" + fpath);
        if (!File.Exists(fpath)) {
            return null;
        }

        //讀取json檔案並轉存成文字格式
        StreamReader file = new StreamReader(fpath);
        string loadJson = file.ReadToEnd();
        file.Close();

        //新增一個物件類型為playerState的變數 loadData
        JsonData loadData = JsonMapper.ToObject(loadJson);

        return loadData;
    }
}
