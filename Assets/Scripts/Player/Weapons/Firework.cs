using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firework : MonoBehaviour
{
    public WeaponVariables weaponType;
    // bools for ground use
    bool rotating;
    PlaystyleEnum behavior;
    public Vector3 target;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        if (GameManager.instance.currentPlaystyle == PlaystyleEnum.PILOT)
        {
            this.transform.rotation = Quaternion.Euler(-90, 0, 0);
            behavior = PlaystyleEnum.PILOT;
            speed = weaponType.speed;
        }
        else
        {
            this.transform.rotation = Quaternion.Euler(0, 0, 0);
            target = this.transform.position + new Vector3(0, 30f, 0);
            behavior = PlaystyleEnum.SOLDIER;
            speed = 10f;
        }

    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, target, speed * Time.deltaTime);

        if (behavior == PlaystyleEnum.SOLDIER)
        {
          StartCoroutine(RiseAndFall());
        }
    }

    IEnumerator RiseAndFall()
    {
        Vector3 originalPosition = this.transform.position;
        yield return new WaitUntil(() => this.transform.position.y == target.y);
        this.transform.rotation = Quaternion.Euler(0, 180, 0);
        target = originalPosition;
        StartCoroutine(WaitForExplosion());
    }

    IEnumerator WaitForExplosion()
    {
        yield return null;
    }
}
