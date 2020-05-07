using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meru_Test
{
    public class CustomerDBContext:DbContext
    {
        public CustomerDBContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer<CustomerDBContext>(new CreateDatabaseIfNotExists<CustomerDBContext>());


        }


        public virtual DbSet<Customer> Customers { get; set; }
    }

    [Table("Customers")]
    public class Customer
    {
        [Key]
        public int CustId { get; set; }

        public string CustName { get; set; }
        public int CustMobNo { get; set; }
        public string Address { get; set; }
        [ForeignKey("SubArea")]
        public int SubAreaId { get; set; }

        public virtual SubArea SubArea {get;set;}

    }

    [Table("SubAreas")]
    public class SubArea
    {
        [Key]
        public int SubAreaId { get; set; }

        public string SubAreaName { get; set; }
        [ForeignKey("Area")]
        public int AreaId { get; set; }
        public virtual Area Area { get; set; }

    }

    [Table("Areas")]
    public class Area
    {
        [Key]
        public int AreaId { get; set; }

        public string AreaName { get; set; }
        [ForeignKey("City")]
        public int CityId { get; set; }
        public virtual City City { get; set; }

    }

    [Table("Cities")]
    public class City
    {
        [Key]
        public int CityId { get; set; }

        public string CityName { get; set; }
        public string State { get; set; }
    }


}
