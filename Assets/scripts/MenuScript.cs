using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
	public float targetRatio = 3f / 2f;

	public void ChangeScene(string sceneName)
	{
		SceneManager.LoadScene (sceneName);
	}
    public void exitapp()
    {
        Application.Quit();
    }

	void Start(){
		Camera cam = GetComponent<Camera> ();

		cam.aspect = targetRatio;
	}


}
