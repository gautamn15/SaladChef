using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class UiCustomers : MonoBehaviour
{
    public GameObject _CustomerTemplate;

    private List<UiCustomerInfo> mCustomerInfoList;
     
    
    public void CreateCustomer(Customer customer)
    {
        GameObject gameObject = Instantiate(_CustomerTemplate);
        UiCustomerInfo uiCustomerInfo = gameObject.GetComponent<UiCustomerInfo>();
        uiCustomerInfo.SetCustomerData(customer);
        gameObject.SetActive(true);
        uiCustomerInfo.transform.SetParent(_CustomerTemplate.transform.parent);
        uiCustomerInfo.transform.localScale = Vector3.one;

        
    }
}
