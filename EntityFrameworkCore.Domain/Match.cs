namespace EntityFrameworkCore.Domain
{
    public class Match : BaseDomainModel
    {
        public int HomeId { get; set; }
        public int AwayId { get; set; }
        public decimal TicketPrice { get; set; }
        public DateTime Date { get; set; }
    }
}
