using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMove : MonoBehaviour
{
    public Joystick joystick;//Joystick de�i�keni
    public Text lifeText, caseText;//Yaz� de�i�kenleri
    public Button button1, button2;//Buton de�i�kenleri
    Rigidbody rb;//Rigidbody de�i�keni
    float speed = 15f;//H�z de�i�keni
    int lifeCounter = 10;//Toplam Can
    public AudioClip sound1, sound2;//Ses de�i�kenleri
    [SerializeField] bool control = true;//Kontrol de�i�keni
    void Start()
    {
        rb = GetComponent<Rigidbody>();//Rigidbody eklentisine eri�im
    }
    void Update()
    {
        lifeText.text = lifeCounter + "";//Can say�s�n� yazd�r
        Vector3 force1 = new Vector3(joystick.Horizontal * speed, 0f, joystick.Vertical * speed);//Hareketi Joystick ile sa�lar
        rb.AddForce(force1);//Nesneye Kuvvet uygular
    }
    void OnCollisionEnter(Collision c1)//Tek seferlik �arp��ma fonksiyonu
    {
        if (c1.gameObject.tag == "Flower")//Oyuncu 'Flower' etiketli nesneye �arparsa
        {
            AudioSource.PlayClipAtPoint(sound2, transform.position);//Ses �alar
            button2.gameObject.SetActive(true);//Bir sonraki b�l�me ge�mek i�in gereken buton aktif hale gelir
            caseText.text = "Game completed";//Ekrana yaz� yazar
            Time.timeScale = 0f;//Oyun ekran� durur
        }
        else if (c1.gameObject.tag == "Wall")//Oyuncu 'Wall' etiketli nesneye �arparsa
        {
            if (!control)//Kontrol 'false' ise a�a��daki i�lemi ger�ekle�tir
            {
                AudioSource.PlayClipAtPoint(sound1, transform.position);//Ses �alar
                lifeCounter--;//Can� azalt�r
                lifeText.text = lifeCounter + "";//Can say�s�n� tekrar yazd�r
                if (lifeCounter == 0)//Can s�f�rsa
                {
                    button1.gameObject.SetActive(true);//B�l�m� tekrar oynamak i�in gereken buton aktif hale gelir
                    caseText.text = "Try again";//Ekrana yaz� yazar
                    Time.timeScale = 0f;//Oyun ekran� durur
                }
            }
        }
    }
    void OnCollisionStay(Collision other)//S�rekli �arp��ma fonksiyonu
    {
        if (other.gameObject.tag == "Wall")//Oyuncu 'Wall' etiketli nesneye s�rekli temas ederse
        {
            StartCoroutine(Damage());//�zel fonksiyon
            if (lifeCounter == 0)//Can 0 olursa
            {
                button1.gameObject.SetActive(true);//B�l�m� tekrar oynamak i�in gereken buton aktif hale gelir
                caseText.text = "Try again";//Ekrana yaz� yazar
                Time.timeScale = 0f;//Oyun ekran� durur
            }
        }
        IEnumerator Damage()//�terasyon fonksiyonu
        {
            if (control)//Kontrol 'true' ise a�a��daki i�lemi ger�ekle�tir
            {
                AudioSource.PlayClipAtPoint(sound1, transform.position);//Ses �alar
                lifeCounter--;//Can� azalt�r
                control = !control;//Kontrol� 'false' yap
                yield return new WaitForSeconds(1.5f);//1.5 saniye bekle        
                control = !control;//Kontrol� 'false' yap
            }
        }
    }
}

