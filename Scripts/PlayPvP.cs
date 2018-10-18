using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayPvP : MonoBehaviour {

	// Use this for initialization
	public void playPvP()
    {
        SceneManager.LoadScene("PvP");
    }
    public void playPvAI()
    {
        SceneManager.LoadScene("PvAI");
    }
}
