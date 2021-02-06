using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class FacadeClass<T> : IJsonParser<T>
{
    public T ParseJson(string FilePath)
    {
       return JsonUtility.FromJson<T>(LoadFile(FilePath).text);
    }
    TextAsset LoadFile(string Path)
    {
        return Resources.Load<TextAsset>(Path);
    }
}
