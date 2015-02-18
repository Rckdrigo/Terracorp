using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Facebook.MiniJSON;

public class FBProfileManager : Singleton<FBProfileManager> {

	public delegate void FBEvents();
	public event FBEvents InitiatedEvent;
	public event FBEvents LoggedInEvent;
	public event FBEvents LoggedOutEvent;
	public event FBEvents LoggedInFailedEvent;
	public event FBEvents DataLoadedEvent;

	private string username;
	public string Username {get {return username;} }
	
	private bool loggedIn;
	public bool LoggedIn {get {return loggedIn;} }

	Dictionary<string,object> userData;

	void Start () {
		print(FB.IsLoggedIn);
		FB.Init(FBInit);
		
	}
	
	void FBInit(){
		print ("FB initialized");
		loggedIn = FB.IsLoggedIn;
		
		InitiatedEvent();
	}

	public void FBLogin(string requieredData){
		if(!FB.IsLoggedIn)
			FB.Login(requieredData,FBLoginCallback);
	}

	void FBLoginCallback(FBResult result){
		if(FB.IsLoggedIn){
			print("Login succesful "+ FB.UserId);
			LoggedInEvent();
		}
		else {
			print("Login fail");
			LoggedInFailedEvent();
		}
	}
	
	public void LoadData(string requiredData){
		FB.API(requiredData, Facebook.HttpMethod.GET,GetFBData);
	}
	
	void GetFBData(FBResult result){
		userData = Json.Deserialize(result.Text) as Dictionary<string,object>;
		username =  (string)userData["name"];

		DataLoadedEvent();
	}
	
	public void FBPostStatus(string status){
		if(FB.IsLoggedIn)
			FB.Feed(linkCaption: "I just smashed " + 1 + " friends! Can you beat it?");
	}
	
	
	void FBPostStatusCallback(FBResult result){
		print ("Done posting");
	}
	
	public void FBLogout(){
		if(FB.IsLoggedIn)
			FB.Logout();
		LoggedOutEvent();
	}

}
