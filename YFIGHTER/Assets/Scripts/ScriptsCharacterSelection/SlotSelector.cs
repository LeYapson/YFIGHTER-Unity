using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SlotSelector : MonoBehaviour {
	public RectTransform navigator1;
    int nav1Pos = 0;
	public RectTransform navigator2;
    int nav2Pos = 0;

	public RectTransform[] slots = new RectTransform[6];

    public int jumpAmount = 6;

    // public Text textShowNav1;
    // public Text textShowNav2;

    void Start(){
        MoveNav1(0);
        MoveNav2(1);
    }

	void Update () {
		// move up
		if(Input.GetKeyDown(KeyCode.W)){
			MoveNav1(-jumpAmount);
		}
		if(Input.GetKeyDown(KeyCode.UpArrow)){
			MoveNav2(-jumpAmount);
		}

		if(Input.GetKeyDown(KeyCode.A)){
			MoveNav1(-1);
		}
		if(Input.GetKeyDown(KeyCode.LeftArrow)){
			MoveNav2(-1);
		}

		if(Input.GetKeyDown(KeyCode.S)){
			MoveNav1(jumpAmount);
		}
		if(Input.GetKeyDown(KeyCode.DownArrow)){
			MoveNav2(jumpAmount);
		}

		if(Input.GetKeyDown(KeyCode.D)){
			MoveNav1(1);
		}
		if(Input.GetKeyDown(KeyCode.RightArrow)){
			MoveNav2(1);
		}
	}

	void MoveNav1(int change){
		if(change > 0){
			if(nav1Pos+change < slots.Length-1){
				nav1Pos += change;
			}else{
				nav1Pos = slots.Length-1;
			}
		}else{
			if(nav1Pos+change >= 0){
				nav1Pos += change;
			}else{
				nav1Pos = 0;
			}
		}
		navigator1.position = slots[nav1Pos].position;
                // textShowNav1.text = "Nav 1 is at slot "+ nav1Pos;
	}

	void MoveNav2(int change){
		if(change > 0){
			if(nav2Pos+change < slots.Length-1){
				nav2Pos += change;
			}else{
				nav2Pos = slots.Length-1;
			}
		}else{
			if(nav2Pos+change >= 0){
				nav2Pos += change;
			}else{
				nav2Pos = 0;
			}
		}
		navigator2.position = slots[nav2Pos].position;
                // textShowNav2.text = "Nav 2 is at slot "+ nav2Pos;
	}
}