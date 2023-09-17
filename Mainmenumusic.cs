using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainmenumusic : MonoBehaviour
{
   
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MuteToggle(bool muted)
    {
        if (muted)
        {
            AudioListener.volume = 0;
        }
        else if(!muted)
        {
            AudioListener.volume = 1;
        }
    }
}
