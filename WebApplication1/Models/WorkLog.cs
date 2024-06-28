public class WorkLog
{
    public int ID { get; set; }
    public int BuildingID { get; set; }
    public DateTime Date { get; set; }
    public string Task { get; set; }
    public DateTime DueDate { get; set; }
    public string Status { get; set; }
    public string Comment { get; set; }
    public string Quality { get; set; }
}