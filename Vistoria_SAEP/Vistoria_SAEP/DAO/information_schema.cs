using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vistoria_SAEP
{
    public class information_schema
    {
        public int autoIncrement { get; set; }

        public information_schema()
        {

        }
        public information_schema(MySqlDataReader dadoLido)
        {
            this.autoIncrement = !dadoLido.IsDBNull(0) ? dadoLido.GetInt16(0) : 0;
        }
    }
}