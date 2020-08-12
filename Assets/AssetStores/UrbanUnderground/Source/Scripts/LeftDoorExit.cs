using UnityEngine;
using System.Collections;

public class LeftDoorExit : MonoBehaviour {
    
    // Z값이 -방향으로 내려갈 것임
    public bool openok = false;
    public bool opened = false;
    float timer;
    public void DoorOpen()
    {
        if (openok)
        {
            openok = false;
            StartCoroutine(DoorOpening());
        }
    }
    IEnumerator DoorOpening()
    {
        while (timer <= 5f)
        {
            timer += Time.deltaTime;
            transform.position =
                new Vector3(transform.position.x, transform.position.y, transform.position.z - (Time.deltaTime * 0.1f));
            yield return null;
        }
        opened = true;
    }

}
