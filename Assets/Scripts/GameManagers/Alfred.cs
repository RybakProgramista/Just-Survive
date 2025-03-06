using UnityEngine;

public class Alfred : MonoBehaviour
{
    public static Alfred Instance { get; private set; }
    private TreeManager _treeManager;
    public TreeManager TreeManager
    {
        get { return _treeManager; }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        _treeManager = GetComponent<TreeManager>();
    }
}
