using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiCustomerInfo : MonoBehaviour
{
    public Slider _SliderTimer;
    public Image _Image;

    private Customer mCustomer;

    public void SetCustomerData(Customer customer)
    {
        mCustomer = customer;
        mCustomer.mOnCustomerCallbackAction = OnCustomerCallback;

        UpdateSlider();
    }

    public void UpdateSlider()
    {
        _SliderTimer.value = 1.0f - (mCustomer.mCustomerData.mTimeToServe - mCustomer.mTimeLeftForOrder)/mCustomer.mCustomerData.mTimeToServe;
    }

    public void Update()
    {
        UpdateSlider();
    }

    public void OnCustomerCallback(Customer customer)
    {

    }


}
