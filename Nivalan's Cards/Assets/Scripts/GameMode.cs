using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameMode : MonoBehaviour {
    public static GameMode singleton = null;
    //public static modeType ModeType = modeType.None;
    public static bool? online = null;
    private void Awake()
    {
        if (singleton && singleton != this)
        {
            DestroyImmediate(gameObject);
            return;
        }
        else
        {
            singleton = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
