using Microsoft.Data.SqlClient;
using NewsPortal.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Areas.Admin.Services {
    public class CategoryRepository {

        //public List<Category> GetCategories() {
        //    List<Category> categories = null;
        //    try {
        //        using (SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-U7D8A9U\LORIKSQL;Initial Catalog=NewsPortalDb;Integrated Security=True")) {
        //            con.Open();
        //            SqlCommand cmd = new SqlCommand("select * from Category", con);
        //            SqlDataReader sdr = cmd.ExecuteReader();
        //            if (sdr.HasRows) {
        //                categories = new List<Category>();
        //                while(sdr.Read()) {
        //                    categories.Add(new Category(int.Parse(sdr["Id"].ToString()), sdr["Name"].ToString()));
        //                }
        //            }
        //        }
        //        return categories;
        //    }
        //    catch (Exception ex) {
        //        return null;
        //    }
        //} 

    }
}
