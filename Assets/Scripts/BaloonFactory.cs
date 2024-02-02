using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Balon fabrikası sınıfı, IFactory arayüzünü uygular ve balon nesnelerini oluşturur.
public class BaloonFactory : MonoBehaviour, IFactory
{
    // Balonların oluşturulacağı pozisyon.
    public Transform SpawnPosition;

    // Balon prefabı.
    public GameObject Baloon;

    // Belirtilen konumda bir balon ürünü oluşturan metod.
    public IProduct GetProduct(Vector2 Position)
    {
        // Balon prefabını SpawnPosition konumunda instantiate et.
        var balon = Instantiate(Baloon, SpawnPosition);
        balon.transform.position = Position;

        // Yeni bir Baloon ürünü oluşturup döndür.
        return new Baloon();
    }

    // Ürünü üreten metod.
    public void PreduceProduct()
    {
        // Belirtilen konumda bir balon ürünü oluştur.
        GetProduct(SpawnPosition.position);
    }
}

// Balon sınıfı, IProduct arayüzünü uygular ve bir balon nesnesini temsil eder.
public class Baloon : IProduct
{
    // Ürünün adını tutan özellik.
    private string productName;

    // Ürün adını döndüren özellik.
    public string ProductName => productName;

    // Balonun başlangıçta yapılandırılmasını sağlayan metod.
    public void Initialize()
    {
        // Ürün adını "PinkBalon" olarak ayarla.
        productName = "PinkBalon";
    }
}
