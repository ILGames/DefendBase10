using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SpriteSheet : MonoBehaviour
{
    private int frames = 1;
    [SerializeField]
    [Range(0,100)]
    private int _frame = 0;
    public int Frame
    {
        set {
            _frame = value;
            UpdateUVS();
        }    
        get {return _frame;}
    }
    [SerializeField]
    private int _sizeX = 1;
    public int SizeX
    {
        set {
            _sizeX = value;
            UpdateUVS();
        }    
        get {return _sizeX;}
    }
    [SerializeField]
    private int _sizeY = 1;
    public int SizeY
    {
        set {
            _sizeY = value;
            UpdateUVS();
        }    
        get {return _sizeY;}
    }
    // is called by Unity when ever a value in the inspector is changed
    private void OnValidate()
    {
        SizeX = _sizeX;
        SizeY = _sizeY;
        Frame = _frame;
    }

    Vector2[] uv;
    Mesh mesh;
    MeshRenderer _renderer;
    Material material;

    MaterialPropertyBlock block;
    // Start is called before the first frame update
    void Start()
    {
        block = new MaterialPropertyBlock();
        Shader shader = Shader.Find("spritesheet");
        _renderer = GetComponent<MeshRenderer>();
        #if UNITY_EDITOR
            material = _renderer.sharedMaterial;
            //_renderer.sharedMaterial = Material.Instantiate(material) as Material;
        #else
            material = _renderer.material;
            //material = _renderer.material = material;  // clone!
            material = _renderer.material = Material.Instantiate(material) as Material;
        #endif
        /*
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        #if UNITY_EDITOR
            Mesh meshCopy = Mesh.Instantiate(meshFilter.sharedMesh) as Mesh;  //make a deep copy
            mesh = meshCopy; 
            meshFilter.mesh = mesh;
        #else
            //do this in play mode
            mesh = meshFilter.mesh;
        #endif
        //Mesh sharedMesh = GetComponent<MeshFilter>().sharedMesh;
        //Vector3[] vertices = mesh.vertices;
        uv = mesh.uv;
        Debug.Log("uv len b " + uv.Length);

        if(uv.Length == 0)
        {
            uv = new Vector2[4];
            uv[0] = new Vector2(0, 0);
            uv[1] = new Vector2(1, 0);
            uv[2] = new Vector2(0, 1);
            uv[3] = new Vector2(1, 1);
        }
*/

       /*
        uv[0] = new Vector2(0, 0);
        uv[1] = new Vector2(1, 0);
        uv[2] = new Vector2(0, 1);
        uv[3] = new Vector2(1, 1);
*/
       // mesh.uv = uv;
       // Debug.Log("uv len a " + uv.Length);

        UpdateUVS();
    }
    void UpdateUVS()
    {
        if(!material) return;
        if(block == null) return;
        //if(!mesh) return;
        int totalFrames = _sizeX * _sizeY;
        float offsetX = _frame % _sizeX;
        float offsetY = Mathf.Floor(_frame / _sizeX);

        float x = 1.0f/_sizeX;
        float y = 1.0f/_sizeY;

        //material.mainTextureScale = new Vector2(x, y);
        //material.mainTextureOffset = new Vector2(offsetX * x, 1 - y - offsetY * y);

        _renderer.GetPropertyBlock(block);
        // scale.x, scale.y, offset.x, offset.y
        block.SetVector("_MainTex_ST", new Vector4(x, y, offsetX * x, 1 - y - offsetY * y));
        _renderer.SetPropertyBlock(block);
        //shader
        
/*
        if(uv.Length == 0)
        {
            uv = new Vector2[4];
            uv[0] = new Vector2(0, 0);
            uv[1] = new Vector2(1, 0);
            uv[2] = new Vector2(0, 1);
            uv[3] = new Vector2(1, 1);
        }
*/
/*
        Vector2[] uvs = new Vector2[uv.Length];
        for (int i = 0; i < uv.Length; i++)
        {
            //(offsetX * x) + 
            //(offsetY * y) + 
            uvs[i] = new Vector2(uv[i].x * x + offsetX * x, 1- (uv[i].y * y + offsetY * y));
        }
        mesh.uv = uvs;*/
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
