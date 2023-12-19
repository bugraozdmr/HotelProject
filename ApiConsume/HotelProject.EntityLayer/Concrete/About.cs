using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject.EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int AboutUsId { get; set; }
        public string Title1 { get; set; }
        public string Title2 { get; set; }
        public string Contentt { get; set; }
        public int CustomerCount { get; set; }
        public int RoomCount { get; set; }
        public int StaffCount { get; set; }
    }
}
