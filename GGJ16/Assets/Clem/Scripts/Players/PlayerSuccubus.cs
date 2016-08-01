using System;

public class PlayerSuccubus : PlayerDefaultCharacter {

	public override void Start() {
		PV = 3;

		base.Start();
		playerType = PlayerType.Succubus;
		speed = 1.1f;
		atk_dist = 2.5f;
	}

	public override void SpecialAction() {
		//charge
		throw new NotImplementedException();
	}
}
