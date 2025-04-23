using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class First_Interactable : MonoBehaviour {

    public static First_Interactable Instance;

    public Material cube1;
    public Material cube2;
    [SerializeField] private GameObject above_Txt;
    [SerializeField] private GameObject bottom_Txt;
    [SerializeField] private GameObject details_Txt;
    [SerializeField] private GameObject heartlungTxt;
    [SerializeField] private GameObject referenceTxt;
    [SerializeField] private GameObject pulse_UI;
    [SerializeField] private BoxCollider[] boxColliders;

    bool aboveTxt_OnActivated;
    bool bottomTxt_OnActivated;
    public int count;
    public bool readyToTranstionSecondModel;

    private Animator m_Animator;
    Ray ray;
    Touch touch;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        StartAnimation();
        count = 0;
    }

    private void Update() {
        RayCast_Activated();
    }

    private void StartAnimation() {
        m_Animator = gameObject.transform.GetChild(0).GetComponent<Animator>();
        m_Animator.SetBool("FirstRotation", true);
    }

    private Vector3 GetMousePosition() {
        return Input.mousePosition;
    }

    public void Collider_Activated() {
        boxColliders[0].enabled = true;
        boxColliders[1].enabled = true;
        details_Txt.SetActive(true);
        pulse_UI.SetActive(true);
    }

    private void RayCast_Activated() {

        if (Input.GetMouseButtonDown(0)) {
            ray = Camera.main.ScreenPointToRay(GetMousePosition());
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity)) {
                Debug.Log("Hit: " + hit.collider.name);

                Hit_Activated(hit);
            }
        }
        else if (Input.touchCount > 0) {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity)) {
                    Hit_Activated(hit);
                }
            }
        }
    }

    public void Hit_Activated(RaycastHit hit) {
        if (hit.collider.tag == "Above_Text_Will Appear" && !aboveTxt_OnActivated) {
            GetComponent<MeshRenderer>().material = cube1;
            above_Txt.SetActive(true);
            //bottom_Txt.SetActive(false);
            aboveTxt_OnActivated = true;
            count++;
            if (count == 2) {
                Debug.Log("count: " + count);
                Invoke("ShaderDissolve_Activated", 3f);
            }
        }
        else if (hit.collider.tag == "Bottom_Text_Will Appear" && !bottomTxt_OnActivated) {
            GetComponent<MeshRenderer>().material = cube2;
            //above_Txt.SetActive(false);
            bottom_Txt.SetActive(true);
            bottomTxt_OnActivated = true;
            count++;
            if (count == 2) {
                Debug.Log("count: " + count);
                Invoke("ShaderDissolve_Activated", 3f);
            }
        }
    }

    // after effect finished activate the next ui healthy lung when model changed to healthy lung...
    // changing model another model that has a different anim.
    // after that appears ui reference pls background.
    public void ShaderDissolve_Activated() {
        Debug.Log("ShaderDissolve_Activated");
        readyToTranstionSecondModel = true;
        
        // show the correct model...
        // after 3s hide it...

    }

    public void HideUI() {
        above_Txt.SetActive(false);
        bottom_Txt.SetActive(false);
        details_Txt.SetActive(false);
        pulse_UI.SetActive(false);
    }

    public void healthyLung_Activated() {
        // continuing the aniamtion..
        heartlungTxt.SetActive(true);
    }

    public void healthyLung_Dectivated() {
        // continuing the aniamtion..
        heartlungTxt.SetActive(false);
    }

    public void ShowTheReference() {
        referenceTxt.SetActive(true);
    }
}
