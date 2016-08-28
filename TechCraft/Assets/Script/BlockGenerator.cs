using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlockGenerator : MonoBehaviour {
	public bool isCursorLocked = true;
	public Camera playerCamera;
	public float reachableDistance = 5.0f;
	public GameObject blockPrefab;
	public GameObject blockGray;
	float blockWidth;
	public AudioClip putSound;
	public AudioClip destroySound;
	private AudioSource audioSource;
	public GameObject[] block;
	public GameObject selectedImage;

	Ray ray;
	RaycastHit hitInfo;
	Renderer blockGrayRenderer;
	Vector3 hitObjPos;
	Image image;
	Sprite[] sprite = new Sprite[5];

	void Awake () {
		for (int i = 0; i < block.Length; i++) {
			sprite [i] = Resources.Load<Sprite> (block [i].name);
		}
	}

	// Use this for initialization
	void Start () {
		if (isCursorLocked) {
			Cursor.visible = false;
		}

		blockWidth = blockPrefab.transform.localScale.x;
		blockGrayRenderer = blockGray.GetComponent<Renderer> ();

		audioSource = gameObject.GetComponent<AudioSource> ();

		image = selectedImage.GetComponent<Image> ();
		image.sprite = sprite [0];
	}

	// Update is called once per frame
	void Update () {
		if (isCursorLocked) {
			Cursor.lockState = CursorLockMode.Locked;
		}
			
		ray = playerCamera.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0.0f));
		bool isRayhit = Physics.Raycast (ray, out hitInfo, reachableDistance);

		// Show gray block
		if (isRayhit) {
			blockGrayRenderer.enabled = true;
			hitObjPos = hitInfo.collider.gameObject.transform.position;
			blockGray.transform.position = hitObjPos + hitInfo.normal * blockWidth;
		} else {
			blockGrayRenderer.enabled = false;
		}

		// Put blocks
		if (isRayhit && Input.GetMouseButtonDown (0)) {
			hitObjPos = hitInfo.collider.gameObject.transform.position;
			Instantiate (blockPrefab, hitObjPos + hitInfo.normal * blockWidth, Quaternion.identity);
			audioSource.clip = putSound;
			audioSource.Play ();
		}

		// Destoroy blocks
		if (isRayhit && Input.GetMouseButtonDown (1)) {
			Destroy (hitInfo.transform.gameObject);
			audioSource.clip = destroySound;
			audioSource.Play ();
		}


		// Select blocks
		for (int i = 1; i <= block.Length; i++) {
			if (Input.GetKeyDown (i.ToString ())) {
				blockPrefab = block [i - 1];
				image.sprite = sprite [i - 1];
			}
		}
	}
}