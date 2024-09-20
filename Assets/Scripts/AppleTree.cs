using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject applePrefab;
    public GameObject BranchPrefab;


    public float speed = 1f;

    public float leftAndRightEdge = 10f;

    public float changeDirChance = 0.1f;

    public float appleDropDelay = 1f;
    // Start is called before the first frame update
    void Start() {
        Invoke("DropApple", 2f);
    }

    // Update is called once per frame
    void Update() {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge) {
            speed = Mathf.Abs(speed);
        } else if (pos.x > leftAndRightEdge) {
            speed = -Mathf.Abs(speed); 
        }
        
    }

    void FixedUpdate() {
        if (Random.value < changeDirChance) {
            speed *= -1;
        }
    }

    void DropApple() {
        float randomNo = Random.value;
        if (randomNo < 0.8 ){
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);
        }
        else{

        GameObject apple = Instantiate<GameObject>(BranchPrefab);
        apple.transform.position = transform.position;
        Invoke("DropApple", appleDropDelay);

            
        }
    }
}
