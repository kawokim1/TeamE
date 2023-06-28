using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public GameObject[] itemPrefab;
    Quaternion rotaition;
    float maxX = 1;
    float minX = -1;
    float minZ = -2;
    float maxZ = 2;
    /// <summary>
    /// �Ҹ�ð�
    /// </summary>
    public float extinction = 0.5f;

    GameObject lightEffect;
    GameObject smokeEffect;

    bool value = false;

    Animator anim;

    readonly int isOpen_String = Animator.StringToHash("isOpen");

    private void Awake()
    {
        anim = GetComponent<Animator>();

        lightEffect = transform.GetChild(2).gameObject;
        smokeEffect = transform.GetChild(3).gameObject;
    }
    private void OnInteraction(UnityEngine.InputSystem.InputAction.CallbackContext context)
    {
        if (value)
        {
            anim.SetBool(isOpen_String, true);
            value = false;
            StartCoroutine(LightEffect());
            StartCoroutine(SmokeEffect());
            StartCoroutine(Setfalse());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
         value = true;
    }
    private void OnDisable()
    {
        ItemSpawn();
    }
    IEnumerator LightEffect()
    {
        lightEffect.SetActive(true);
        yield return new WaitForSeconds(extinction);
        lightEffect.SetActive(false);
    }
    IEnumerator SmokeEffect()
    {
        yield return new WaitForSeconds(extinction);
        smokeEffect.SetActive(true);
        yield return new WaitForSeconds(extinction);
        smokeEffect.SetActive(false);
    }
    IEnumerator Setfalse()
    {
        yield return new WaitForSeconds(extinction += 0.3f);
        this.gameObject.SetActive(false);
    }
    void ItemSpawn()
    {
        for (int i =0; i < itemPrefab.Length; i++)
        {
            Vector3 spawnPos = new Vector3(transform.position.x + Random.Range(minX, maxX),
                0.5f,
                transform.position.z + Random.Range(minZ, maxZ));
            Instantiate(itemPrefab[i],
               spawnPos,
               rotaition);
        } 
    }
}
