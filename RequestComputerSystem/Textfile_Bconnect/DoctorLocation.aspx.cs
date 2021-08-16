using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using System.IO;

namespace RequestComputerSystem.Textfile_Bconnect
{
    public partial class DoctorLocation : System.Web.UI.Page
    {
        string sql = "";
        DataTable dt;
        SQLclass cl_Sql = new SQLclass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string StatusLoad = "Location";
                if (Location())
                {
                    StatusLoad = "Doctor";
                    if (Doctor())
                    {
                        StatusLoad = "DoctorByLocation";
                        if (DoctorByLocation())
                        {
                            StatusLoad = "Success";
                        }
                    }
                }

                CheckStatusLaod(StatusLoad);
            }
        }

        public void CheckStatusLaod(string STL)
        {
            if (STL == "Success")
            {
                // SAVE LOG success
                CreateTextFile();
            }
            else
            {
                // SAVE LOG Error
            }
        }

        public Boolean CreateTextFile()
        {
            Boolean bl = false;

            string Path = "~/Textfile_Bconnect/Load/";
            string FilePath = Server.MapPath(Path + "Bconnect.txt");
            string FileContent = "Put File Content Here";
            File.WriteAllText(FilePath, FileContent);

            return bl;
        }

        protected Boolean Location()
        {
            Boolean bl = false;
            sql = "select LocationUID,Name from VwCareProviderLocation_BEG " +
                "where LocationUID > 0 group by LocationUID,Name; ";
            dt = new DataTable();
            dt = cl_Sql.selectBconnect(sql);
            if (dt.Rows.Count > 0)
            {
                bl = true;
            }

            return bl;
        }

        protected Boolean Doctor()
        {
            Boolean bl = false;
            sql = "select CareproviderUID,ServiceName from VwCareProviderLocation_BEG " +
                "group by CareproviderUID,ServiceName " +
                "order by CareproviderUID; ";
            dt = new DataTable();
            dt = cl_Sql.selectBconnect(sql);
            if (dt.Rows.Count > 0)
            {
                bl = true;
            }

            return bl;
        }
        
        protected Boolean DoctorByLocation()
        {
            Boolean bl = false;
            sql = "select LocationUID,CareproviderUID from VwCareProviderLocation_BEG " +
                "where LocationUID > 0 group by LocationUID,CareproviderUID; ";
            dt = new DataTable();
            dt = cl_Sql.selectBconnect(sql);
            if (dt.Rows.Count > 0)
            {
                bl = true;
            }

            return bl;
        }
    }
}