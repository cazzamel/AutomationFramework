using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AutomationFramework.Helpers
{
    public class HtmlTableHelper
    {
        private static List<TableDatacollection> _tableDatacollections;
        private static string Name;

        public static void ReadTable(IWebElement table, string TableLink1 = null, string TableLink2 = null, string TableLink3 = null)
        {
            //Initialize the table
            _tableDatacollections = new List<TableDatacollection>();

            //Get all the columns from the table
            var columns = table.FindElements(By.TagName("th"));

            //Get all the rows
            var rows = table.FindElements(By.TagName("tr"));

            //Create row index
            int rowIndex = 0;
            foreach (var row in rows)
            {
                int colIndex = 0;

                var colDatas = row.FindElements(By.TagName("td"));
                //Store data only if it has value in row
                if (colDatas.Count != 0)
                    foreach (var colValue in colDatas)
                    {
                        if (colValue.Text == TableLink1 || colValue.Text == TableLink2 || colValue.Text == TableLink3)
                        {
                            _tableDatacollections.Add(new TableDatacollection
                            {

                                RowNumber = rowIndex,

                                ColumnName = colValue.Text != "" ?
                                colValue.Text : colIndex.ToString(),

                                ColumnValue = colValue.Text + rowIndex,
                                ColumnSpecialValues = GetControl(colValue)
                            });
                        }
                        else
                        {
                            _tableDatacollections.Add(new TableDatacollection
                            {

                                RowNumber = rowIndex,

                                ColumnName = columns[colIndex].Text != "" ?
                                columns[colIndex].Text : colIndex.ToString(),

                                ColumnValue = colValue.Text,
                                ColumnSpecialValues = GetControl(colValue)
                            });
                            //Move to next column
                            colIndex++;
                        }
                        //Move to next Row
                        rowIndex++;
                    }
            }
        }

        private static ColumnSpecialValue GetControl(IWebElement columnValue)
        {
            ColumnSpecialValue columnSpecialValue = null;
            //Check if the control has specfic tags like input/hyperlink etc
            if (columnValue.FindElements(By.TagName("a")).Count > 0)
            {
                columnSpecialValue = new ColumnSpecialValue
                {
                    ElementCollection = columnValue.FindElements(By.TagName("a")),
                    ControlType = "hyperLink"
                };
            }
            if (columnValue.FindElements(By.TagName("input")).Count > 0)
            {
                columnSpecialValue = new ColumnSpecialValue
                {
                    ElementCollection = columnValue.FindElements(By.TagName("input")),
                    ControlType = "input"
                };
            }

            return columnSpecialValue;
        }


        public static void PerformActionOnCell(string refColumnValue = null, string controlToOperate = null)
        {
            foreach (int rowNumber in GetDynamicRowNumber(refColumnValue, controlToOperate))
            {
                var cell = (from e in _tableDatacollections
                            where e.ColumnName == refColumnValue && e.RowNumber == rowNumber
                            select e.ColumnSpecialValues).SingleOrDefault();

                //Need to operate on those controls
                if (controlToOperate != null && cell != null)
                {
                    //Since based on the control type, the retriving of text changes
                    //created this kind of control
                    if (cell.ControlType == "hyperLink")
                    {
                        var returnedControl = (from c in cell.ElementCollection
                                               where c.Text == refColumnValue
                                               select c).SingleOrDefault();

                        //ToDo: Currenly only click is supported, future is not taken care here
                        returnedControl?.Click();
                    }
                    if (cell.ControlType == "input")
                    {
                        var returnedControl = (from c in cell.ElementCollection
                                               where c.GetAttribute("value") == controlToOperate
                                               select c).SingleOrDefault();

                        //ToDo: Currenly only click is supported, future is not taken care here
                        returnedControl?.Click();
                    }

                }
                else
                {
                    cell.ElementCollection?.First().Click();
                }
            }
        }

        private static IEnumerable GetDynamicRowNumber(string columnName, string columnValue)
        {
            //dynamic row
            foreach (var table in _tableDatacollections)
            {
                if (table.ColumnName == columnName && table.ColumnValue == columnValue)
                    yield return table.RowNumber;
            }
        }
    }


    public class TableDatacollection
    {
        public int RowNumber { get; set; }
        public string ColumnName { get; set; }
        public string ColumnValue { get; set; }
        //public string Name { get; set; }
        public ColumnSpecialValue ColumnSpecialValues { get; set; }
    }

    public class ColumnSpecialValue
    {
        public IEnumerable<IWebElement> ElementCollection { get; set; }
        public string ControlType { get; set; }
    }
}
