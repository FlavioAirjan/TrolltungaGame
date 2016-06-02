using UnityEngine;
using System.Collections;

 public interface mobIA  {



    void Start();


    void Update();


    void hitsound();


    IEnumerator Atack();


    void damaged();


    IEnumerator damagedAmine();

    void stopmove();

    void start();

    void dead();

    bool isAtacking();

    float dirValue();
}
