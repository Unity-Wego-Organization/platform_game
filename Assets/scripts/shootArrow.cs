using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootArrow : MonoBehaviour
{
    public float LaunchForce;
    public GameObject arrow;
    public bow bow;
    private bool cooldown = false;
    private void Start()
    {
        bow = FindObjectOfType<bow>();
    }
    [SerializeField] public float cooldowntime;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && bow.ActiveBow && !cooldown)
        {
            cooldown = true;
            StartCoroutine(wait());
            shoot();
        }
    }
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(cooldowntime);
        cooldown = false;
    }
        void shoot()
    {
        GameObject ArrowIns = Instantiate(arrow, transform.position, transform.rotation);
        ArrowIns.GetComponent<Rigidbody2D>().AddForce(transform.right * LaunchForce);
    }
}
