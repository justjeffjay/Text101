using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;
	private enum States { start, cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom };
	private States myState;

	// Use this for initialization
	void Start () {
		text.text = "<Press Space to Begin Game>";
		myState = States.start;
	}
	
	// Update is called once per frame
	void Update () {
		print ("myState: " + myState);
		if 		(myState == States.start) 		{ start_game(); }
		else if (myState == States.cell) 		{ state_cell(); }
		else if (myState == States.sheets_0) 	{ state_sheets_0(); }
		else if (myState == States.lock_0) 		{ state_lock_0(); }
		else if (myState == States.mirror) 		{ state_mirror(); }
		else if (myState == States.cell_mirror) { state_cell_mirror(); }
		else if (myState == States.sheets_1) 	{ state_sheets_1(); }
		else if (myState == States.lock_1) 		{ state_lock_1(); }
		else if (myState == States.freedom) 	{ state_freedom(); }
	}

	void start_game () {
		if (Input.GetKeyDown(KeyCode.Space)) {		
			myState = States.cell;
		}
	}
	void state_cell () {
		text.text = "Once upon a time you fell asleep. Not an every day occurance to be sure. However, " +
					"this was far from a normal day. On this day when your eyes closed something, dare I say it, " +
					"unusual happened. On this day when you closed your eyes you would never be the same again. " +
					"On this day your world would end... Open your eyes and look at the prison your life has become.\n\n" +
					"S to view Sheets; M to view Mirror; L to view Lock";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_0;
		} else if (Input.GetKeyDown(KeyCode.M)) {
			myState = States.mirror;
		} else if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_0;
		}	
	}
	void state_sheets_0 () {
		text.text = "You look at your sheets and consider for a moment wearing them ghost-style to scare the guards.\n\n" +
					"Then you realize that's just dumb.\n\n" +
					"R to Return to your cold damp reality of a cell";
		if (Input.GetKeyDown(KeyCode.R)) {		
			myState = States.cell;
		} 
	}	
	void state_lock_0 () {
		text.text = "You stare at the lock. The lock stares back. You play this game for a few hours.\n\n" +
					"Nothing changes.\n\n" +
					"R to Return to your cell a little older but no wiser";
		if (Input.GetKeyDown(KeyCode.R)) {		
			myState = States.cell;
		} 
	}	
	void state_mirror () {
		text.text = "Ahhhhhhh! Oh wait, that's just your own face staring back. It's not pleasant. You don't want to linger.\n\n" +
					"R to Return to your cell, B to break the Mirror";
		if (Input.GetKeyDown(KeyCode.R)) {		
			myState = States.cell;
		} else if (Input.GetKeyDown(KeyCode.B)) {		
			myState = States.cell_mirror;
		} 	
	}
	void state_cell_mirror () {
		text.text = "You smashed that mirror good. You're now bleeding, and quite badly. Uh-oh.\n\n" +
					"At least you have a piece of that stupid thing to remember your mistake.\n\n" +
					"S to view Sheets; L to view Lock";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_1;
		} else if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_1;
		}	
	}	
	void state_sheets_1 () {
		text.text = "Good job. You're sheets are now the color red. Which can be used to...\n\n" +
					"Well, do nothing really. Shoot.\n\n" +
					"R to return to your cell and revisit your previous actions";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_mirror;
		}	
	}	
	void state_lock_1 () {
		text.text = "You are so smart. Seriously. Genius level. That mirror can be used as a key!\n\n" +
					"That didn't work. But at that exact moment, a wizard appeared and unlocked the cell. What luck!\n\n" +
					"F to run to freedom";
		if (Input.GetKeyDown(KeyCode.F)) {
			myState = States.freedom;
		}	
	}	
	void state_freedom () {
		text.text = "You are free!\n\n" +
					"Oh wait, no. You're still in jail, just not in a jail cell. Your journey has just begun...\n\n" +
					"Q to start over";
		if (Input.GetKeyDown(KeyCode.Q)) {
			myState = States.cell;
		}	
	}
}
