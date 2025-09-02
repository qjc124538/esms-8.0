using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esms.Ddd.Test
{
    [SugarTable("ABP_TEST")]
    public class AbpTest
    {
        [SugarColumn(ColumnName = "ID", IsPrimaryKey = true, OracleSequenceName = "ABP_TEST_SEQ")]
        public decimal? Id { get; set; }

        [SugarColumn(ColumnName = "NAME")]
        public string? Name { get; set; }
    }
}
