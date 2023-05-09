using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMove : MonoBehaviour
{
    public Joystick joystick;//Joystick deðiþkeni
    public Text lifeText, caseText;//Yazý deðiþkenleri
    public Button button1, button2;//Buton deðiþkenleri
    Rigidbody rb;//Rigidbody deðiþkeni
    float speed = 15f;//Hýz deðiþkeni
    int lifeCounter = 10;//Toplam Can
    public AudioClip sound1, sound2;//Ses deðiþkenleri
    [SerializeField] bool control = true;//Kontrol deðiþkeni
    void Start()
    {
        rb = GetComponent<Rigidbody>();//Rigidbody eklentisine eriþim
    }
    void Update()
    {
        lifeText.text = lifeCounter + "";//Can sayýsýný yazdýr
        Vector3 force1 = new Vector3(joystick.Horizontal * speed, 0f, joystick.Vertical * speed);//Hareketi Joystick ile saðlar
        rb.AddForce(force1);//Nesneye Kuvvet uygular
    }
    void OnCollisionEnter(Collision c1)//Tek seferlik çarpýþma fonksiyonu
    {
        if (c1.gameObject.tag == "Flower")//Oyuncu 'Flower' etiketli nesneye çarparsa
        {
            AudioSource.PlayClipAtPoint(sound2, transform.position);//Ses çalar
            button2.gameObject.SetActive(true);//Bir sonraki bölüme geçmek için gereken buton aktif hale gelir
            caseText.text = "Game completed";//Ekrana yazý yazar
            Time.timeScale = 0f;//Oyun ekraný durur
        }
        else if (c1.gameObject.tag == "Wall")//Oyuncu 'Wall' etiketli nesneye çarparsa
        {
            if (!control)//Kontrol 'false' ise aþaðýdaki iþlemi gerçekleþtir
            {
                AudioSource.PlayClipAtPoint(sound1, transform.position);//Ses çalar
                lifeCounter--;//Caný azaltýr
                lifeText.text = lifeCounter + "";//Can sayýsýný tekrar yazdýr
                if (lifeCounter == 0)//Can sýfýrsa
                {
                    button1.gameObject.SetActive(true);//Bölümü tekrar oynamak için gereken buton aktif hale gelir
                    caseText.text = "Try again";//Ekrana yazý yazar
                    Time.timeScale = 0f;//Oyun ekraný durur
                }
            }
        }
    }
    void OnCollisionStay(Collision other)//Sürekli çarpýþma fonksiyonu
    {
        if (other.gameObject.tag == "Wall")//Oyuncu 'Wall' etiketli nesneye sürekli temas ederse
        {
            StartCoroutine(Damage());//Özel fonksiyon
            if (lifeCounter == 0)//Can 0 olursa
            {
                button1.gameObject.SetActive(true);//Bölümü tekrar oynamak için gereken buton aktif hale gelir
                caseText.text = "Try again";//Ekrana yazý yazar
                Time.timeScale = 0f;//Oyun ekraný durur
            }
        }
        IEnumerator Damage()//Ýterasyon fonksiyonu
        {
            if (control)//Kontrol 'true' ise aþaðýdaki iþlemi gerçekleþtir
            {
                AudioSource.PlayClipAtPoint(sound1, transform.position);//Ses çalar
                lifeCounter--;//Caný azaltýr
                control = !control;//Kontrolü 'false' yap
                yield return new WaitForSeconds(1.5f);//1.5 saniye bekle        
                control = !control;//Kontrolü 'false' yap
            }
        }
    }
}

