using UnityEngine;
using UnityEngine.InputSystem;

public class Merhaba : MonoBehaviour
{
    int sayac = 0;   // Kaç kez dokunulduğunu tutar
    [SerializeField] int kazanmaSiniri = 10;

    void Start()
    {
        Debug.Log("Oyun başladı! " + gameObject.name + " yakalanmayı bekliyor.");
    }

    void Update()
    {
        var isaret = Pointer.current;
        if (isaret == null || !isaret.press.wasPressedThisFrame) return;

        Vector2 ekran = isaret.position.ReadValue();
        Vector2 dunya = Camera.main.ScreenToWorldPoint(ekran);

        if (GetComponent<Collider2D>().OverlapPoint(dunya))
        {
            sayac = sayac + 1;
            Debug.Log("Dokunuldu! Toplam Yakalama: " + sayac);

            // Kazanma koşulu
            if (sayac >= kazanmaSiniri)
            {
                Debug.Log("TEBRİKLER! Oyunu Kazandın! 10 kez yakaladın.");
            }
        }
    }
}