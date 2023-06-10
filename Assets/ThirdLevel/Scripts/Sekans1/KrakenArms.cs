using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class KrakenArms : MonoBehaviour
{
    public GameObject arm, rock;
    public Transform[] points;
    public float upVeloctiy, Force;
    private KrakenArmRock armRock;
    private Animator animator;

    private void Start()
    {
        
    }
    public void BossSekans1Calistir()
    {
        StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        for (int i = 0; i < points.Length; i++)
        {

            GameObject arms = Instantiate(arm, points[i].position, Quaternion.identity);
            animator = GameObject.FindGameObjectWithTag("krakenArm").GetComponent<Animator>();

            arms.transform.DOMoveY(-6.5f, 1f).OnComplete(() =>
            {

                arms.transform.DOMoveY(-6.5f, 2f).OnComplete(() =>
                {
                    animator.SetBool("Exit", true);
                    arms.transform.DOMoveY(-6.5f, 2f).OnComplete(() =>
                    {
                        animator.SetBool("Exit", false);
                        animator.SetBool("input", true);
                        arms.transform.DOMoveY(-20, 1f).OnComplete(() =>
                        {
                            animator.SetBool("input", false);
                            Destroy(arms);
                        });
                    });
                });
            });
            yield return new WaitForSeconds(10);
        }

    }
}


