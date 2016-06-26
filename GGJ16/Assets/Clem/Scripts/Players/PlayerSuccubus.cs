using System;

public class PlayerSuccubus : PlayerDefault {

	public override void Start() {
		base.Start();
		playerType = PlayerType.Succubus;
		PV = 3;
		speed = 1.1f;
		atk_dist = 2.5f;
	}

	public override void SpecialAction() {
		//charge
		throw new NotImplementedException();
	}
}
