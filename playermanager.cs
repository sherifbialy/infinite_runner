using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermanager : MonoBehaviour
{
    public static bool gameover;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        gameover = false;
        Time.timeScale = 1;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameover)
        {
            Time.timeScale = 0;
        }
    }
}
