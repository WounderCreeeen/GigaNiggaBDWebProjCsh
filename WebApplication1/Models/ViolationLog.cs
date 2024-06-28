public class ViolationLog
{
    public int ID { get; set; }
    public int BuildingID { get; set; }
    public DateTime Date { get; set; }
    public string Task { get; set; }
    public string Reason { get; set; }
}