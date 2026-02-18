using UnityEngine;

public class Heal : Powerup
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public override void PowerUp()
    {
        opila.changeHP(1);
    }

}
