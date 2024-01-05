using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaloonFactory : MonoBehaviour, IFactory
{
    public Transform SpawnPosition;
    public GameObject Baloon;
    public IProduct GetProduct(Vector2 Position)
    {
        var balon = Instantiate(Baloon, SpawnPosition);
        balon.transform.position = Position;
        return new Baloon();
    }

    public void PreduceProduct()
    {
        GetProduct(SpawnPosition.position);
    }
}
public class Baloon : IProduct
{
    private string productName;
    public string ProductName => productName;

    public void Initialize()
    {
        productName = "PinkBalon";
    }

}