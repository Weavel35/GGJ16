using UnityEngine;
using System.Collections;
 
[AddComponentMenu("Effects/SetRenderQueue")]
[RequireComponent(typeof(Renderer))]
 
public class SetRenderQueue : MonoBehaviour {
    public int queue = 1;
   
    public int[] queues;
   private Renderer _renderer;

    protected void Start() {
		_renderer = this.GetComponent<Renderer>();
        if (!_renderer || !_renderer.sharedMaterial || queues == null)
            return;
        _renderer.sharedMaterial.renderQueue = queue;
        for (int i = 0; i < queues.Length &&  i < _renderer.sharedMaterials.Length; i++)
            _renderer.sharedMaterials[i].renderQueue = queues[i];
    }
   
}