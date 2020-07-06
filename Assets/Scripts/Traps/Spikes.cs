using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private bool isOnUp = true;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveSpikes());
    }

    IEnumerator MoveSpikes()
    {
        while (true)
        {
            if (isOnUp)
            {
                MoveDown();
                yield return new WaitForSecondsRealtime(2);
            }
            else
            {
                MoveUp();
                yield return new WaitForSecondsRealtime(2);
            }
        }
    }

    private void MoveDown()
    {
        transform.position = transform.position + new Vector3(0, -10, 0);
        isOnUp = false;
    }

    private void MoveUp()
    {
        transform.position = transform.position + new Vector3(0, 10, 0);
        isOnUp = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            player.UpdateHealth(-12.5f);
        }
    }
}
