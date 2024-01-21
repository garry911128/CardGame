using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicManager : MonoBehaviour {
    private static MusicManager instance;

    public static MusicManager Instance {
        get { return instance; }
    }

    void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // 在这里实现音乐播放逻辑
}
