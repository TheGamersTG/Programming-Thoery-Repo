using UnityEngine;

public class AttackSpeedBoost : Powerup
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public override void PowerUp()
    {
        opila.attackSpdBuff();
    }

}
