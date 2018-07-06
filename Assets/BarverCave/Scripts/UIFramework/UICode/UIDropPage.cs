using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDropPage {
	private Transform _dropnode;
	private Image _dropwin;
	public bool _autoshown = true;

	public UIDropPage()
	{
		GameObject _page = GameObject.Instantiate(GameResources.loadGameObject(3)) as GameObject;
		_dropwin = _page.GetComponent<Image> ();
		_dropwin.rectTransform.SetParent (GameResources.Instance()._ObjUIPanel.transform);
		_dropwin.rectTransform.localScale = Vector3.one;
		_dropwin.rectTransform.anchoredPosition = Vector2.zero;

		_dropnode = _page.transform.Find("Panel");
		Button _close = _page.transform.Find("Close").GetComponent<Button> ();
		_close.onClick.AddListener (()=>{
			_page.SetActive (false);
			_autoshown = false;
		});
		hide ();
	}

	public void reloaddrop(){
		for (int i = _dropnode.childCount; i < 4; ++i) {
			RectTransform _item = gamedbmgr.Instance ().generateitemdrop (gamedbmgr.Instance()._debugitems[Random.Range(0,gamedbmgr.Instance()._debugitems.Count)]).GetComponent<RectTransform>();
			_item.SetParent(_dropnode);
			_item.localScale = Vector3.one;
		}
		_dropwin.gameObject.SetActive (true);
	}

	public void hide(){
		_dropwin.gameObject.SetActive (false);
	}
}
