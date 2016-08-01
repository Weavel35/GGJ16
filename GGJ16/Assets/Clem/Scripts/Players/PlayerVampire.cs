using System;

public class PlayerVampire : PlayerDefaultCharacter {

	public override void Start() {
		base.Start();
		playerType = PlayerType.Vampire;


	}
	//regagne pv + chauve souris + crains lumière
	public override void SpecialAction() {
		//chauve souris
		throw new NotImplementedException();
	}
}
