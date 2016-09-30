using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour {
	private Animator myAnimator;

	private AnimatorStateInfo animState;

	private Rigidbody myRigidbody;

	private float fowardForce = 800.0f;

	private float turnForce = 500.0f;

	private float upForce = 500.0f;

	private float movableRange = 3.4f;

	private float coefficient = 0.95f;

	private bool isEnd = false;

	private GameObject stateText;

	private GameObject scoreText;

	int Score = 0;

	private bool isLButtonDown = false;

	private bool isRButtonDown = false;




	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator> ();

		myAnimator.SetFloat ("Speed", 1f);

		myRigidbody = GetComponent<Rigidbody> ();

		stateText = GameObject.Find ("GameResultText");

		scoreText = GameObject.Find ("ScoreText");


	
	}
	
	// Update is called once per frame
	void Update () {

		if (isEnd) {
			fowardForce *= coefficient;
			turnForce *= coefficient;
			upForce *= coefficient;
			myAnimator.speed *= coefficient;

			}

		myRigidbody.AddForce (transform.forward * fowardForce);

		if ((Input.GetKey (KeyCode.LeftArrow)|| isLButtonDown) && -movableRange < transform.position.x) {
			myRigidbody.AddForce (-turnForce, 0, 0);
		} else if ((Input.GetKey (KeyCode.RightArrow)||isRButtonDown) && movableRange > transform.position.x) {
			myRigidbody.AddForce (turnForce, 0, 0);
		}

		if (myAnimator.GetCurrentAnimatorStateInfo (0).IsName ("Jump")) {
			myAnimator.SetBool ("Jump", false);
		}

		if ((Input.GetKey (KeyCode.Space)) && transform.position.y < 0.5f) {
			myAnimator.SetBool ("Jump", true);
			myRigidbody.AddForce (transform.up * upForce);
		}


	}

	void OnTriggerEnter(Collider c){
		if (c.gameObject.tag == "CarTag" || c.gameObject.tag == "TrafficConeTag") {
			isEnd = true;
			stateText.GetComponent<Text> ().text = "Game Over";

		}

		if (c.gameObject.tag == "GoalTag") {
			isEnd = true;
			stateText.GetComponent<Text> ().text = "CLEAR!!";
		}

		if (c.gameObject.tag == "CoinTag") {
			Score += 10;
			scoreText.GetComponent<Text>().text = "Score:"+Score+"pt";
			GetComponent<ParticleSystem> ().Play ();
			Destroy (c.gameObject);
		}

	}

	public void GetMyJumpButtonDown(){
		if (transform.position.y < 0.5f) {
			myAnimator.SetBool ("Jump", true);
			myRigidbody.AddForce (transform.up * upForce);
		}
	}

	public void GetMyLeftButtonDown(){
		isLButtonDown = true;
	}

	public void GetMyLeftButtonUp(){
		isLButtonDown = false;
	}

	public void GetMyRightButtonDown(){
		isRButtonDown = true;
	}

	public void GetMyRightButtonUp(){
		isRButtonDown = false;
	}


}
