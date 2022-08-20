using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;     // User interface yani kullanýcý arayüz kütüphanesini ekledik.

public class Ball_Controller : MonoBehaviour
{

    Rigidbody fizik; // bir önceki dersimizde rigidbodyi void startýn içerisindeki satýrda tanýmalmýþtým aþaðýda örnek olarak yazýyor. Biz fiziðe hiç bir yerde ulaþamýyoruz, bu yüzden globalde tanýmlýyoruz.
    public int hiz;
    int sayac = 0;
    public int Coins;

    public Text SayacText;
    public Text Finish;

    // Start is called before the first frame update
    void Start()    // Bir kere çalýþan bir metot
    {
        fizik = GetComponent<Rigidbody>();        // Rigidbody fizik = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()         // Normal Update komutumuzu zaten biliyoruz, sürekli çalýþýyor ama belli bir zamana göre çalýþmýyor yani belli bir oranda deðil, deðiþebiliyor ama FixedUpdate sabittir eðer 
        // FixedUpdate kullanýrsak sabit olur. Biz fizik haraketlerini bu FixedUpdate ile yapýcaðýz. Sürekli çalýþýyor / Þimdi Update metodumuz bizim her framede çalýþýyor ama bize sabit hýzda çalýþan
        // metot lazým o zaman FixedUpdate i kullanýcaðýz. FixedUpdate de her zaman çalýþýyor ama sabit bir hýzda çalýþýyor.
    {
        float yatay = Input.GetAxisRaw("Horizontal");  // dikkat ettiyseniz büyük harfle baþladýk parametrede önemli çünkü küçük harfle Horizontal yazmayacaðýz. Horizontal = yatay demek Vertical = dikey
        float dikey = Input.GetAxisRaw("Vertical");   // demek. Peki Bu GetAxisRaw bize bir float döndürüyor yani bu metot bir float deðeri return ediyor, bizde bunu dikey diye bir deðiþken tanýmlayýp
                                                      // ona atadýk.

        Vector3 vec = new Vector3(yatay,0,dikey);  // Bu kod satýrýnýn anlamý nedir? = az sonra oyunumuzda topumuzu haraket ettiriceðiz. Hangi eksende haraket ettiðini bilmem gerekiyor. X ve Z ekseninde
                // haraket ettiriyoruz. Y ekseninde yani yukarý ve ya aþaðý gitmeyecek. Öne, arkaya, saða, sola gideceðinden dolayý X ve Z ekseninde haraket edicek.
            // Böyle bir vektör oluþturduk, bu vektörü yani vec i bir yere parametre olarak vereceðiz birazdan ve topumuz haraket edecek. Gördüðünüzde anlayacaksýnýz. x e yatayý atadýk y ye 0 ý z ye de 
               // dikeyi atadýk. Þimdi rigidbodyimizi oluþturucaz çünkü rigidbodymizin içerisinde bir metot var addforce diye topumuza kuvvet uyguluyor.

        fizik.AddForce(vec*hiz); // þimdi topumuza kuvvet uygulayacaðýz. Evet bu kadar haraket ettirme komudumuz bu kadardý. Haraket ediyor ama çok yavaþ haraket ediyor. hiz diye bir intager oluþturduk
        // public olucak þekilde ve bu vector3 müz ile çarpýyoruz. public komutu olduðundan scriptimizin arayüzünde artýk hiz diye bir sekme var ve buna bir deðer verirsek oyun motoru içerisinde hýzýný
        // istediðimiz gibi deðiþtirebiliriz manuel bir þekilde.

      //  Debug.Log("yatay =  " + yatay + "   dikey = " + dikey);     // bu komut konsolda  eðer yatayýn bir artmasýný istiyorsak D tuþuna basýyoruz - 1 olmasýný istiyorsakta A tuþuna basýyoruz.
                                                                   // dikey içinde 1 olmasýný istiyorsak W tuþuna basýyoruz eðer -1 olmasýný istiyorsak S tuþuna basýyoruz.



    }


    void OnTriggerEnter(Collider other)       // Þimdi bu trigger bir objeye temas edildiðinde bu metot çalýþacak. Bu ontrigger in þu þekilde 3 metodu var. Enter / Stay / Exit. Biz burada Enter kullanýcaz.
    {                                          // Enter = Bir kere temas olduðunda bir kere söylüyor ve bir daha çalýþmýyor.
                                               // Stay = Temas olduðu süre boyunca hep bizi uyarýyor.
                                               // Exit = Temas oldu ve temastan çýkýldýktan sonra yazdýrýyor.
                                               //  Debug.Log("Temas Oldu");

       // Destroy(other.gameObject);        // Burada gördüðünüz farklý bir parametre var other. Burada temas edilen oyun objesini yok et kodunu yazdýk ama bu çok iyi bir yöntem deðil çünkü bizim sahnemiz
                                        // de baþka triggerlý elemanlar olabilir. Biz sadece coin vb olan þeyleri silmek istedik ama farklý objelerde silindi bunu olsun istemedik. Buna bir çözüm olarak
                                        // öncelikle bu coinlerimize ve ya vb objelerimize birer etiket vermemiz gerekiyor tag yani prefab üzerinden add tag yapabiliriz ve hepsinde artýk coin diye bir tag
                                        // var. Þimdi biz diyeceðiz ki yukarýdaki kodda sadece coin olanlarý sil.


       // if (other.gameObject.tag== "Coins")       // Buradaki eðer komudunda sadece tagleri Coins isminde olan etiketli objeleri deðdikçe oyundan kaldýr/sil. 
       /* {
           // Destroy(other.gameObject);            // farký triggerlý olan objelere tag verip mesela x olsun x e deðerse konumunu deðiþtirebiliriz, yok edebiliriz, boyutunu deðiþtirebilirdik vb þeyleri
                                                    // yapabilirdik. Þimdi burada biz objelerimizi yok ediyoruz biz bunlarý yok etmeyelim sadece kapatalým.

            other.gameObject.SetActive(false);            // gameobjectin setactive diye bir metodu var

        }               */
       


        
        
        if (other.gameObject.tag == "Coins")         
        {
            other.gameObject.SetActive(false);
            sayac++;
            // Debug.Log("Sayac = " + sayac);     Bunlarý artýk console da göstermemize gerek kalmadý oyun ekranýnda görüyoruz.
            SayacText.text = "Coins = " + sayac;

                if (sayac == Coins)
                {
                   //  Debug.Log("Oyun Bitti");    Bunlarý artýk console da göstermemize gerek kalmadý oyun ekranýnda görüyoruz.
                   Finish.text = "Finish";
                }
        }
        
    }
}
