
using System.Reflection;

namespace DickinsonBros.DataTable.Models
{
    public class DataTableWithPropertyInfo
    {
        public System.Data.DataTable DataTable { get; set; }
        public PropertyInfo[] Properties { get; set; }
    }
}
