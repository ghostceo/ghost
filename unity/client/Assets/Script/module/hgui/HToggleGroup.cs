
using UnityEngine.UI;
using System;
using UnityEngine.Events;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine;

public class HToggleGroup : UIBehaviour
{
    [Serializable]
    public class ToggleGroupEvent : UnityEvent<int> 
    { }

    public ToggleGroupEvent onValueChanged = new ToggleGroupEvent();

    public bool enableBack;

    private List<HToggle> m_Toggles = new List<HToggle>();
    private int nowChooseTab = 0;

    public List<HToggle> getToggleList()
    {
        return m_Toggles;
    }

    public HToggle getToggle(int index)
    {
        if (m_Toggles != null && m_Toggles[index] != null)
        {
            return m_Toggles[index];
        }
        return null;
    }

    public void NotifyToggleOn(HToggle toggle)
    {
        ValidateToggleIsInGroup(toggle);

        // disable all toggles in the group
        for (var i = 0; i < m_Toggles.Count; i++)
        {
            if (m_Toggles[i] == toggle) {
                onValueChanged.Invoke(i);
                nowChooseTab = i;
                continue;
            }
            m_Toggles[i].isOn = false;
        }
    }

    private void ValidateToggleIsInGroup(HToggle toggle)
    {
        if (toggle == null || !m_Toggles.Contains(toggle))
            throw new ArgumentException(string.Format("Toggle {0} is not part of ToggleGroup {1}", toggle, this));
    }

    public void UnregisterToggle(HToggle toggle)
    {
        if (m_Toggles.Contains(toggle))
        {
            m_Toggles.Remove(toggle);
        }
    }

    public void RegisterToggle(HToggle toggle)
    {
        if (!m_Toggles.Contains(toggle))
        {
            int siblingIndex = toggle.transform.GetSiblingIndex();
            for (var i = 0; i < m_Toggles.Count; i++)
            {
                if (siblingIndex < m_Toggles[i].transform.GetSiblingIndex())
                {
                    m_Toggles.Insert(i, toggle);
                    return;
                }
            }
            m_Toggles.Add(toggle);
        }
    }

    public bool AnyTogglesOn()
    {
        return m_Toggles.Find(x => x.isOn) != null;
    }

    public IEnumerable<HToggle> ActiveToggles()
    {
        return m_Toggles.Where(x => x.isOn);
    }

    public void SetAllTogglesOff()
    {
        for (var i = 0; i < m_Toggles.Count; i++)
        {
           m_Toggles[i].isOn = false;
        }
    }

    protected override  void OnEnable()
    {
        base.OnEnable();
        if (enableBack)
        {
            StartCoroutine(enableCallBack());
        }
    }

    
    IEnumerator enableCallBack()
    {
        yield return new WaitForSeconds(1);
        onValueChanged.Invoke(nowChooseTab);
    } 
    
    
    
}
