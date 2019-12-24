using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CustomerMood
{
    NONE,
    WAITING,
    COMPLETED,
    ANGRY,
    
}

public class CustomerData
{
    public CustomerMood mCustomerMood;
    public float mTimeToServe;
    public List<int> mSaladItems;
}


public class Customer
{
    public CustomerData mCustomerData;
    public float mTimeLeftForOrder;

    public System.Action<Customer> mOnCustomerCallbackAction;
   
    private bool mStartTime = false;

    public void StartTime()
    {
        mStartTime = true;
        mTimeLeftForOrder = mCustomerData.mTimeToServe;
    }

    public void InvokeCallback()
    {
        if (mOnCustomerCallbackAction != null)
            mOnCustomerCallbackAction(this);
    }

    public void SetCustomerMood(CustomerMood customerMood)
    {
        mCustomerData.mCustomerMood = customerMood;
        InvokeCallback();
        
    }

    public void Update()
    {
        mTimeLeftForOrder -= Time.deltaTime;
    }

}

public class CustomerManager : MonoBehaviour
{
    public int _MaxCustomerInQueue = 5;
    public UiCustomers _UiCustomers;

    private Queue<Customer> mCustomerQueue = new Queue<Customer>();
    public List<Customer> mCustomerDataWaitingForOrderList = new List<Customer>();

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 20; ++i)
        {
            CreateCustomer(null, 100.0f);
        }

        Invoke("CreateCustomer", 20.0f);
    }

    void PollFoCustomers()
    {
        if (mCustomerDataWaitingForOrderList.Count < _MaxCustomerInQueue)
        {
            if (mCustomerQueue.Count > 0)
            {
                Customer customer = mCustomerQueue.Dequeue();
                mCustomerDataWaitingForOrderList.Add(customer);
                _UiCustomers.CreateCustomer(customer);
                customer.StartTime();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        PollFoCustomers();
        UpdateCustomers();
    }

    public void UpdateCustomers()
    {
        for (int i = 0; i < mCustomerDataWaitingForOrderList.Count; ++i)
        {
            mCustomerDataWaitingForOrderList[i].Update();
        }
    }

    public CustomerData CreateCustomer(List<int> items, float timeToServe)
    {
        CustomerData customerData = new CustomerData();
        customerData.mSaladItems = items;
        customerData.mTimeToServe = timeToServe;

        Customer customer = new Customer();
        customer.mCustomerData = customerData;
        customer.mTimeLeftForOrder = timeToServe;


        mCustomerQueue.Enqueue(customer);

        return customerData;
    }

    
}
