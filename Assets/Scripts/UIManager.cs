using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

	public GameObject FBLogin;
	public GameObject FBLogout;
	
	public GameObject welcomeText;
	

	// Use this for initialization
	void Start () {
		FBProfileManager.Instance.LoggedInEvent += LoggedIn;
		FBProfileManager.Instance.LoggedOutEvent+= LoggedOut;
		FBProfileManager.Instance.DataLoadedEvent += DataLoaded;
		FBProfileManager.Instance.InitiatedEvent += Initiated;
	}

	void Initiated ()
	{
		if(FBProfileManager.Instance.LoggedIn)
			LoggedIn ();
		else
			LoggedOut ();
		
	}

	void LoggedIn ()
	{
		FBLogin.SetActive(false);
		FBLogout.SetActive(true);
		FBProfileManager.Instance.LoadData("/me?fields=name");
	}
	
	void DataLoaded(){
		welcomeText.SetActive(true);
		welcomeText.GetComponent<Text>().text = "Bienvenido " + FBProfileManager.Instance.Username;
	}
	
	void LoggedOut ()
	{
		FBLogin.SetActive(true);
		FBLogout.SetActive(false);
		welcomeText.SetActive(false);
	}
	
	void OnGUI(){
		GUILayout.Label(""+FB.IsLoggedIn);
	}
}
