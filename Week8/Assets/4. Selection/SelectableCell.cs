using UnityEngine;


	[RequireComponent(typeof(Cell))]
	public class SelectableCell : Selectable
	{
		public Color SelectedColor = Color.cyan;
		
		private Color cachedColor;
		private Renderer cellRenderer;
		private Cell cell;
		
		void Start()
		{
			// Field initialization
			cell = GetComponent<Cell>();
			cellRenderer = cell.TileRenderer;
			cachedColor = cellRenderer.sharedMaterial.color;

		}
		public override void OnSelect()
		{
			cellRenderer.material.color = SelectedColor;
		}

		public override void OnDeselect()
		{
			cellRenderer.material.color = cachedColor;
		}

		public Cell GetCell()
		{
			return cell;
		}
		
		public bool IsOccupied()
		{
			return GetComponentInChildren<Unit>() != null;
		}
		
	}
