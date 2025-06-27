using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Maintenance_App.Model
{
    public class Service
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Indexed]
        public int CarId { get; set; }
        [Indexed]
        public int UserId { get; set; }
        public string Status { get; set; } //possible enum
        public string Type { get; set; } //pssible enum
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime ServiceDate { get; set; }
    }
}
