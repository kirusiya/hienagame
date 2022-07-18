using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameControl : MonoBehaviour
{
    public GameObject gO_Hyena;
    public GameObject gO_Rabbit;
    public GameObject gO_Carrot;
    public GameObject gO_Farmer;
    public GameObject gO_Boat;

    public GameObject gO_Hyena_B;
    public GameObject gO_Rabbit_B;
    public GameObject gO_Carrot_B;
    public GameObject gO_Farmer_B;

    public GameObject gO_Hyena_F;
    public GameObject gO_Rabbit_F;
    public GameObject gO_Carrot_F;

    public Button btn_Move;

    // Start is called before the first frame update
    void Start()
    {
        btn_Move.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (gO_Farmer_B.activeInHierarchy && gO_Carrot_B.activeInHierarchy || gO_Farmer_B.activeInHierarchy && gO_Hyena_B.activeInHierarchy || gO_Farmer_B.activeInHierarchy && gO_Rabbit_B.activeInHierarchy) {
            btn_Move.interactable = true;
            Debug.Log ("Estoy activo");
        } else {
            btn_Move.interactable = false;
        }

        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Pressed primary button.");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
    
            if(hit.collider != null)
            {
                Debug.Log ("Target name: " + hit.collider.name);
                
                if (hit.collider.name == "GO_Hyena") {
                    Debug.Log("Haz seleccionado a: " + hit.collider.name);
                    gO_Hyena_B.SetActive(true);
                    gO_Hyena.SetActive(false);
                    gO_Rabbit_B.SetActive(false);
                    gO_Carrot_B.SetActive(false);

                    if (!gO_Rabbit_F.activeInHierarchy) {
                        gO_Rabbit.SetActive(true);
                    }
                    if (!gO_Carrot_F.activeInHierarchy) {
                        gO_Carrot.SetActive(true);
                    }
                } else if (hit.collider.name == "GO_Rabbit") {
                    Debug.Log("Haz seleccionado a: " + hit.collider.name);
                    gO_Hyena_B.SetActive(false);
                    gO_Rabbit_B.SetActive(true);
                    gO_Rabbit.SetActive(false);
                    gO_Carrot_B.SetActive(false);

                    if (!gO_Hyena_F.activeInHierarchy) {
                        gO_Hyena.SetActive(true);
                    }
                    if (!gO_Carrot_F.activeInHierarchy) {
                        gO_Carrot.SetActive(true);
                    }
                } else if (hit.collider.name == "GO_Carrot") {
                    Debug.Log("Haz seleccionado a: " + hit.collider.name);
                    gO_Hyena_B.SetActive(false);
                    gO_Rabbit_B.SetActive(false);
                    gO_Carrot_B.SetActive(true);
                    gO_Carrot.SetActive(false);
                    if (!gO_Hyena_F.activeInHierarchy) {
                        gO_Hyena.SetActive(true);
                    }
                    if (!gO_Rabbit_F.activeInHierarchy) {
                        gO_Rabbit.SetActive(true);
                    }
                } else if (hit.collider.name == "GO_Farmer") {
                    Debug.Log("Haz seleccionado a: " + hit.collider.name);
                    gO_Farmer_B.SetActive(true);
                    gO_Farmer.SetActive(false);
                } else if (hit.collider.name == "GO_Boat") {
                    Debug.Log("Haz seleccionado a: " + hit.collider.name);
                }
            }
        }
    }

    public void move() {
        if (gO_Carrot_B.activeInHierarchy) {
            gO_Carrot_F.SetActive(true);
            gO_Carrot_B.SetActive(false);
        } else if (gO_Hyena_B.activeInHierarchy) {
            gO_Hyena_F.SetActive(true);
            gO_Hyena_B.SetActive(false);
        } else if (gO_Rabbit_B.activeInHierarchy) {
            gO_Rabbit_F.SetActive(true);
            gO_Rabbit_B.SetActive(false);
        }
    }

    public void ResetScene() {
        SceneManager.LoadScene("SampleScene");
    }

}
