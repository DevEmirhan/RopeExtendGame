using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool canMove = true;
    public UnityEngine.AI.NavMeshAgent myNavMesh;
    public FieldOfView fow;
    public FieldOfView fowArea;
    [SerializeField]
    private PathHolder myPaths;
    private bool isSeenPlayer;
    public Color seen;
    //public Animator gfxAnimator;
    public float waitSecondsNextMove;
    private bool startedNextPos;
    //public GameObject Warning;
    //public GameObject powParticle;

    private void Start()
    {
        transform.position = new Vector3(myPaths.CurrentPath().position.x, transform.position.y, myPaths.CurrentPath().position.z);
        StartCoroutine(WaitForNextMovement());
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove || GameManager.Instance.gameState != GameManager.GameState.Play)
            return;
        Debug.Log(isSeenPlayer);
        if (!isSeenPlayer)
        {
            #region player dedection
            //RaycastHit hit;
            //if (Physics.Raycast(transform.position, PlayerController.Instance.transform.position - transform.position, out hit, 10))
            //{
            //    if (hit.transform.CompareTag("Player"))
            //    {
            //        myNavMesh.isStopped = false;
            //        SetDestination(hit.transform.position);
            //        Warning.SetActive(true);
            //        if (!doOnceSound)
            //        {
            //            AudioSourceController.Instance.audioSource.PlayOneShot(warningSfx);
            //            doOnceSound = true;
            //        }
            //    }
            //    else
            //    {
            //        Warning.SetActive(false);
            //        doOnceSound = false;
            //    }
            //}
            #endregion
            // movement -------------------------------------------------
            if (myNavMesh.remainingDistance < 0.2f && !startedNextPos)
            {
                StartCoroutine(WaitForNextMovement());
            }
            // movement end ---------------------------------------------
            // player check ---------------------------------------------
            if (fow.visibleTargets.Contains(PlayerController.Instance.playerModel.transform) || fowArea.visibleTargets.Contains(PlayerController.Instance.playerModel.transform))
            {
                isSeenPlayer = true;
                PlayerController.Instance.Dead("enemyCatched");
               // Instantiate(powParticle, PlayerController.Instance.transform.position + Vector3.up * 2, powParticle.transform.rotation);
                StopMe();
                fow.viewMeshFilter.GetComponent<MeshRenderer>().materials[0].color = seen;
                fowArea.viewMeshFilter.GetComponent<MeshRenderer>().materials[0].color = seen;
                //Warning.SetActive(true);
            }
            // player check end ---------------------------------------------
        }
    }
    private void SetDestination(Vector3 pos)
    {
        //gfxAnimator.SetBool("isRunning", true);
        myNavMesh.destination = pos;
    }
    public void StopMe()
    {
        myNavMesh.isStopped = true;
        //gfxAnimator.SetBool("isRunning", false);
    }
    private IEnumerator WaitForNextMovement()
    {
        startedNextPos = true;
        StopMe();
        yield return new WaitForSeconds(waitSecondsNextMove);
        if (!isSeenPlayer || canMove)
        {
            myNavMesh.isStopped = false;
            SetDestination(myPaths.NextPathPosition());
            startedNextPos = false;
        }
    }
}
