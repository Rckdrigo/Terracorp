using UnityEngine;
using System.Collections;

public class GameStateMachine : Singleton<GameStateMachine> {

	public delegate void GameStates();
	
	public GameStates state;

}
