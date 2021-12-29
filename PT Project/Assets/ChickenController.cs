using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public abstract class Chicken
{
    protected GameObject gameObject;
    public Chicken(GameObject g) { gameObject = g; }

    public abstract void jump();
}

// INHERITANCE
public class Hen : Chicken
{
    public Hen(GameObject g) : base(g)
    {

    }
    // POLYMORPHISM
    public override void jump()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 5.0f, 0.0f), ForceMode.Impulse);
    }
}

// INHERITANCE
public class Chick : Chicken
{
    public Chick(GameObject g) : base(g)
    {

    }
    // POLYMORPHISM
    public override void jump()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 1.0f, 0.0f), ForceMode.Impulse);
    }
}

// INHERITANCE
public class Rooster : Chicken
{
    public Rooster(GameObject g) : base(g)
    {

    }
    // POLYMORPHISM
    public override void jump()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0.0f, 15.0f, 0.0f), ForceMode.Impulse);
    }
}