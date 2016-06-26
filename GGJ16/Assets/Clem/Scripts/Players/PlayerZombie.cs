using System;

public class PlayerZombie : PlayerDefault {

	public override void Start() {
		base.Start();
		playerType = PlayerType.Zombie;
		PV = 5;
		speed = 0.80f;
		atk_dist = 2;
		atk_pow = 2;

	}

	public override void SpecialAction() {
		//explosion
		throw new NotImplementedException();
	}
}
