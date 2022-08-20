using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera_Controller : MonoBehaviour
{

    public GameObject Ball;
    Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {
        // Öncelikle 2 nokta arasýndaki mesafeyi nasýl bulurum? = Þimdi kameramýzýn pozisyonundan karakterimizin pozisyonunu çýkartýrsak arasýndaki
        // transform.position                             // mesafeyi bulmuþ oluruz. Peki biz kameramýzýn pozisyonununa nasýl ulaþabiliriz? = þuan zaten kameranýn içerisine bir kod yazýyoruz.
        // ama bu þekilde topumuzun pozisyonununa ulaþamýyoruz bu yüzden hemen yukarýda oyun objesini atýyoruz globale.

        // Ball.transform.position                        // bu þekilde ulaþabiliyoruz. (topun pozisyonuna)

        distance = transform.position - Ball.transform.position;    // Bu þekilde aradaki mesafeyi bir kez buldurttuk bakýn farkýndaysanýz starta yazdým tek kez buldurmam yeterli ve bunu hep kullanabilirim.
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Ball.transform.position + distance;    // Þimdi burada update metodunu kullandýk ama bu kamera olaylarýnda LateUpdate kullanýlýyor. Þimdi 3 tane Update türü görmüþ olucaðýz.

        // Bunlar FixedUpdate, Update, LateUpdate
        // LateUpdate = Bütün Updateler bittikten sonra çalýþýyor. Bu þekilde kameranýn görüntüsü daha güzel oluyor öbür türlü bazen titremeler olabiliyor.
    }
}
