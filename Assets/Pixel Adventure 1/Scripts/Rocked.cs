using System.Collections;
using UnityEngine;

public class HareketEt : MonoBehaviour
{
    public float wait = 2f;
    public float hiz = 5f;


    private Transform player;
    private Vector3 baslangicKonum;
    private bool following = false;
    private bool waiting = false;
    public Animator animator;

    string Rocked_Wake = "Rocked_Wake";
    //string Rocked_Sleep = "Rocked_Sleep";
    string Rocked_GoToBed = "Rocked_GoToBed";
    //string Rocked_Hunt = "Rocked_Hunt";


    void Start()
    {
        baslangicKonum = transform.position;
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player") && !waiting)
        {
            player = collider.transform;
            animator.Play(Rocked_Wake);

            following = true;
            StartCoroutine(WaitAndFollowRoutine());
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            animator.Play(Rocked_GoToBed);
            following = false;
            StopCoroutine(WaitAndFollowRoutine());
            waiting = false;
        }
    }

    IEnumerator WaitAndFollowRoutine()
    {
        waiting = true;

        yield return new WaitForSeconds(wait);

        while (following && player != null)
        {
            float yon = (player.position - transform.position).normalized.x;
            transform.Translate(Vector2.right * yon * hiz * Time.deltaTime);
            yield return null;
        }

        waiting = false;
    }
}