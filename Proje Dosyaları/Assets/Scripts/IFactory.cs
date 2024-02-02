using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// IFactory arabirimine sahip sınıflar, belirli bir konumda bir ürün oluşturabilir.
public interface IFactory
{
    // Belirtilen konumda bir ürün döndüren metod.
    IProduct GetProduct(Vector2 Position);
}
