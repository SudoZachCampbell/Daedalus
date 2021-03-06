using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal targetPortal;
    public Transform normalVisible;
    public Transform normalInvisible;
    public Camera portalCamera;
    public Renderer viewthroughRenderer;
    public PortalType type;
    [SerializeField]
    private Material safeSky;
    [SerializeField]
    private Material darkSky;
    private RenderTexture viewthroughRenderTexture;
    private Material viewthroughMaterial;
    private Camera mainCamera;
    public bool portalDisabled = false;
    public Collider boxCollider;
    public bool flip = false;
    // Start is called before the first frame update
    void Start()
    {
        // Create render texture

        viewthroughRenderTexture = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.DefaultHDR);
        viewthroughRenderTexture.Create();

        // Assign render texture to portal material (cloned)

        viewthroughMaterial = viewthroughRenderer.material;
        viewthroughMaterial.mainTexture = viewthroughRenderTexture;
        // Assign render texture to portal camera

        portalCamera.targetTexture = viewthroughRenderTexture;
        portalCamera.GetComponent<Skybox>().material = type == PortalType.Light ? darkSky : safeSky;

        // Cache the main camera

        mainCamera = Camera.main;

        boxCollider = GetComponent<BoxCollider>();
    }

    private void LateUpdate()
    {
        var virtualPosition = TransformPositionBetweenPortals(this, targetPortal, mainCamera.transform.position);
        var virtualRotation = TransformRotationBetweenPortals(this, targetPortal, mainCamera.transform.rotation);

        // Position camera

        portalCamera.transform.SetPositionAndRotation(virtualPosition, virtualRotation);
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            portalCamera.fieldOfView = Mathf.Lerp(portalCamera.fieldOfView, 60, 10 * Time.deltaTime);

        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            portalCamera.fieldOfView = 40;
        }
    }

    private void OnDestroy()
    {
        // Release render texture from GPU

        viewthroughRenderTexture.Release();

        // Destroy cloned material and render texture

        Destroy(viewthroughMaterial);
        Destroy(viewthroughRenderTexture);
    }

    // Update is called once per frame
    void Update()
    {

    }


    public static Vector3 TransformPositionBetweenPortals(Portal sender, Portal target, Vector3 position)
    {
        return
            target.normalInvisible.TransformPoint(
                sender.normalVisible.InverseTransformPoint(position));
    }

    public static Quaternion TransformRotationBetweenPortals(Portal sender, Portal target, Quaternion rotation)
    {
        return
            target.normalInvisible.rotation *
            Quaternion.Inverse(sender.normalVisible.rotation) *
            rotation;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !portalDisabled)
        {
            targetPortal.portalDisabled = true;
            targetPortal.boxCollider.isTrigger = false;
            if (type == PortalType.Light)
            {
                mainCamera.GetComponent<Skybox>().material = darkSky;
                //RenderSettings.ambientLight = new Color(0, 0, 0);
                //mainCamera.cullingMask &= ~(1 << LayerMask.NameToLayer("Sun Layer"));
            }
            else
            {
                mainCamera.GetComponent<Skybox>().material = safeSky;
                //mainCamera.cullingMask |= 1 << LayerMask.NameToLayer("Sun Layer");
            }
            var spawnerTransform = targetPortal.transform.Find("Spawner").transform;
            other.gameObject.transform.position = new Vector3(spawnerTransform.position.x, other.gameObject.transform.position.y, spawnerTransform.position.z);
            other.gameObject.transform.rotation = spawnerTransform.rotation;
            StartCoroutine(PortalCooldown());
        }
    }

    private IEnumerator PortalCooldown()
    {
        while (true)
        {
            yield return new WaitForSeconds(2); //wait 2 seconds
            targetPortal.portalDisabled = false;
            targetPortal.boxCollider.isTrigger = true;
        }
    }

    public enum PortalType
    {
        Light,
        Dark
    }
}
