using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{

    public VideoPlayer vid;
 
    public void Start() {
        vid.loopPointReached += EndReached;
    }
    
    public void EndReached(UnityEngine.Video.VideoPlayer vp) {
        SceneManager.LoadScene(3);
    }
}
