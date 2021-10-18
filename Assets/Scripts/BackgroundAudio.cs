using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudio : MonoBehaviour
{
    public static BackgroundAudio instance;
    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject); 
            return;
        }
        DontDestroyOnLoad(gameObject);
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
