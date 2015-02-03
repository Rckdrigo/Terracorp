using UnityEngine;
using System.Collections;

public class FBProfileManager : Singleton<FBProfileManager> {

	void Start () {
		FB.Init(FBInit);
	}
	
	void FBInit(){
		print("Facebook Init");
	}

	public void FBLogin(){
		if(!FB.IsLoggedIn)
			FB.Login("user_about_me, user_birthday",FBLoginCallback);
	}

	void FBLoginCallback(FBResult result){
		if(FB.IsLoggedIn){
			print("Login succesful");
			FBPostStatus("");
		}
		else 
			print("Login fail");
	}
	
	public void FBPostStatus(string status){
		if(FB.IsLoggedIn)
			FB.Feed(linkCaption: "I just smashed " + 1 + " friends! Can you beat it?");
	}
	
	
	void FBPostStatusCallback(FBResult result){
	
	}
	
	public void FBLogout(){
		if(FB.IsLoggedIn)
			FB.Logout();
	}

}
