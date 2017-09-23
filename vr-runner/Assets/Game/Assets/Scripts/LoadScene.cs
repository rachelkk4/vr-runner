using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public void loadByIndex(int sceneIndex)
    {
        // Load a scene using the scene manager
        SceneManager.LoadScene(sceneIndex);
    }
}
