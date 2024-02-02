using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// IProduct arabirimine sahip sınıflar, bir ürünün adını ve başlatma işlemlerini tanımlayabilir.
public interface IProduct
{
    // Ürünün adını getiren özellik.
    string ProductName { get; }

    // Ürünü başlatan metod.
    void Initialize();
}
