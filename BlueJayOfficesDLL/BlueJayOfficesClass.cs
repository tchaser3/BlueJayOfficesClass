/* Title:           Blue Jay Offices Class
 * Date:            1-7-20
 * Author:          Terry Holmes
 * 
 * Description:     This is used for the Blue Jay Offices */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace BlueJayOfficesDLL
{
    public class BlueJayOfficesClass
    {
        //setting up the classes
        EventLogClass TheEventLogClass = new EventLogClass();

        //setting up data
        BlueJayOfficesDataSet aBlueJayOfficesDataSet;
        BlueJayOfficesDataSetTableAdapters.bluejayofficesTableAdapter aBlueJayOfficesTableAdapter;

        InsertBlueJayOfficeEntryTableAdapters.QueriesTableAdapter aInsertBlueJayOfficeTableAdapter;

        UpdateBlueJayOfficeEntryTableAdapters.QueriesTableAdapter aUpdateBlueJayOfficeTableAdapter;

        FindActiveBlueJayOfficesDataSet aFindActiveBlueJayOfficesDataSet;
        FindActiveBlueJayOfficesDataSetTableAdapters.FindActiveBlueJayOfficesTableAdapter aFindActiveBlueJayOfficesTableAdatper;

        FindBlueJayOfficesByOfficeIDDataSet aFindBlueJayOfficeByOfficeIDDataSet;
        FindBlueJayOfficesByOfficeIDDataSetTableAdapters.FindBlueJayOfficeByOfficeIDTableAdapter aFindBlueJayOfficeByOfficeIDTableAdapter;

        public FindBlueJayOfficesByOfficeIDDataSet FindBlueJayOfficesByOfficeID(int intOfficeID)
        {
            try
            {
                aFindBlueJayOfficeByOfficeIDDataSet = new FindBlueJayOfficesByOfficeIDDataSet();
                aFindBlueJayOfficeByOfficeIDTableAdapter = new FindBlueJayOfficesByOfficeIDDataSetTableAdapters.FindBlueJayOfficeByOfficeIDTableAdapter();
                aFindBlueJayOfficeByOfficeIDTableAdapter.Fill(aFindBlueJayOfficeByOfficeIDDataSet.FindBlueJayOfficeByOfficeID, intOfficeID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Blue Jay Offices Class // Find Blue Jay Offices By Office ID " + Ex.Message);
            }

            return aFindBlueJayOfficeByOfficeIDDataSet;
        }
        public FindActiveBlueJayOfficesDataSet FindActiveBlueJayOffices()
        {
            try
            {
                aFindActiveBlueJayOfficesDataSet = new FindActiveBlueJayOfficesDataSet();
                aFindActiveBlueJayOfficesTableAdatper = new FindActiveBlueJayOfficesDataSetTableAdapters.FindActiveBlueJayOfficesTableAdapter();
                aFindActiveBlueJayOfficesTableAdatper.Fill(aFindActiveBlueJayOfficesDataSet.FindActiveBlueJayOffices);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Blue Jay Offices Class // Find Active Blue Jay Offices " + Ex.Message);
            }

            return aFindActiveBlueJayOfficesDataSet;
        }
        public bool UdpateBlueJayOffice(int intTransactionID, string strAddress, string strCity, string strState, string strZipCode, int intAreaManagerID)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateBlueJayOfficeTableAdapter = new UpdateBlueJayOfficeEntryTableAdapters.QueriesTableAdapter();
                aUpdateBlueJayOfficeTableAdapter.UpdateBlueJayOffice(intTransactionID, strAddress, strCity, strState, strZipCode, intAreaManagerID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Blue Jay Office Class // Update Blue Jay Office " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public bool InsertBlueJayOffice(int intOfficeID, string strAddress, string strCity, string strState,string strZipCode, int intAreaManagerID)
        {
            bool blnFatalError = false;

            try
            {
                aInsertBlueJayOfficeTableAdapter = new InsertBlueJayOfficeEntryTableAdapters.QueriesTableAdapter();
                aInsertBlueJayOfficeTableAdapter.InsertBlueJayOffice(intOfficeID, strAddress, strCity, strState, strZipCode, intAreaManagerID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Blue Jay Office Class // Insert Blue Jay Office " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public BlueJayOfficesDataSet GetBlueJayOfficesInfo()
        {
            try
            {
                aBlueJayOfficesDataSet = new BlueJayOfficesDataSet();
                aBlueJayOfficesTableAdapter = new BlueJayOfficesDataSetTableAdapters.bluejayofficesTableAdapter();
                aBlueJayOfficesTableAdapter.Fill(aBlueJayOfficesDataSet.bluejayoffices);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Blue Jay Offices Class // Get Blue Jay Offices Info " + Ex.Message);
            }

            return aBlueJayOfficesDataSet;
        }
        public void UpdateBlueJayOfficesDB(BlueJayOfficesDataSet aBlueJayOfficesDataSet)
        {
            try
            {
                aBlueJayOfficesTableAdapter = new BlueJayOfficesDataSetTableAdapters.bluejayofficesTableAdapter();
                aBlueJayOfficesTableAdapter.Update(aBlueJayOfficesDataSet.bluejayoffices);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Blue Jay Offices Class // Update Blue Jay Offices DB " + Ex.Message);
            }
        }
    }
}
