using ParkTogether.DAL.Entities;

namespace ParkTogether.DTOs
{
    public class ParkingCellRequest
    {
        public string AdminName { get; set; }
        public string AdminPassword { get; set; }
        public ParkingCell ParkingCell { get; set; }
    }
}
