using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class getCrystal : MonoBehaviour
{
    private Text scoreText; //отображение на экране\
    private GameObject player;

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        print("SCORE");
    //        scoreText = (Text)FindObjectOfType(typeof(Text)); //ищем текстовое поле на экране
    //        scoreText.text = (int.Parse(scoreText.text) + 1).ToString(); //преобразовываем текст в integer и увеличиваем счет на единицу; возвращаем полученное число очков
    //        Destroy(gameObject); //удаляем кристалл с карты

    //    }
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            scoreText = (Text)FindObjectOfType(typeof(Text)); //ищем текстовое поле на экране
            scoreText.text = (int.Parse(scoreText.text) + 1).ToString(); //преобразовываем текст в integer и увеличиваем счет на единицу; возвращаем полученное число очков
            Destroy(gameObject); //удаляем кристалл с карты
        }
    }

    private void Start()
    {
        player = GameObject.Find("player");
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) > 50) 
        {
            Destroy(gameObject);
        }
    }
}
