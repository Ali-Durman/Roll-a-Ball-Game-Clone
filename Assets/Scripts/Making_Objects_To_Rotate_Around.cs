using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Making_Objects_To_Rotate_Around : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45)*Time.deltaTime);       // Burada kullandýðýmýz transform.Rotate vector3 axislerini alýyor. transform.Rotate adý üstünde döndürmeye yarýyor.
                                                                        // Burada ise vector3 ün x y z ile çaðrý zamanlarýyla çarparsak stabil bir þekilde yavaþlayacaktýr.
                                                                        // Bu üstte gördüðüm tüm kod coin ya da vb. objeleri stabil bir hýzda döndürmeye yarýyor. 
       // Debug.Log(Time.deltaTime);     Bu Time.deltaTime nedir? = Bu her update metodunun çaðrý zamaný demektir.
    }
}
