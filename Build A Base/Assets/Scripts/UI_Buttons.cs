using UnityEngine;
using System.Collections;

public class UI_Buttons : MonoBehaviour 
{
	[SerializeField]GameObject m_livingQuarters;
    [SerializeField]GameObject m_Power;
    [SerializeField]GameObject m_Water;
    [SerializeField]GameObject m_Recyling;
    [SerializeField]GameObject m_Wind;
    [SerializeField]GameObject m_Communication;
	public GameObject Done;

    public void Living () 
	{
		m_livingQuarters.SetActive (true);
		Done.SetActive (true);
	}
    public void Power ()
        {
        m_Power.SetActive (true);
		Done.SetActive (true);
        }
    public void Water ()
    {
    m_Water.SetActive (true);
		Done.SetActive (true);
    }
    public void Recycling()
    {
        m_Recyling.SetActive (true);
		Done.SetActive (true);
    }
    public void Wind ()
    {
        m_Wind.SetActive(true);
		Done.SetActive (true);
    }
    public void Communication ()
    {
        m_Communication.SetActive(true);
		Done.SetActive (true);
    }
}
