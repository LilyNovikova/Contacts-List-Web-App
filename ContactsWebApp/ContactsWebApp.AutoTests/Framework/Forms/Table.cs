using Aquality.Selenium.Elements;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsWebApp.Framework.Forms
{
    public class Table : Form
    {
        private string TableLocator;
        private string HeaderCellLocator => "//tr//th";

        public Table(string xpathLocator) : base(By.XPath(xpathLocator), "Table")
        {
            TableLocator = xpathLocator;
        }

        public ILabel this[int row, int column] =>
            cellLbl(row, column);

        public ILabel this[int row, string columnHeader]
        {
            get
            {
                var headers = Headers;
                var column = headers.IndexOf(columnHeader);
                return this[row, column + 1];
            }
        }


        public IEnumerable<string> GetRow(int number)
        {
            var cells = ElementFactory.FindElements<Label>(By.XPath(TableLocator + RowCellLocator(number)), $" cell in table row {number}");
            return cells.Select(cell => cell.Text);
        }

        public IEnumerable<string> GetColumn(int number)
        {
            var cells = ElementFactory.FindElements<Label>(By.XPath(TableLocator + ColumnCellLocator(number)), $"cell in table column {number}");
            return cells.Select(cell => cell.Text);
        }

        public IEnumerable<string> GetColumn(string header)
        {
            var number = Headers.ToList().IndexOf(header) + 1;
            var cells = ElementFactory.FindElements<Label>(By.XPath(TableLocator + ColumnCellLocator(number)), $"cell in table column '{header}'");
            return cells.Select(cell => cell.Text);
        }

        public List<string> Headers
        {
            get
            {
                var cells = ElementFactory.FindElements<Label>(By.XPath(TableLocator + HeaderCellLocator), "table header");
                return cells.Select(cell => cell.Text).ToList();
            }
        }

        public ILabel GetCellByCondition(string resultColumnHeader, Func<string, bool> condition, string conditionColumnHeader)
        {
            var conditionColumn = GetColumn(conditionColumnHeader).ToList();
            var firstSuitable = conditionColumn.Where(cell => condition(cell)).First();
            var rowNumber = conditionColumn.IndexOf(firstSuitable) + 1;
            return this[rowNumber, resultColumnHeader];
        }

        private string RowCellLocator(int number) => $"/tr[.//td][{number}]//td";
        private string ColumnCellLocator(int number) => $"//tr[.//td]//td[{number}]";
        private ILabel cellLbl(int row, int column) =>
            ElementFactory.GetLabel(By.XPath(TableLocator + CellLocator(row, column)), $"table cell[{row}][{column}]");
        private string CellLocator(int row, int column) => $"//tr[.//td][{row}]//td[{column}]";


    }
}
