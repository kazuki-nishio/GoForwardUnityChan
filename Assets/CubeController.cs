using System.Collections;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    //キューブの移動速度
    private float speed = -12;
    //消滅位置
    private float deadLine = -10;
    AudioSource audio;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        this.audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);
        //画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    //キューブが他のオブジェクトと接触したら音を鳴らす
     void OnCollisionEnter2D(Collision2D collision)
    {
        audio.PlayOneShot(audioClip, 0.5f);
        //ユニティちゃんと接触した場合は鳴らさない
        if(collision.gameObject.tag=="UnityChanTag")
        {
          audio.volume = 0;
        }
    }
}
